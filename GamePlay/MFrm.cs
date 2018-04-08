using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using RACoN;
using RACoN.RTILayer;
using AGI.STKObjects;
using AGI.STKUtil;

using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

namespace STK_demonstration
{
    public partial class MFrm : Form
    {
        private delegate void DealPacketDelegate(object pack);
        public CSimulationManager simulation = null;
        public CState state = null;
        public RD_XmlReadWrite RdXml;  //保存仿真数据用于回放
        public STKScenObjs Scenemana;
        //public excelhelp ehelper;
        //新建场景使用参数以及默认值
        #region 时间参数
        public string scenenamenew="default";
        public string startTime= "18 Feb 2017 00:00:00.00";
        public string endTime= "18 Feb 2017 04:00:00.00";
        public DateTime dStartTime;
        public double stepTime = 0.1;
        #endregion
        #region 窗体
        public ChartView chartView;
        public TrafficView trafficView;
        public ShowUsers showusers;
        public wincmd wcmd;
        indicate ind;
        Django djg;
        #endregion
        /// <summary>
        /// 覆盖相关
        /// </summary>
        private bool covsetup=false;
        private double covrate;
        private const double R = 6371.0;
        public string linkinfo_update = null;
        public MFrm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            state = new CState();
            RdXml = new RD_XmlReadWrite();
            Scenemana = new STKScenObjs(this);
            state.isSceneSetUp = false;
            state.workMode = CState.WorkMode.SimMode;//默认为仿真模式

            chartView = new ChartView();
            chartView.Hide();
            trafficView = new TrafficView();
            trafficView.Hide();
            showusers = new ShowUsers(this);
            showusers.Hide();
            wcmd = new wincmd(this);
            wcmd.Hide();
            //主要目的是新建一个苟窗体
            djg = new Django(this);
            djg.Hide();
            //新建一个excel帮助器
            //ehelper = new excelhelp(this);
        }
        #region 回放相关
        private bool StartReplay(string stkXmlName)
        {
            this.Cursor = Cursors.WaitCursor;
            this.scenenamenew = stkXmlName;
            //自动建立新场景
            //新场景ToolStripMenuItem_Click(null, null);

            //开子线程，读回放数据
            RdXml.fasterTimes = state.replayDataFaster;//修改读取包的速度，由于子线程还未开始，不用锁
            RdXml.DealPacketCallback = this.DealPacket;
            Thread xmlThread = new Thread(this.RdXml.ReadXml);
            xmlThread.Name = "xmlThread";
            xmlThread.IsBackground = true;
            this.RdXml.xmlReaderThread = xmlThread;
            xmlThread.Start();
            this.Cursor = Cursors.Default;
            return true;
        }
        
