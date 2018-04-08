using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
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
        RD_InterSatellitePath rd_update = new RD_InterSatellitePath();
        int beamdiameter = 0;
        public void DealPacket(string type, object pac)
        {
            this.RdXml.packetAllNum++;
            switch (type)
            {
                case "StkScenarioIC":
                    this.Invoke(new DealPacketDelegate(DealPacket_Scenset), pac);
                    break;
                case "ChainInfo":
                    this.Invoke(new DealPacketDelegate(DealPacket_ChainInfo), pac);
                    break;
                case "XGYHCoordinate":
                    this.Invoke(new DealPacketDelegate(DealPacket_XGY), pac);
                    break;
                case "StartOpnetIC":
                    this.Invoke(new DealPacketDelegate(DealPacket_opstart), pac);
                    break;
                case "S2GLinkAbility":
                    this.Invoke(new DealPacketDelegate(DealPacket_S2gLinkTraffic), pac);
                    break;
                case "NetTraffic":
                    this.Invoke(new DealPacketDelegate(DealPacket_NetTraffic), pac);
                    break;
                case "QosPerfomance":
                    this.Invoke(new DealPacketDelegate(DealPacket_AppTraQos), pac);
                    break;
                case "AccessAbility":
                    this.Invoke(new DealPacketDelegate(DealPacket_AccessAbility), pac);
                    break;
                case "UserAllNum":
                    this.Invoke(new DealPacketDelegate(DealPacket_UserAllNum), pac);
                    break;
                case "UserOnline":
                    this.Invoke(new DealPacketDelegate(DealPacket_UserOnline), pac);
                    break;
                case "LinkTraDesign":
                    this.Invoke(new DealPacketDelegate(DealPacket_LinkTraDesign), pac);
                    break;
                case "OpSimTime":
                    this.Invoke(new DealPacketDelegate(DealPacket_OpSimTime), pac);
                    break;
                case "Finish":
                    this.Invoke(new DealPacketDelegate(DealPacket_Finish), pac);
                    break;
                case "Mobility":
                    this.Invoke(new DealPacketDelegate(DealPacket_vehinfo), pac);
                    break;
                case "SatUserParameter":
                    this.Invoke(new DealPacketDelegate(DealPacket_SatUser), pac);
                    break;
                case "InterSatellitePath":
                    this.Invoke(new DealPacketDelegate(DealPacket_InterSatellitePath), pac);
                    break;
                case "BeamParameter":
                    this.Invoke(new DealPacketDelegate(DealPacket_BeamParameter), pac);
                    break;
                default:
                    break;
            }
        }
        public void DealPacket_Scenset(object pack)
        {
            RD_Scenset rd = (RD_Scenset)pack;
            this.Cursor = Cursors.WaitCursor;
            if (this.state.isSceneSetUp == true || this.root.CurrentScenario != null)
            {
                this.ResetCloseScene();
            }
            //建立场景    
            this.Cursor = Cursors.Default;
            this.scenenamenew = rd.ScenarioName;
            this.dStartTime= DateTime.ParseExact(rd.StartTime, "yyyy-M-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            this.startTime = timeproc(rd.StartTime);
            this.endTime = timeproc(rd.StopTime);
            this.stepTime = rd.StepTime;
            this.新场景ToolStripMenuItem_Click(null, null);
            Scenemana.newsat("FX",rd.SatelliteAltitude + 6371.0, rd.OrbitalInclination, rd.RightAscensionOfAscendingNode);
            Scenemana.newwalker("FX", rd.OrbitalNumber, rd.InPlaneSatelliteNumber, rd.PhaseParameters, rd.raanspread);
            Scenemana.delsat("FX");
        }
        //处理波束交互类的函数
        public void DealPacket_BeamParameter(object pack)
        {
            //提取波束参数
            RD_BeamParameter rd = (RD_BeamParameter)pack;
            beamdiameter = rd.BeamDiameter;

        }
        public void DealPacket_ChainInfo(object pack)
        {
            RD_ChainInfo rd = (RD_ChainInfo)pack;
            //建立链路
            chain_path temp = new chain_path(this);
            temp.sensor_name = rd.id;
            temp.path = rd.PathNodes;
            foreach (var o in rd.PathNodes)
                temp.path_Objs.Add(Scenemana.stkObjs.Find(c => c.ObjName == o));
            //beamdiameter = 103;
            Scenemana.setupchain(temp,beamdiameter);
            Scenemana.all_path.Add(temp);
        }
        public void DealPacket_InterSatellitePath(object pack)
        {
            RD_InterSatellitePath rd = (RD_InterSatellitePath)pack;
            //判断是否为之前已存在的相同链路，如不同，则清除之前的链路
            if (rd_update.ISLPath != null  && !rd.ISLPath.Equals(rd_update.ISLPath))
            {
                //清除链路
                chain_path temp;
                temp = Scenemana.all_path.Find(c => c.sensor_name == rd_update.ISLid.ToString());
                if (temp != null)
                {
                    Scenemana.RemoveAllSensorOnPath(temp);
                    Scenemana.all_path.Remove(temp);
                }
                //else MessageBox.Show("读取链路记录异常");
            }
            //判断是否需要建立新的链路（第一次建立或者链路改变）
            if (rd_update.ISLPath == null || !rd.ISLPath.Equals(rd_update.ISLPath) )
            {
                chain_path pathinfo = new chain_path(this);
                RD_ChainInfo temp1;
                int index = 0;
                string Nodes = rd.ISLPath.ToString();
                string[] nodelist = Nodes.Split(new string[] { "->" }, StringSplitOptions.None);
                foreach (var str in nodelist)
                {
                    pathinfo.path.Add(str);
                    //将系统物件表中的物体添加到链路的小表中
                    pathinfo.path_Objs.Add(Scenemana.stkObjs.Find(c => c.ObjName == str));
                }
                //pathinfo.sensor_name = pathinfo.path[0] + "-" + pathinfo.path[pathinfo.path.Count - 1];
                pathinfo.sensor_name = rd.ISLid.ToString();
                Scenemana.msglist.Clear();
                Scenemana.msglist.Add(new Msg { PathNodes = pathinfo.path, id = pathinfo.sensor_name });
                temp1 = Scenemana.MakePacket(Scenemana.msglist[index]);
                if (temp1 != null)
                {
                    //立即执行
                    DealPacket_ChainInfo(temp1);
                    index++;
                }
            }
            rd_update = rd;//记录最新的链路信息，为下次判断做准备
        }
        //处理信关站位置的包处理
        public void DealPacket_XGY(object pack)
        {
            RD_XGY rd = (RD_XGY)pack;
            if (rd.XGYHType == "xg")
                Scenemana.newcity(rd.XGYHName, rd.XGYHLatitude, rd.XGYHLongitude);
            else if (rd.XGYHType == "yh")
                Scenemana.newuser(rd.XGYHName, rd.XGYHLatitude, rd.XGYHLongitude);
        }
        public void DealPacket_opstart(object pack)
        {
            this.toolStripStatusLabel4.Text = "进行中";
            //this.simManager.view.state.isSceneSetUp = true;
            this.root.Rewind();//复位
            this.state.rewindStkTime = this.root.CurrentTime;
            try
            {
                this.root.PlayForward();
                //this.RdXml.sw.Reset();//注意新场景要Reset而不是Start
            }
            catch
            {
            }
        }
        public void DealPacket_OpSimTime(object pack)
        {
            if (this.时间同步ToolStripMenuItem.Checked)//如果菜单选中了时间同步模式
            {
                RD_SimTime rd = (RD_SimTime)pack;
                root.CurrentTime = this.state.rewindStkTime + rd.simeTime;//一定要加上前面复位时STK场景的时间点，因为rd.simTime是记录STK推荐的相对时间 
            }
        }
        public void DealPacket_S2gLinkTraffic(object pack)
        {
            if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                return;
            //this.RdXml.packetNum2[3]++;
            RD_S2GLinkAbility rd = (RD_S2GLinkAbility)pack;
            double dBytes;
            double UplinkUtilizationRadio;
            double DownlinkUtilizationRadio;
            int index = this.chartView.m_chartParam.mIx_S2GLink_Sat.FindIndex(str => str == rd.SatName);
            int bit2Ratio = 1000;   //bit单位转换的比率    //kb/s
            if (index == -1) //未添加过该颗星，新建chart
            {
                TreeNode node = new TreeNode(rd.SatName);
                int index2 = this.chartView.AddNodeOn2(node, "对地链路传输能力");
                if (index2 == -1)    //node添加失败
                {
                    return;
                }
                List<int> thisBeam = new List<int>();
                this.chartView.m_chartParam.mIx_S2GLink_Beam.Add(thisBeam);
                List<double> thisUp = new List<double>();
                this.chartView.m_chartParam.mDt_S2GLink_Up.Add(thisUp);
                List<double> thisDw = new List<double>();
                this.chartView.m_chartParam.mDt_S2GLink_Dw.Add(thisDw);

                Chart chart = ChartParam.CreateChart(this.chartView.m_chartTemplate, 4, 4);
                chart.Name = "chart" + (this.chartView.m_chartParam.chartCount++).ToString();//所有chart名称不一样
                chart.Series[0].Name = "上行速率(kb/s)";    //如果修改转换比率要修改上面的bit2Ratio
                chart.Series[1].Name = "下行速率(kb/s)";
                chart.Series[2].Name = "上行利用率(%)";
                chart.Series[3].Name = "下行利用率(%)";

                dBytes = rd.UplinkTrafficBps / bit2Ratio;
                thisUp.Add(dBytes);
                this.chartView.m_chartParam.mDt_S2GLink_Up_Sum.Add(dBytes);
                chart.Series[0].Points.AddXY(rd.simTime, dBytes);
                dBytes = rd.DownlinkTrafficBps / bit2Ratio;
                thisDw.Add(dBytes);
                this.chartView.m_chartParam.mDt_S2GLink_Dw_Sum.Add(dBytes);
                chart.Series[1].Points.AddXY(rd.simTime, dBytes);
                UplinkUtilizationRadio = rd.UplinkTrafficBps * 100 / (2000000.0 * 32 * 32);//占该颗星总的上行速率百分比：2Mbps(速率/信道)*32(信道/波束)*32(波束/星)
                chart.Series[2].Points.AddXY(rd.simTime, UplinkUtilizationRadio);
                DownlinkUtilizationRadio = rd.DownlinkTrafficBps * 100 / (10000000.0 * 32 * 32);
                chart.Series[3].Points.AddXY(rd.simTime, DownlinkUtilizationRadio * 100);

                this.chartView.Controls.Add(chart);
                this.chartView.m_chartParam.mCs_S2GLink.Add(chart);
                this.chartView.m_chartParam.mIx_S2GLink_Sat.Add(rd.SatName);
                thisBeam.Add(rd.SatbeamID);
                TreeNodeTag nodeTag = new TreeNodeTag(2, chart, index2);//index2为添加的节点在其父节点的子节点的索引
                node.Tag = nodeTag;
            }
            else
            {
                int index2 = this.chartView.m_chartParam.mIx_S2GLink_Beam[index].FindIndex(beam => beam == rd.SatbeamID);
                if (index2 == -1) //未添加过此波束，累加并添加到List
                {
                    this.chartView.m_chartParam.mIx_S2GLink_Beam[index].Add(rd.SatbeamID);
                    dBytes = rd.UplinkTrafficBps / bit2Ratio;      //kb/s
                    this.chartView.m_chartParam.mDt_S2GLink_Up[index].Add(dBytes);
                    this.chartView.m_chartParam.mDt_S2GLink_Up_Sum[index] += dBytes;    //累加
                    dBytes = rd.DownlinkTrafficBps / bit2Ratio;      //kb/s
                    this.chartView.m_chartParam.mDt_S2GLink_Dw[index].Add(dBytes);
                    this.chartView.m_chartParam.mDt_S2GLink_Dw_Sum[index] += dBytes;    //累加
                }
                else //已添加过此波束，减去再添加，同时更新原来的值
                {
                    this.chartView.m_chartParam.mDt_S2GLink_Up_Sum[index] -= this.chartView.m_chartParam.mDt_S2GLink_Up[index][index2];
                    this.chartView.m_chartParam.mDt_S2GLink_Dw_Sum[index] -= this.chartView.m_chartParam.mDt_S2GLink_Dw[index][index2];

                    dBytes = rd.UplinkTrafficBps / 1000;        //kb/s
                    this.chartView.m_chartParam.mDt_S2GLink_Up[index][index2] = dBytes; //更新原来的值
                    this.chartView.m_chartParam.mDt_S2GLink_Up_Sum[index] += dBytes;    //累加
                    dBytes = rd.DownlinkTrafficBps / 1000;      //kb/s
                    this.chartView.m_chartParam.mDt_S2GLink_Dw[index][index2] = dBytes; //更新原来的值
                    this.chartView.m_chartParam.mDt_S2GLink_Dw_Sum[index] += dBytes;    //累加
                }
                this.chartView.m_chartParam.mCs_S2GLink[index].Series[0].Points.AddXY(rd.simTime, this.chartView.m_chartParam.mDt_S2GLink_Up_Sum[index]);
                this.chartView.m_chartParam.mCs_S2GLink[index].Series[1].Points.AddXY(rd.simTime, this.chartView.m_chartParam.mDt_S2GLink_Dw_Sum[index]);
                UplinkUtilizationRadio = this.chartView.m_chartParam.mDt_S2GLink_Up_Sum[index] * bit2Ratio * 100 / (2000000.0 * 32 * 32);//占该颗星总的上行速率百分比：2Mbps(速率/信道)*32(信道/波束)*32(波束/星)
                DownlinkUtilizationRadio = this.chartView.m_chartParam.mDt_S2GLink_Dw_Sum[index] * bit2Ratio * 100 / (10000000.0 * 32 * 32);
                this.chartView.m_chartParam.mCs_S2GLink[index].Series[2].Points.AddXY(rd.simTime, UplinkUtilizationRadio);
                this.chartView.m_chartParam.mCs_S2GLink[index].Series[3].Points.AddXY(rd.simTime, DownlinkUtilizationRadio);
            }
        }
        public void DealPacket_AppTraQos(object pack)
        {
            if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                return;
            //this.RdXml.packetNum2[7]++; //for test
            RD_QosPerfomance rd = (RD_QosPerfomance)pack;

            Chart chart;
            int index = this.chartView.m_chartParam.mIx_TraQos.FindIndex(str => str == rd.TrafficName_SD);
            int bit2Ratio = 1000;   //bit单位转换的比率    //kb/s
            if (index == -1) //未添加过该条业务流，新建chart
            {
                TreeNode node = new TreeNode(rd.TrafficName_SD);
                int index2 = this.chartView.AddNodeOn2(node, "业务流Qos性能");
                if (index2 == -1)    //node添加失败
                    return;
                chart = ChartParam.CreateChart(this.chartView.m_chartTemplate, 4, 4);
                chart.Name = "chart" + (this.chartView.m_chartParam.chartCount++).ToString();//所有chart名称不一样
                chart.Series[0].Name = "发送量(kb/s)";    //如果修改转换比率要修改上面的bit2Ratio
                chart.Series[1].Name = "接收量(kb/s)";
                chart.Series[2].Name = "时延(ms)";//"时延(ms)";//20150928修改
                chart.Series[3].Name = "时延抖动(ms)";//"时延抖动(ms)";
                this.chartView.Controls.Add(chart);
                this.chartView.m_chartParam.mIx_TraQos.Add(rd.TrafficName_SD);
                this.chartView.m_chartParam.mCs_TraQos.Add(chart);
                TreeNodeTag nodeTag = new TreeNodeTag(2, chart, index2);//index2为添加的节点在其父节点的子节点的索引
                node.Tag = nodeTag;
            }
            else
                chart = this.chartView.m_chartParam.mCs_TraQos[index];
            chart.Series[0].Points.AddXY(rd.simTime, rd.AppTrafficSend / bit2Ratio);
            chart.Series[1].Points.AddXY(rd.simTime, rd.AppTrafficRcvd / bit2Ratio);
            if (rd.DelayTime != -1)
                chart.Series[2].Points.AddXY(rd.simTime, rd.DelayTime * 1000);  //单位ms 20150928修改
            if (rd.DelayVar != -1)
                chart.Series[3].Points.AddXY(rd.simTime, rd.DelayVar * 1000);   //单位ms 20150928修改
        }
        public void DealPacket_NetTraffic(object pack)
        {
            if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                return;
            //this.RdXml.packetNum2[5]++;
            this.chartView.m_chartParam.mC_NetTra.Series[0].Points.AddXY(((RD_NetTraffic)pack).simTime, ((RD_NetTraffic)pack).AppTrafficRcvd/1000);//目前是kbit/s
        }
        public void DealPacket_AccessAbility(object pack)
        {
            if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                return;
            //this.RdXml.packetNum2[10]++;
            RD_AccessAbility rd = (RD_AccessAbility)pack;
            this.chartView.m_listItem_jieru.SubItems[0].Text = (Math.Round(rd.AccessSuccessRate, 4) * 100).ToString();
            this.chartView.m_listItem_jieru.SubItems[1].Text = Math.Round(rd.AccessTimeAverage, 2).ToString() + "s";
            this.chartView.m_listItem_jieru.SubItems[2].Text = Math.Round(rd.ChannelApplyAverage, 2).ToString() + "s";
            this.chartView.m_listItem_jieru.SubItems[3].Text = (rd.AccessSignalingCost / 8).ToString() + "Byte";
        }
        public void DealPacket_UserAllNum(object pack)
        {
            if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                return;
            //this.RdXml.packetNum2[8]++;
            this.chartView.m_listItem_yonghu.SubItems[0].Text = ((RD_UserAllNum)pack).UserAllNum.ToString();
        }
        public void DealPacket_UserOnline(object pack)
        {
            if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                return;
            //this.RdXml.packetNum2[9]++;
            this.chartView.m_listItem_yonghu.SubItems[1].Text = ((RD_UserOnline)pack).UserOnlineNum.ToString();
        }
        public void DealPacket_LinkTraDesign(object pack)
        {
            if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                return;
            //this.RdXml.packetNum2[12]++;
            RD_LinkTraDesign rd = (RD_LinkTraDesign)pack;
            this.chartView.m_listItem_zhibiao.SubItems[0].Text = (rd.StogDownstrmDatarate / 1000000).ToString() + "Mbps";
            this.chartView.m_listItem_zhibiao.SubItems[1].Text = (rd.StogUpstrmDatarate / 1000000).ToString() + "Mbps";
            this.chartView.m_listItem_zhibiao.SubItems[2].Text = (rd.StosDatarate / 1000000).ToString() + "Mbps";
        }
        public void DealPacket_vehinfo(object pack)
        {
            if (this.state.isSceneSetUp == false)
                return;
            RD_Mobility rd = (RD_Mobility)pack;
            Scenemana.newveh(rd.MobileNodeName);//新建一个交通工具
            Scenemana.vehtime(rd.MobileNodeName, rd.MobileStartTime);
            Scenemana.vehway(rd.MobileNodeName, rd.StartLatitude, rd.StartLongitude, rd.MobileSpeed);
            //这里待添加终止时间
            Scenemana.vehway(rd.MobileNodeName,rd.EndLatitude,rd.EndLongitude, rd.MobileSpeed);
        }

        public void DealPacket_SatUser(object pack)
        {
            if (this.state.isSceneSetUp == false)
                return;
            RD_SatUser rd = (RD_SatUser)pack;
            Scenemana.newsat(rd.SatUserName,(rd.SatUserAltitude)+6371.0,rd.SatUserOrbitalInclination,rd.SatUserRightAscensionOfAscendingNode, @"D:\STK9\STKData\VO\Models\Space\a2100.mdl");
            Scenemana.newwalker_SatUser(rd.SatUserName, rd.SatUserOrbitalNumber, rd.SatUserInPlaneSatelliteNumber, rd.SatUserPhaseParameters, rd.SatUserRAANSpread);
            //Scenemana.hlSatUser(rd.SatUserName);
        }

        public void DealPacket_Finish(object pack)
        {
            if (state.workMode == CState.WorkMode.ReplayMode)
            {
                if (this.state.isSceneSetUp == false)//因为确定是主线程才会调用此函数所以不用锁
                    return;
                this.toolStripStatusLabel4.Text = "回放完成";
                this.root.Pause();
                WaitForm waitForm = new WaitForm();
                waitForm.Text = "回放结束，是否重启";
                waitForm.ShowDialog();
                if (waitForm.buttonClicked.Equals("buttonYes"))
                    ResetCloseScene();
            }
            else if (state.workMode == CState.WorkMode.SimMode)
            {
                root.Pause();               
                toolStripStatusLabel4.Text = "仿真完成";
                WaitForm waitForm = new WaitForm();
                waitForm.Text = "是否保存数据";
                waitForm.ShowDialog();
                if (waitForm.buttonClicked.Equals("buttonYes"))
                {
                    RdXml.InitXmlWriter();
                    RdXml.SaveXmlWriter();
                    MessageBox.Show("保存成功！");
                }
                waitForm.Dispose();
                RdXml.ResetXmlWriter();
                display("仿真结束");
            }
            //if (静态链路ToolStripMenuItem.Checked)
            //    ehelper.end();
        }
        #region 特殊函数
        private string timeproc(string sor)
        {
            string[] list;
            string[] date;
            list = sor.Split(' ');
            date = list[0].Split('-');
            switch (date[1])
            {
                case "1":
                    date[1] = "Jan";
                    break;
                case "2":
                    date[1] = "Feb";
                    break;
                case "3":
                    date[1] = "Mar";
                    break;
                case "4":
                    date[1] = "Apr";
                    break;
                case "5":
                    date[1] = "May";
                    break;
                case "6":
                    date[1] = "Jun";
                    break;
                case "7":
                    date[1] = "Jul";
                    break;
                case "8":
                    date[1] = "Aug";
                    break;
                case "9":
                    date[1] = "Sep";
                    break;
                case "10":
                    date[1] = "Oct";
                    break;
                case "11":
                    date[1] = "Nov";
                    break;
                case "12":
                    date[1] = "Dec";
                    break;
                default:
                    MessageBox.Show("月份转化失效");
                break;
            }
            string temp = string.Format("{0} {1} {2} {3}", date[2], date[1], date[0], list[1]);
            return temp;
        }
        #endregion
    }
}
public class Msg
{
    //public string StartOrEnd;
    public string id;
    public List<string> PathNodes;
    public double time;
}
