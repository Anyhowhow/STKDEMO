using System;
using System.Collections.Generic;
using RACoN;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text;
using System.Diagnostics;

namespace STK_demonstration
{ 
    public class CSTK_demonstration : RACoN.Federation.CGenericFederate
    {
        #region Declarations
        public STK_demonstration.Som.FederateSom Som;
        private CSimulationManager simManager;
        public int clear_flag;
        Process file32; //  用来和tftpd32相关联的引用
        #endregion //Declarations
        public CSTK_demonstration(CSimulationManager parent): base()
        {
            // Create and Attach Som to federate
            Som = new STK_demonstration.Som.FederateSom();
            this.SetSom(Som);
            simManager = parent;
            clear_flag = 0;
            // Create regions manually
        }
        public override void FdAmb_InteractionReceivedHandler(object sender, RACoN.RTILayer.CHlaInteractionEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_InteractionReceivedHandler(sender, data);
            if (this.simManager.view.state.workMode != CState.WorkMode.SimMode) //不是仿真模式，注意这里用"!="以便扩展工作模式
                return;

            if (data.InteractionClassHandle == this.Som.StartOpnetIC.ClassHandle)//处理开始仿真这个特殊的包(一次仿真只有一个)，目前是处理完成后立即return
            {                  
                    if (data.GetParameterValue<int>(this.Som.StartOpnetIC.qualnet_ready) == 1)
                    {
                        if (this.simManager.view.root.CurrentScenario == null)
                        {
                            MessageBox.Show("场景未建立好不能仿真");
                            return;
                        }
                        //AGI.STKUtil.AgExecCmdResult stkresult;
                        //stkresult = (AGI.STKUtil.AgExecCmdResult)this.simManager.view.root.ExecuteCommand("AllInstanceNames /");
                        //if (stkresult.Count == 0)
                        //{
                        //    MessageBox.Show("未正确建立STK场景");
                        //    return;
                        //}
                        simManager.view.RdXml.sw.Stop();
                        RePlayData rpd2 = new RePlayData("StartOpnetIC", simManager.view.RdXml.sw.ElapsedMilliseconds);
                        this.simManager.view.RdXml.sw.Start();
                        RD_Op rd2 = new RD_Op();
                        //处理方法
                        this.simManager.view.DealPacket("StartOpnetIC", rd2);
                        rpd2.packet = rd2;
                        this.simManager.view.RdXml.allPackets.Add(rpd2);
                        try
                        {
                            file32.CloseMainWindow();
                            file32.Close();
                            file32 = null;
                        }
                        catch { }
                    }
                    return;
            }
            if (this.simManager.view.state.isSceneSetUp == true)   //场景已建立起来才能处理的包
            {
                #region InteractionPackets

                //待修改

                if (data.InteractionClassHandle == this.Som.OpSimTimeIC.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();//暂停时钟运行以记录从开始仿真到当前时刻，windows系统过了多长时间，用于写到回放数据XML中的time属性
                    RePlayData rpd = new RePlayData("OpSimTime", this.simManager.view.RdXml.sw.ElapsedMilliseconds);//"OpSimTime"表明这种包的类型
                    this.simManager.view.RdXml.sw.Start();//恢复时钟运行
                    RD_SimTime rd = new RD_SimTime();//只要需要保存到xml，都这样处理，处理什么类型的交互类这里就新建什么类型的class，这个class将定义在ReplayData.cs中，其功能主要是保存交互类的各参数值到xml中                                                
                                                     //获取需要获取的交互类参数值，可以不读取不需要的值
                    rd.simeTime = data.GetParameterValue<double>(this.Som.OpSimTimeIC.SimTime);
                    this.simManager.view.DealPacket_OpSimTime(rd);//调用处理这种包的函数去完成刷新控件显示的功能，有时代码较短可以直接进行刷新但推荐统一用处理函数的方式
                    rpd.packet = rd;//所有的处理包都封装到一个外层类RePlayData中，方便统一写入xml
                    this.simManager.view.RdXml.allPackets.Add(rpd);//添加到集合中，在收到finish包时遍历集合并写入xml
                }
                

                //
                //处理链路信息的交互类
                else if (data.InteractionClassHandle == this.Som.InterSatellitePathIC.ClassHandle)
                {

                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("InterSatellitePath", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_InterSatellitePath rd = new RD_InterSatellitePath();
                    rd.ISLPath = data.GetParameterValue<String>(this.Som.InterSatellitePathIC.ISLPath);
                    rd.ISLid = data.GetParameterValue<Int16>(this.Som.InterSatellitePathIC.ISLid);
                    this.simManager.view.DealPacket_InterSatellitePath(rd);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //
                //
                //处理固定节点的交互类
                else if (data.InteractionClassHandle == this.Som.StkXGYHCoordinate.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("XGYHCoordinate", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_XGY rd = new RD_XGY();

                    rd.XGYHName = data.GetParameterValue<string>(this.Som.StkXGYHCoordinate.XGYHName);
                    rd.XGYHLatitude = data.GetParameterValue<string>(this.Som.StkXGYHCoordinate.XGYHLatitude);
                    rd.XGYHLongitude=data.GetParameterValue<string>(this.Som.StkXGYHCoordinate.XGYHLongitude);
                    rd.XGYHType = data.GetParameterValue<string>(this.Som.StkXGYHCoordinate.XGYHType);

                    this.simManager.view.DealPacket_XGY(rd);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //处理波束参数的交互类
                else if (data.InteractionClassHandle == this.Som.BeamParameters.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("BeamParameter", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_BeamParameter rd = new RD_BeamParameter();
                    string beamnumber = data.GetParameterValue<string>(this.Som.BeamParameters.BeamNumber);
                    //rd.BeamNumber = int.Parse(beamnumber.Replace("\0", ""));
                    string beamazimuth = data.GetParameterValue<string>(this.Som.BeamParameters.BeamAzimuth);
                    rd.BeamAzimuth = int.Parse(beamazimuth.Replace("\0", ""));
                    string beamelevation = data.GetParameterValue<string>(this.Som.BeamParameters.BeamElevation);
                    rd.BeamElevation = int.Parse(beamelevation.Replace("\0", ""));
                    string beamdiameter = data.GetParameterValue<string>(this.Som.BeamParameters.BeamDiameter);
                    rd.BeamDiameter = int.Parse(beamdiameter.Replace("\0",""));
                    rd.BeamType = data.GetParameterValue<string>(this.Som.BeamParameters.BeamType);
                    this.simManager.view.DealPacket_BeamParameter(rd);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //
                //处理satuser的交互类
                else if (data.InteractionClassHandle == this.Som.SatUserParameter.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("SatUserParameter", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_SatUser rd = new RD_SatUser();

                    rd.SatUserName = data.GetParameterValue<string>(this.Som.SatUserParameter.SatUserName);
                    rd.SatUserAltitude = data.GetParameterValue<double>(this.Som.SatUserParameter.SatUserAltitude);
                    rd.SatUserOrbitalInclination = data.GetParameterValue<double>(this.Som.SatUserParameter.SatUserOrbitalInclination);
                    rd.SatUserRightAscensionOfAscendingNode = data.GetParameterValue<double>(this.Som.SatUserParameter.SatUserRightAscensionOfAscendingNode);
                    rd.SatUserOrbitalNumber = 15;
                    rd.SatUserInPlaneSatelliteNumber = 6;
                    rd.SatUserPhaseParameters = 2;
                    rd.SatUserRAANSpread = 360;
                    //rd.SatUserOrbitalNumber = data.GetParameterValue<int>(this.Som.SatUserParameter.SatUserOrbitalNumber);
                    //rd.SatUserInPlaneSatelliteNumber = data.GetParameterValue<int>(this.Som.SatUserParameter.SatUserInPlaneSatelliteNumber);
                    //rd.SatUserPhaseParameters = data.GetParameterValue<double>(this.Som.SatUserParameter.SatUserPhaseParameters);
                    //rd.SatUserRAANSpread = data.GetParameterValue<double>(this.Som.SatUserParameter.SatUserRAANSpread);
                    this.simManager.view.DealPacket_SatUser(rd);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //各星对地链路传输能力
                else if (data.InteractionClassHandle == this.Som.OpS2gLinkTrafficAbility.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("S2GLinkAbility", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_S2GLinkAbility rd = new RD_S2GLinkAbility();

                    rd.simTime = data.GetParameterValue<double>(this.Som.OpS2gLinkTrafficAbility.SimTime);
                    rd.simTime = Math.Round(rd.simTime, 2);
                    rd.SatName = data.GetParameterValue<String>(this.Som.OpS2gLinkTrafficAbility.SatName);
                    rd.SatbeamID = data.GetParameterValue<int>(this.Som.OpS2gLinkTrafficAbility.SatbeamID);
                    rd.UplinkTrafficBps = data.GetParameterValue<double>(this.Som.OpS2gLinkTrafficAbility.UplinkTrafficBps);
                    //UplinkUtilizationRadio = data.GetParameterValue<double>(this.Som.OpS2gLinkTrafficAbility.UplinkUtilizationRadio));
                    rd.DownlinkTrafficBps = data.GetParameterValue<double>(this.Som.OpS2gLinkTrafficAbility.DownlinkTrafficBps);
                    //DownlinkUtilizationRadio = data.GetParameterValue<double>(this.Som.OpS2gLinkTrafficAbility.DownlinkUtilizationRadio));
                    //LinkPkLossRadio = data.GetParameterValue<double>(this.Som.OpS2gLinkTrafficAbility.LinkPkLossRadio));
                    this.simManager.view.DealPacket_S2gLinkTraffic(rd);//处理这种包，如果是第一次收到，要检查是否已添加顶层树节点20160225
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //星间链路传输能力
                //移动的通信节点
                else if (data.InteractionClassHandle==this.Som.mobilenodeparameter.ClassHandle)
                {
                    return;
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("Mobility",simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_Mobility rd = new RD_Mobility();

                    rd.MobileNodeName = data.GetParameterValue<string>(Som.mobilenodeparameter.MobileNodeName);
                    rd.StartLatitude = data.GetParameterValue<string>(Som.mobilenodeparameter.StartLatitude);
                    rd.StartLongitude = data.GetParameterValue<string>(Som.mobilenodeparameter.StartLongitude);
                    rd.MobileStartTime = data.GetParameterValue<string>(Som.mobilenodeparameter.MobileStartTime);
                    rd.MobileSpeed = data.GetParameterValue<string>(Som.mobilenodeparameter.MobileSpeed);
                    //对数据就进行第一次处理
                    simManager.view.DealPacket_vehinfo(rd);
                    rpd.packet = rd;
                    simManager.view.RdXml.allPackets.Add(rpd);
                }
                //网络吞吐量 字节单位
                else if (data.InteractionClassHandle == this.Som.OpAppTrafficInfoAll.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("NetTraffic", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_NetTraffic rd = new RD_NetTraffic();

                    rd.simTime = data.GetParameterValue<double>(this.Som.OpAppTrafficInfoAll.SimTime);
                    rd.AppTrafficRcvd = data.GetParameterValue<double>(this.Som.OpAppTrafficInfoAll.AppTrafficRcvd);
                    this.simManager.view.chartView.m_chartParam.mC_NetTra.Series[0].Points.AddXY(rd.simTime, rd.AppTrafficRcvd / 1000);  //Bps->kb/s

                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //各星资源占用率
                //指定业务流的QOS性能 字节单位
                else if (data.InteractionClassHandle == this.Som.OpAppTrafficInfoSingle.ClassHandle)
                {
                    String SubnetName_1 = " ";
                    String ScrName = " ";
                    String SubnetName_2 = " ";
                    String DestName = " ";

                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("QosPerfomance", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_QosPerfomance rd = new RD_QosPerfomance();

                    rd.simTime = data.GetParameterValue<double>(this.Som.OpAppTrafficInfoSingle.SimTime);
                    rd.simTime = Math.Round(rd.simTime, 2);
                    SubnetName_1 = data.GetParameterValue<String>(this.Som.OpAppTrafficInfoSingle.SubnetName_1);
                    ScrName = data.GetParameterValue<String>(this.Som.OpAppTrafficInfoSingle.ScrName);
                    SubnetName_2 = data.GetParameterValue<String>(this.Som.OpAppTrafficInfoSingle.SubnetName_2);
                    DestName = data.GetParameterValue<String>(this.Som.OpAppTrafficInfoSingle.DestName);
                    rd.AppTrafficSend = data.GetParameterValue<double>(this.Som.OpAppTrafficInfoSingle.AppTrafficSend);
                    rd.AppTrafficRcvd = data.GetParameterValue<double>(this.Som.OpAppTrafficInfoSingle.AppTrafficRcvd);
                    rd.DelayTime = data.GetParameterValue<double>(this.Som.OpAppTrafficInfoSingle.DelayTime);
                    rd.DelayVar = data.GetParameterValue<double>(this.Som.OpAppTrafficInfoSingle.DelayVar);

                    rd.TrafficName_SD = SubnetName_1 + "." + ScrName + "-" + SubnetName_2 + "." + DestName;
                    this.simManager.view.DealPacket_AppTraQos(rd);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //用户总数
                else if (data.InteractionClassHandle == this.Som.OpUserNumIC.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("UserAllNum", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_UserAllNum rd = new RD_UserAllNum();

                    rd.UserAllNum = data.GetParameterValue<int>(this.Som.OpUserNumIC.UserNumValue);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);

                    this.simManager.view.chartView.m_listItem_yonghu.SubItems[0].Text = rd.UserAllNum.ToString();

                }
                //在线用户数目
                else if (data.InteractionClassHandle == this.Som.OpUserOnlineIC.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("UserOnline", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_UserOnline rd = new RD_UserOnline();

                    int OnlineFlag = 0;
                    int UserNum = 0;
                    //UserId = data.GetParameterValue<int>(this.Som.OpUserOnlineIC.UserId));
                    OnlineFlag = data.GetParameterValue<int>(this.Som.OpUserOnlineIC.OnlineFlag);
                    rd.simTime = data.GetParameterValue<double>(this.Som.OpUserOnlineIC.SimTime);
                    rd.simTime = Math.Round(rd.simTime, 2);
                    if (OnlineFlag == 0)
                    {
                        UserNum = int.Parse(this.simManager.view.chartView.m_listItem_yonghu.SubItems[1].Text);
                        this.simManager.view.chartView.m_listItem_yonghu.SubItems[1].Text = (UserNum - 1).ToString();
                        rd.UserOnlineNum = UserNum - 1;
                    }
                    else if (1 == OnlineFlag)
                    {
                        UserNum = int.Parse(this.simManager.view.chartView.m_listItem_yonghu.SubItems[1].Text);
                        this.simManager.view.chartView.m_listItem_yonghu.SubItems[1].Text = (UserNum + 1).ToString();
                        rd.UserOnlineNum = UserNum + 1;
                    }
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                }
                //接入能力(用户的全局接入成功率)
                else if (data.InteractionClassHandle == this.Som.OpAccessAbility.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("AccessAbility", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_AccessAbility rd = new RD_AccessAbility();

                    rd.AccessSignalingCost = data.GetParameterValue<int>(this.Som.OpAccessAbility.AccessSignalingCost);
                    rd.AccessTimeAverage = data.GetParameterValue<double>(this.Som.OpAccessAbility.AccessTimeAverage);
                    rd.AccessSuccessRate = data.GetParameterValue<double>(this.Som.OpAccessAbility.AccessSuccessRate);
                    rd.ChannelApplyAverage = data.GetParameterValue<double>(this.Som.OpAccessAbility.ChannelApplyAverage);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);

                    this.simManager.view.chartView.m_listItem_jieru.SubItems[0].Text = (Math.Round(rd.AccessSuccessRate, 4) * 100).ToString();
                    this.simManager.view.chartView.m_listItem_jieru.SubItems[1].Text = Math.Round(rd.AccessTimeAverage, 2).ToString() + "s";
                    this.simManager.view.chartView.m_listItem_jieru.SubItems[2].Text = Math.Round(rd.ChannelApplyAverage, 2).ToString() + "s";
                    this.simManager.view.chartView.m_listItem_jieru.SubItems[3].Text = (rd.AccessSignalingCost / 8).ToString() + "Byte"; //Math.Round((AccessSignalingCost / 8.0), 1).ToString() + "Byte";

                }
                //链路传输能力设计指标
                else if (data.InteractionClassHandle == this.Som.OpLinkAbilityDesigned.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("LinkTraDesign", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Start();
                    RD_LinkTraDesign rd = new RD_LinkTraDesign();

                    rd.StogDownstrmDatarate = data.GetParameterValue<double>(this.Som.OpLinkAbilityDesigned.StogDownstrmDatarate);
                    rd.StogUpstrmDatarate = data.GetParameterValue<double>(this.Som.OpLinkAbilityDesigned.StogUpstrmDatarate);
                    rd.StosDatarate = data.GetParameterValue<double>(this.Som.OpLinkAbilityDesigned.StosDatarate);
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);

                    this.simManager.view.chartView.m_listItem_zhibiao.SubItems[0].Text = (rd.StogDownstrmDatarate / 1000000).ToString() + "Mbps";
                    this.simManager.view.chartView.m_listItem_zhibiao.SubItems[1].Text = (rd.StogUpstrmDatarate / 1000000).ToString() + "Mbps";
                    this.simManager.view.chartView.m_listItem_zhibiao.SubItems[2].Text = (rd.StosDatarate / 1000000).ToString() + "Mbps";

                }
                else if(data.InteractionClassHandle==this.Som.PlanComplete.ClassHandle)
                {
                    try
                    {
                        //启动接收文件的进程
                        //file32 = Process.Start("tftpd32.exe");
                        //simManager.view.display("场景已生成，文件接收已打开");

                        string dowloadpath = data.GetParameterValue<string>(this.Som.PlanComplete.mc);
                        dowloadpath = dowloadpath.Replace("\\", "/");

                        string targetDir = Directory.GetCurrentDirectory();

                        // write the py file
                        string lineOfdownload = "pyhelp.httpDownload(\'" + dowloadpath + "\', \'path.csv\')";
                        string[] lines = { "import pyhelp", lineOfdownload };
                        System.IO.File.WriteAllLines(targetDir + "\\downloadPath.py", lines);

                        //run the py file
                        Process proc = null;
                        proc = new Process();
                        proc.StartInfo.WorkingDirectory = targetDir;

                        proc.StartInfo.FileName = "downloadPath.py";
                        proc.StartInfo.CreateNoWindow = false;
                        proc.Start();
                        proc.WaitForExit();

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                    }
                }
                else if (data.InteractionClassHandle == this.Som.OpFinish.ClassHandle)
                {
                    this.simManager.view.RdXml.sw.Stop();
                    RePlayData rpd = new RePlayData("Finish", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                    this.simManager.view.RdXml.sw.Reset();//计时结束
                    RD_Finish rd = new RD_Finish();
                    rpd.packet = rd;
                    this.simManager.view.RdXml.allPackets.Add(rpd);
                    simManager.view.DealPacket_Finish(rd);
                }
                #endregion
            }
            if (data.InteractionClassHandle == this.Som.StkScenarioIC.ClassHandle) //根据控制台发来的场景名建立STK场景
            {
                   
                    ////////////////////////////
                    //gez2017/2/24新版方案
                    //////////////////////////// 
                    
                if(file32!=null)
                {
                    try
                    {
                        file32.Kill();
                        file32.Close();
                    }
                    catch
                    {}
                }
                this.simManager.view.RdXml.sw.Stop();
                RePlayData rpd = new RePlayData("StkScenarioIC", this.simManager.view.RdXml.sw.ElapsedMilliseconds);
                this.simManager.view.RdXml.sw.Start();
                RD_Scenset rd = new RD_Scenset();

                rd.ScenarioName = data.GetParameterValue<String>(this.Som.StkScenarioIC.ScenarioName);
                rd.StartTime = data.GetParameterValue<String>(this.Som.StkScenarioIC.StartTime);
                rd.StopTime = data.GetParameterValue<String>(this.Som.StkScenarioIC.StopTime);
                rd.StepTime = data.GetParameterValue<double>(this.Som.StkScenarioIC.StepTime);
                    
                rd.InPlaneSatelliteNumber= data.GetParameterValue<int>(this.Som.StkScenarioIC.InPlaneSatelliteNumber);
                rd.OrbitalInclination = data.GetParameterValue<double>(this.Som.StkScenarioIC.OrbitalInclination);
                rd.OrbitalNumber= data.GetParameterValue<int>(this.Som.StkScenarioIC.OrbitalNumber);
                rd.PhaseParameters= data.GetParameterValue<double>(this.Som.StkScenarioIC.PhaseParameters);
                rd.RightAscensionOfAscendingNode= data.GetParameterValue<double>(this.Som.StkScenarioIC.RightAscensionOfAscendingNode);
                rd.SatelliteAltitude= data.GetParameterValue<double>(this.Som.StkScenarioIC.SatelliteAltitude);
                rd.raanspread = data.GetParameterValue<double>(this.Som.StkScenarioIC.RAANSpread);

                this.simManager.view.DealPacket("StkScenarioIC", rd);
                rpd.packet = rd;
                this.simManager.view.RdXml.allPackets.Add(rpd);
              
            }
        }
    }
}