        #endregion
        #region 场景相关
        public void ResetCloseScene()
        {
            //0725添加新的excel处理，上次的还有问题
            string res;
            CmdHelper.RunCmd("taskkill /f /im excel.exe", out res);
            if (this.state.isSceneSetUp == false)    //isScenesetup说明rdxml清理过
            {
                if (root.CurrentScenario != null)   //20150907
                {
                    state.isSceneSetUp = false;//STK仿真场景是否已建立
                    CloseScene();
                }
                return;
            }

            DateTime start = DateTime.Now;
            //LogHelper.InfoLog("ResetCloseScene", "进入函数");
            TimeSpan tSpan = DateTime.Now - start;//中间的时间差是执行Loghelper的时间
            this.root.Pause();
            this.Cursor = Cursors.WaitCursor;

            //RdXml
            if (this.RdXml.xmlReaderThread != null)
            {
                if ((this.RdXml.xmlReaderThread.ThreadState & System.Threading.ThreadState.Stopped) == System.Threading.ThreadState.Stopped)
                {
                    //Application.DoEvents();
                    //LogHelper.InfoLog("xmlReaderThread", "已关闭");
                }
                else
                {
                    lock (this.RdXml.stopRead)
                    {
                        if (this.RdXml.isStopRead == false) //在主线程中修改使子线程自然退出
                            this.RdXml.isStopRead = true;
                    }
                    start = DateTime.Now;
                    while (true)
                    {
                        lock (this.RdXml.stopRead)
                        {
                            //Thread对象的ThreadState属性提供一个由ThreadState定义的位掩码，它指示线程的当前状态。一个线程至少总是处于ThreadState枚举中定义的一个可能状态，并且可以同时处于多个状态。
                            //1&1 =1; 结果是不变的才对.
                            if (this.RdXml.isStopRead == false)
                            {
                                //Application.DoEvents();
                                break;
                            }
                            else if ((this.RdXml.xmlReaderThread.ThreadState & System.Threading.ThreadState.Stopped) == System.Threading.ThreadState.Stopped)
                            {
                                this.RdXml.isStopRead = false;
                                //Application.DoEvents();
                                break;
                            }
                            else if ((this.RdXml.xmlReaderThread.ThreadState & System.Threading.ThreadState.WaitSleepJoin) == System.Threading.ThreadState.WaitSleepJoin)
                            {
                                try
                                {
                                    this.RdXml.xmlReaderThread.Interrupt();//唤醒之并忽略报的异常
                                }
                                catch (System.Threading.ThreadInterruptedException)
                                {

                                }
                            }
                        }
                        Application.DoEvents(); //清空当前的消息队列，防止子线程发出的更新控件消息在控件回收后才处理
                        System.Threading.Thread.Sleep(100);
                        //强制退出机制
                        tSpan = DateTime.Now - start;
                        if (tSpan.TotalMinutes > 1)
                        {
                            WaitForm waitForm = new WaitForm();
                            waitForm.Text = "关闭场景超时，是否退出软件";
                            waitForm.ShowDialog();
                            if (waitForm.buttonClicked.Equals("buttonYes"))
                            {
                                Application.Exit();
                            }
                            else
                                start = DateTime.Now;
                        }
                    }
                }
            }
            Application.DoEvents();
            if (this.state.isSceneSetUp == true)
            {
                state.isSceneSetUp = false;//STK仿真场景是否已建立
                CloseScene();
            }           

            //STK仿真场景Lev1的全部obj，例如卫星、实体等
            Scenemana.stkObjs.Clear();
            Scenemana.sensorcolor_index = 0;
            Scenemana.all_path.Clear();
            Scenemana.LineTargets.Clear();

            this.RdXml.allPackets.Clear();
            this.RdXml.sw.Reset();
            try
            {
                //Other Form
                chartView.Dispose();
                chartView = new ChartView();
                chartView.Hide();
                trafficView.Dispose();
                trafficView = new TrafficView();
                trafficView.Hide();
            }
            catch
            {
            }
            System.Threading.Thread.Sleep(100);
            this.toolStripStatusLabel2.Text = "场景名";
            this.toolStripStatusLabel4.Text = "未开始";
            state.replayDataFaster = 1;
            toolStripStatusLabel5.Text = "x" + state.replayDataFaster.ToString();

            this.Cursor = Cursors.Default;
        }
        private void CloseScene()
        {
            try
            {
                AxAGI.STKX.AxAgUiAxVOCntrl crl3d = new AxAGI.STKX.AxAgUiAxVOCntrl();
                AxAGI.STKX.AxAgUiAx2DCntrl crl2d = new AxAGI.STKX.AxAgUiAx2DCntrl();

                crl3d.Dock = DockStyle.Fill;
                crl2d.Dock = DockStyle.Fill;

                
                tabPage1.Controls.Clear();//清空3d场景
                tabPage2.Controls.Clear();//清空2d场景

                axAgUiAxVOCntrl1.Dispose();
                axAgUiAx2DCntrl1.Dispose();

                tabPage1.Controls.Add(crl3d);
                tabPage2.Controls.Add(crl2d);

                axAgUiAxVOCntrl1 = crl3d;
                axAgUiAx2DCntrl1 = crl2d;

                Thread.Sleep(100);
                state.isSceneSetUp = false;
                //清空信息队列和建立链路的索引
                this.Scenemana.msglist.Clear();
                //this.index = 0;
                //覆盖性能相关的复原工作
                covsetup = false;
                信关站覆盖显示ToolStripMenuItem.Checked = false;
                //每次重启的时候强行终止所有的excel程序，防止下次出现错误
                string res;
                CmdHelper.RunCmd("taskkill /f /im excel.exe",out res);
                //0810再次更改
                this.Scenemana = new STKScenObjs(this);
            }
            catch
            {
            }
        }
        #endregion
        #region 覆盖相关
        private double covcal(double volve)
        {
            int i, j;//分别代表当前的纬度和经度
            double total=0;//计算得到的点位总数
            double pie;//当前纬度的权重
            double r;//当前纬度的旋转半径
            double line;//当前行的覆盖范围内的总点数（最后加权）
            bool mark = false;//用于判决的标志位
            double lineall;//表示当前纬度总共有多少个样本点(加权后)
            double all = 0;
            for (i=-89;i<90;i++)//舍弃极地的权重
            {
                r = R * Math.Cos(i);
                pie = Math.Cos(i);
                line = 0;
                for(j=-180;j<180; j++)
                {
                    mark = false;
                    foreach(var o in Scenemana.stkcities)
                    {
                        double dis = GetDistance(i, j, o.lat, o.lon);
                        if (dis<volve)
                        {
                            mark = true;
                            break;
                        }
                    }
                    if(mark)
                    {
                        line++;
                    }
                }
                line = line * pie;//进行加权
                lineall = 360 * pie;
                total += line;
                all += lineall;
            }
            double rate = total / all;
            return rate;
        }
        private double GetDistance(double lx,double ly,double rx,double ry)
        {
            return R * (Math.Acos(Math.Cos(lx.ToRadius()) * Math.Cos(rx.ToRadius()) * Math.Cos(ly.ToRadius() - ry.ToRadius()) + Math.Sin(lx.ToRadius()) * Math.Sin(rx.ToRadius())));
        }
        #endregion
        #region root
        public AGI.STKObjects.AgStkObjectRoot root
        {
            get
            {
                if (rootObject == null)
                {
                    rootObject = new AGI.STKObjects.AgStkObjectRoot();
                }
                return rootObject;
            }
        }
        private AGI.STKObjects.AgStkObjectRoot rootObject = null;

        public void DoSimulation()
        {
            if ((this.simulation.federate.FederateState & RACoN.FederateStates.JOINED) == RACoN.FederateStates.JOINED)
            {
                this.simulation.federate.Run();
            }
        }
        #endregion
        public void display(string str)
        {
            ind.wordsTosay = str;
            ind.Show();           
            timer1.Interval = 1500;
            timer1.Enabled = true;
        }
        #region 事件
        private void 加入联邦ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (simulation == null)
            {
                simulation = new CSimulationManager(this);
                simulation.federation.FederateName = "STKDEMO";
            }
            if (this.simulation.federate.FederateState == FederateStates.JOINED)
                return;
            //下面开始算是开始发功了，耗时
            this.Cursor = Cursors.WaitCursor;
            bool result = true;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    result = this.simulation.federate.InitializeFederation(simulation.federation);
                }
                catch
                {
                }
                if (!result)
                {
                    Thread.Sleep(100);
                    continue;
                }
                else
                    break;
            }
            if (!result)
            {
                MessageBox.Show("加入联邦失败");
                simulation = null;
                return;
             }
             //清理标志位
             this.加入联邦ToolStripMenuItem.Enabled = false;
             this.退出联邦ToolStripMenuItem.Enabled = true;
             stFed.Text = "已加入联邦";
            this.Cursor = Cursors.Default;
            display("已加入联邦");
        }

        private void 退出联邦ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (simulation == null)
            {
                return;
            }
            if ((this.simulation.federate.FederateState&RACoN.FederateStates.JOINED)==0)
            {
                this.加入联邦ToolStripMenuItem.Enabled = true;
                this.退出联邦ToolStripMenuItem.Enabled = false;
                this.stFed.Text = "已退出联邦";
                return;
            }
            if ((this.simulation.federate.FederateState & RACoN.FederateStates.JOINED) != 0)
            {
                if (this.simulation.federate.FinalizeFederation(this.simulation.federation,
                    RACoN.ResignAction.DELETE_OBJECTS_THEN_DIVEST) == false)//
                {
                    return; //20150904发现RTI明明已退出但就是==false导致状态显示错误，重启RTI后正常！可能是因为正在和OPNET经RTI通信
                }
                this.加入联邦ToolStripMenuItem.Enabled = true;
                this.退出联邦ToolStripMenuItem.Enabled = false;
                this.stFed.Text = "已退出联邦";
            }
        }            

        public void 新场景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetCloseScene();
            try
            {
                root.NewScenario(this.scenenamenew);  
                this.toolStripStatusLabel3.Text = this.scenenamenew;
                //设置场景时间和步长：
                StringBuilder cmd = new StringBuilder();
                StringBuilder cmd2 = new StringBuilder();
                cmd.AppendFormat("SetAnalysisTimePeriod * \"{0}\" \"{1}\"", startTime, endTime);
                cmd2.AppendFormat("SetAnimation * StartTimeOnly UseAnalysisStartTime EndMode Loop Endtime UseAnalysisEndTime TimeStep {0}", stepTime);

                root.ExecuteCommand(cmd.ToString());
                root.ExecuteCommand(cmd2.ToString());

                this.root.ExecuteCommand("SetUnits / km");
                this.root.ExecuteCommand("VO * Annotation Time XPos 10.0 YPos 60.0 Color Red");
                this.root.ExecuteCommand("VO * Annotation ViewerPos Show On Color Red");

                //建立场景正确
                this.state.isSceneSetUp = true;
                this.卸载场景ToolStripMenuItem.Enabled = true;
                //场景复位
                toolStripButton1_Click(null, null);
                //this.Scenemana.newsat();//调试用代码
                ////this.Scenemana.newcity(); 
                //this.Scenemana.newwalker("sat", 2, 3, 360);

            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.ToString());
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.wcmd.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.state.isSceneSetUp == false)
                return;
            this.root.Rewind();//复位
            this.root.ExecuteCommand("VO * View Home");
        }
       

        private void 卸载场景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetCloseScene();
            this.toolStripStatusLabel3.Text = "场景名";
            this.toolStripStatusLabel4.Text = "未开始";
            卸载场景ToolStripMenuItem.Enabled = false;
        }
        private void 回放模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //进入回放模式，关RTI数据接收，防止干扰回放过程
            state.workMode = CState.WorkMode.ReplayMode;
            ResetCloseScene();
            this.toolStripStatusLabel2.Text = "回放模式";
            string replayXml = System.IO.Directory.GetCurrentDirectory() + "\\回放数据xml";
            //string stkXml = System.IO.Directory.GetCurrentDirectory() + "\\STK场景xml";
            string temp = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (Directory.Exists(replayXml) == false)
            {
                MessageBox.Show("打开xml文件路径出错！\r\n" + replayXml);
                replayXml = @"C:\";
            }
            openFileDialog.InitialDirectory = replayXml;
            openFileDialog.Filter = "xml文件|*.xml";
            openFileDialog.Title = "打开建立STK场景的xml文件";
            while (true)
            {
                //LogHelper.InfoLog("一键回放ToolStripMenuItem_Click", "进入while循环");
                DialogResult result = DialogResult.Cancel;
                try
                {
                    result = openFileDialog.ShowDialog();
                }
                catch 
                {

                }
                if (result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (File.Exists(filePath) == false)
                    {
                        MessageBox.Show("文件不存在！");
                        continue;
                    }
                    temp = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    this.RdXml.replayXmlName = temp;
                    break;
                }
                else
                {
                    //fortest
                    MessageBox.Show("未正确打开建场景的xml文件");
                    return;
                }
            }
            //LogHelper.InfoLog("一键回放ToolStripMenuItem_Click", "进入StartReplay");
            //读XML建STK场景，注意此XML命名与Scenario一致
            if (StartReplay(this.RdXml.replayXmlName) == false)
                MessageBox.Show("未正确建立场景");
            this.Cursor = Cursors.Default;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (this.state.isSceneSetUp == false)
                return;           
            this.root.PlayForward();
            if (this.state.workMode == CState.WorkMode.ReplayMode)
            {
                lock (this.RdXml.stopRead)
                {
                    if (RdXml.isPauseRead == true)
                    {
                        RdXml.isPauseRead = false;
                    }
                    if (RdXml.xmlReaderThread != null)
                    {
                        if ((this.RdXml.xmlReaderThread.ThreadState & System.Threading.ThreadState.WaitSleepJoin) == System.Threading.ThreadState.WaitSleepJoin)
                        {
                            try
                            {
                                this.RdXml.xmlReaderThread.Interrupt();//唤醒之并忽略报的异常
                            }
                            catch (System.Threading.ThreadInterruptedException)
                            {

                            }
                        }
                    }
                }
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            //Scenario
            if (this.state.isSceneSetUp == false)
                return;
            this.root.Pause();
            if (this.state.workMode == CState.WorkMode.ReplayMode)
            {
                lock (this.RdXml.stopRead)
                {
                    if (RdXml.isPauseRead == false)
                    {
                        RdXml.isPauseRead = true;
                    }
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.root.StepForward();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (state.isSceneSetUp == false)
                return;
            root.Faster();
            double step2 = 0;
            try
            {
                int in1 = root.Step.IndexOf(':');
                string str = root.Step.Substring(in1 + 1).Trim();
                int in2 = str.IndexOf(' ');
                str = str.Substring(0, in2);
                step2 = double.Parse(str);
            }
            catch
            {
                return;
            }
            state.stepTime = step2;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (state.isSceneSetUp == false)
                return;
            root.Slower();
            double step2 = 0;
            try
            {
                int in1 = root.Step.IndexOf(':');
                string str = root.Step.Substring(in1 + 1).Trim();
                int in2 = str.IndexOf(' ');
                str = str.Substring(0, in2);
                step2 = double.Parse(str);
            }
            catch
            {
                return;
            }
            state.stepTime = step2;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (state.isSceneSetUp ==false)
            {
                return;
            }
            else if (state.workMode != CState.WorkMode.SimMode)
            {
                state.replayDataFaster *= 2;
                toolStripStatusLabel5.Text = "x" + state.replayDataFaster.ToString();
                lock (RdXml.stopRead)
                {
                    RdXml.fasterTimes = state.replayDataFaster;
                }
            }         
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if(state.isSceneSetUp==false)
            {
                return;
            }
            else if (state.workMode != CState.WorkMode.SimMode)
            {
                state.replayDataFaster /= 2;
                toolStripStatusLabel5.Text = "x" + state.replayDataFaster.ToString();
                lock (RdXml.stopRead)
                {
                    RdXml.fasterTimes = state.replayDataFaster;
                }
            }           
        }

        private void 指标显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chartView.ShowDialog();
        }

        private void 链路显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trafficView.ShowDialog();
        }
       

        private void 信关站覆盖显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.isSceneSetUp == false)
            {
                display("场景尚未建立");
                return;
            }   
            if (信关站覆盖显示ToolStripMenuItem.Checked)
            {
                foreach (var fac in Scenemana.stkcities)
                {
                    Scenemana.targetcircle(fac.name, fac.lat, fac.lon, 2800);
                }
                if (covsetup == false)
                {
                    covrate = covcal(2800);//2800的半径范围
                    covsetup = true;
                    toolStripStatusLabel1.Text = string.Format("覆盖率:{0}", covrate.ToString("0.00%"));
                    display(string.Format("覆盖率:{0}", covrate.ToString("0.00%")));
                }              
            }
            else
            {
                foreach (var fac in Scenemana.stkcities)
                {
                    Scenemana.delcircle(fac.name);
                }
            }
        }
        #endregion

        private void MFrm_Load(object sender, EventArgs e)
        {
            ind = new indicate();
            ind.TopMost = true;
        }
        /// <summary>
        /// 用来处理提示显示的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ind.wordsTosay = null;
            ind.Hide();
        }
        //int index=0;
        /// <summary>
        /// 用于检查当前时间并与链路通断时间进行对比的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// 用于刷新链路信息显示的计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
 
                //找到当前时刻对应的链路，并在treeview中显示该链路
                string linkinfo = showusers.GetLink(root.CurrentTime);
                //若信息不为空，且和上次不同
                if (linkinfo != null && !linkinfo.Equals(linkinfo_update))
                {
                    timer2.Stop();//暂停计时器
                    DialogResult MsgBoxResult;//设置对话框的返回值
                    MsgBoxResult = MessageBox.Show("链路信息已刷新，是否需要重新显示？",//对话框的显示内容
                    "刷新提示",//对话框的标题
                    MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮
                    MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号
                    MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                    if (MsgBoxResult == DialogResult.Yes)//如果对话框的返回值是YES（按"Y"按钮）
                    {
                        showusers.ClearTreeview();
                        showusers.ShowTreeview(linkinfo);
                        timer2.Start();//重启计时器
                    }
                    if (MsgBoxResult == DialogResult.No)//如果对话框的返回值是NO（按"N"按钮）
                    {                        
                        timer2.Start();//重启计时器
                    }
                    linkinfo_update = linkinfo;//保存当前时刻的链路信息  
                }                   
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void 仿真模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetCloseScene();
            //将当前的工作模式设置为仿真模式
            state.workMode = CState.WorkMode.SimMode;
        }

        private void 设置sensor可视性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            djg.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RD_Scenset rd = new RD_Scenset();
            rd.StartTime = "2017-2-07 16:00:00";
            rd.StepTime = 0.017;
            rd.StopTime = "2017-2-08 04:00:00";
            rd.ScenarioName = "FuXing";
            rd.SatelliteAltitude = 1039.5;
            rd.OrbitalInclination = 80;
            rd.RightAscensionOfAscendingNode = 0;
            rd.OrbitalNumber = 13;
            rd.InPlaneSatelliteNumber = 12;
            rd.PhaseParameters = 6;
            rd.raanspread = 200;

            DealPacket_Scenset(rd);

            RD_SatUser rdu = new RD_SatUser();
            rdu.SatUserName = "SatUser";
            rdu.SatUserAltitude = 500;
            rdu.SatUserOrbitalInclination = 82;
            rdu.SatUserRightAscensionOfAscendingNode = 15;
            rdu.SatUserOrbitalNumber = 15;
            rdu.SatUserInPlaneSatelliteNumber = 6;
            rdu.SatUserPhaseParameters = 2;
            rdu.SatUserRAANSpread = 180;

            DealPacket_SatUser(rdu);

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FormTest formTest = new FormTest(); 
            formTest.ShowDialog();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            
        }

        private void 链路信息显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linkinfo_update = null;
            //找到当前时刻对应的链路，并在treeview中显示该链路
            string linkinfo = showusers.GetLink(root.CurrentTime);
            if (linkinfo != null)
            {
                timer2.Enabled = true;//启动刷新treeview的定时器
                linkinfo_update = linkinfo;//记录当前显示的链路信息
                showusers.ShowTreeview(linkinfo);
                showusers.ShowDialog();//显示treeview窗体              
            }
            else MessageBox.Show("当前时刻无可显示链路，请稍后查看");
            //showusers.ShowTreeview("YH6->[UL0]FX0512[FL0]->XG5");
            //showusers.ShowDialog();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click_2(object sender, EventArgs e)
        {
            char zero ='0';
            int zero1 = int.Parse(zero.ToString());
            MessageBox.Show(zero1.ToString());
        }
    }
    /// <summary>
    /// 扩展方法，弧度转化
    /// </summary>
    static class Myextension
    {
        public static double ToRadius(this double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
    }
    public static class CmdHelper
    {
        private static string CmdPath = @"C:\Windows\System32\cmd.exe";
        /// <summary>
                /// 执行cmd命令
                /// 多命令请使用批处理命令连接符：
                /// <![CDATA[
                /// &:同时执行两个命令
                /// |:将上一个命令的输出,作为下一个命令的输入
                /// &&：当&&前的命令成功时,才执行&&后的命令
                /// ||：当||前的命令失败时,才执行||后的命令]]>
                /// 其他请百度
                /// </summary>
                /// <param name="cmd"></param>
                /// <param name="output"></param>
        public static void RunCmd(string cmd, out string output)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            using (Process p = new Process())
            {
                p.StartInfo.FileName = CmdPath;
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
                p.Start();//启动程序

                //向cmd窗口写入命令
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
            }
        }
    }


}


