using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace STK_demonstration
{
    public delegate void DealPacketDelegate(string type, object pack);
    public class RePlayData
    {
        public String type = null;
        public long time;
        public object packet;
        public RePlayData(string str, long tm)
        {
            type = str;
            time = tm;
        }
    }   
    public class RD_XmlReadWrite    //XML保存仿真数据用于回放
    {
        public XmlWriter writer = null;//Xml书写器，需要在外部初始化以及关闭
        //public XmlReader reader = null;
        public string replayXmlName = "DefaultScenario";
        private string m_path;
        public List<RePlayData> allPackets;//保存从RTI接收的全部仿真数据包
        public System.Diagnostics.Stopwatch sw;
        public bool isWriterSaved = true;
        public bool isReaderClosed = true;//没有close可能是子线程正在读xml回放数据
        public Thread xmlReaderThread = null;//用于强制Abort
        // for test
        public int packetAllNum = 0;
        public object stopRead;
        public bool isStopRead = false;
        public bool isPauseRead = false;
        public int[] packetNum = new int[30];

        public RD_XmlReadWrite()
        {
            m_path = System.IO.Directory.GetCurrentDirectory();
            if (System.IO.Directory.Exists(m_path + "\\STK场景xml") == false)
                System.IO.Directory.CreateDirectory(m_path);
            if (System.IO.Directory.Exists(m_path + "\\回放数据xml") == false)
                System.IO.Directory.CreateDirectory(m_path);
            sw = new System.Diagnostics.Stopwatch();
            //for test
            for (int i = 0; i < packetNum.Length; i++)
            {
                packetNum[i] = 0;
            }
            allPackets = new List<RePlayData>();
            packetAllNum = 0;
            stopRead = new object();
            fasterTimes = 1;
            fastertimes = fasterTimes;
        }
        public void InitXmlWriter(String root = "SimPackets")
        {
            if (writer != null)
                writer.Close();
            XmlWriterSettings mySettings = new XmlWriterSettings();
            mySettings.Indent = true;
            mySettings.NewLineChars = Environment.NewLine;
            if (System.IO.Directory.Exists(m_path) == false)
                System.IO.Directory.CreateDirectory(m_path);
            writer = XmlWriter.Create(m_path + "\\回放数据xml\\" + replayXmlName + ".xml", mySettings);
            writer.WriteStartDocument();
            writer.WriteStartElement(root);

            isWriterSaved = false;
        }
        public void SaveXmlWriter()
        {
            if (writer == null || isWriterSaved == true)
                return;
            isWriterSaved = true;
            for (int i = 0; i < allPackets.Count; i++)
            {
                switch (allPackets[i].type)
                {
                    case "RouteTraffic":
                        this.packetNum[2]++;
                        ((RD_RouteTraffic)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "XGYHCoordinate":
                        this.packetNum[17]++;
                        ((RD_XGY)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "S2GLinkAbility":
                        this.packetNum[3]++;
                        ((RD_S2GLinkAbility)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "S2SLinkAbility":
                        this.packetNum[4]++;
                        ((RD_S2SLinkAbility)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "NetTraffic":
                        this.packetNum[5]++;
                        ((RD_NetTraffic)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "ResOccupancy":
                        this.packetNum[6]++;
                        ((RD_ResOccupancy)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "QosPerfomance":
                        this.packetNum[7]++;
                        ((RD_QosPerfomance)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "AccessAbility":
                        this.packetNum[10]++;
                        ((RD_AccessAbility)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;                             
                    case "UserAllNum":
                        this.packetNum[8]++;
                        ((RD_UserAllNum)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "UserOnline":
                        this.packetNum[9]++;
                        ((RD_UserOnline)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "PKLossRate":
                        this.packetNum[11]++;
                        ((RD_PKLossRate)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "LinkTraDesign":
                        this.packetNum[12]++;
                        ((RD_LinkTraDesign)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "OpSimTime":
                        this.packetNum[13]++;
                        ((RD_SimTime)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "StkScenarioIC":
                        this.packetNum[14]++;
                        ((RD_Scenset)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "StartOpnetIC":
                        this.packetNum[16]++;
                        ((RD_Op)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "Finish":
                        this.packetNum[15]++;
                        ((RD_Finish)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "ChainInfo":
                        this.packetNum[17]++;
                        ((RD_ChainInfo)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "SatUserParameter":
                        this.packetNum[18]++;
                        ((RD_SatUser)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    case "InterSatellitePath":
                        this.packetNum[19]++;
                        ((RD_InterSatellitePath)(allPackets[i].packet)).SaveXml(writer, allPackets[i].time);
                        break;
                    default:
                        continue;
                }
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }
        public void ResetXmlWriter()
        {
            if (writer != null)
            {
                writer.Close();
                writer = null;
            }
            allPackets.Clear();
            sw.Reset();
            isWriterSaved = true;
            //for test
            for (int i = 0; i < packetNum.Length; i++)
                packetNum[i] = 0;
            packetAllNum = 0;
        }
        public DealPacketDelegate DealPacketCallback = null;
        private bool isStop;

        public double fasterTimes=1;//回放时加快进度的倍数：读包加快和STK演示加快
        private double fastertimes;//内部使用
        public void ReadXml()
        {
            XmlReaderSettings mySettings = new XmlReaderSettings();
            mySettings.IgnoreComments = true;
            mySettings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(m_path + "\\回放数据xml\\" + replayXmlName + ".xml", mySettings))
            {
                lock (this.stopRead)
                {
                    isStopRead = false;
                    isPauseRead = false;
                }
                isStop = false;
                int preTime = 0;
                int nextTime = 0;
                int spanTime = 0;
                object pack = null;
                string type = null;
                while (reader.Read())
                {
                    lock (this.stopRead)
                    {
                        if (isStopRead == true)//在主线程中修改使子线程自然退出
                        {
                            isStopRead = false;
                            break;
                        }
                        else if (isPauseRead == true)
                        {
                            isPauseRead = false;
                            isStop = true;
                        }
                        fastertimes = fasterTimes;//主线程中若修改fasterTimes将影响读包速度，不过太快时误差增大因此要限速
                    }
                    if (isStop == true)
                    {
                        isStop = false;
                        try
                        {
                            Thread.Sleep(-1);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    if (reader.Name.Equals("Packet"))
                    {
                        type = reader.GetAttribute("Type");
                        nextTime = Convert.ToInt32(reader.GetAttribute("Time"));
                        spanTime = nextTime - preTime;
                        if (spanTime <= 0)
                            spanTime = 2;
                        spanTime = (int)(spanTime / fastertimes);//加快读取进度
                        try
                        {
                            Thread.Sleep(spanTime);
                        }
                        catch (Exception)//(System.Threading.ThreadInterruptedException e)
                        {

                        }
                        preTime = nextTime;
                        switch (type)
                        {
                            case "StkScenarioIC":
                                RD_Scenset pasen = new RD_Scenset();
                                pasen.ScenarioName = reader.GetAttribute("ScenarioName");
                                pasen.StartTime = reader.GetAttribute("StartTime");
                                pasen.StopTime = reader.GetAttribute("StopTime");
                                pasen.StepTime = Convert.ToDouble(reader.GetAttribute("StepTime"));
                                pasen.InPlaneSatelliteNumber = Convert.ToInt32(reader.GetAttribute("InPlaneSatelliteNumber"));
                                pasen.OrbitalInclination = Convert.ToDouble(reader.GetAttribute("OrbitalInclination"));
                                pasen.RightAscensionOfAscendingNode = Convert.ToDouble(reader.GetAttribute("RightAscensionOfAscendingNode"));
                                pasen.SatelliteAltitude = Convert.ToDouble(reader.GetAttribute("SatelliteAltitude"));
                                pasen.OrbitalNumber = Convert.ToInt32(reader.GetAttribute("OrbitalNumber"));
                                pasen.PhaseParameters = Convert.ToDouble(reader.GetAttribute("PhaseParameters"));
                                pasen.raanspread = Convert.ToDouble(reader.GetAttribute("raanspread"));
                                pack = pasen;
                                break;
                            case "ChainInfo":
                                RD_ChainInfo pacinfo = new RD_ChainInfo();
                                pacinfo.id = reader.GetAttribute("id");
                                pacinfo.StartOrEnd = reader.GetAttribute("StartOrEnd");
                                pacinfo.usetime = Convert.ToDouble(reader.GetAttribute("usetime"));
                                string[] temp;
                                temp=reader.GetAttribute("PathNodes").Split('-');
                                foreach(var o in temp)
                                {
                                    pacinfo.PathNodes.Add(o);
                                }
                                pack = pacinfo;
                                break;
                            case "StartOpnetIC":
                                RD_Op pacop = new RD_Op();
                                pack = pacop;
                                break;
                            case "XGYHCoordinate":
                                RD_XGY pacxy = new RD_XGY();
                                pacxy.XGYHLongitude = reader.GetAttribute("XGYHLongitude");
                                pacxy.XGYHLatitude = reader.GetAttribute("XGYHLatitude");
                                pacxy.XGYHName = reader.GetAttribute("XGYHName");
                                pacxy.XGYHType = reader.GetAttribute("XGYHType");
                                pack = pacxy;
                                break;
                            case "OpSimTime":
                                RD_SimTime pac = new RD_SimTime();
                                pac.simeTime = Convert.ToInt64(reader.GetAttribute("SimTime"));
                                pack = pac;
                                break;
                            case "RouteTraffic":
                                RD_RouteTraffic pacRouteTraffic = new RD_RouteTraffic();
                                pacRouteTraffic.SatRouteCostSent = Convert.ToDouble(reader.GetAttribute("SatRouteCostSent"));
                                pacRouteTraffic.SatRouteCostRcvd = Convert.ToDouble(reader.GetAttribute("SatRouteCostRcvd"));
                                pacRouteTraffic.simTime = Convert.ToDouble(reader.GetAttribute("SimTime"));
                                pack = pacRouteTraffic;
                                break;
                            case "S2GLinkAbility":
                                RD_S2GLinkAbility pacS2GLinkAbility = new RD_S2GLinkAbility();
                                pacS2GLinkAbility.SatName = reader.GetAttribute("SatName");
                                pacS2GLinkAbility.SatbeamID = Convert.ToInt32(reader.GetAttribute("SatbeamID"));
                                pacS2GLinkAbility.UplinkTrafficBps = Convert.ToDouble(reader.GetAttribute("UpTraBps"));
                                pacS2GLinkAbility.DownlinkTrafficBps = Convert.ToDouble(reader.GetAttribute("DwTraBps"));
                                pacS2GLinkAbility.simTime = Convert.ToDouble(reader.GetAttribute("SimTime"));
                                pack = pacS2GLinkAbility;
                                break;
                            case "SatUserParameter":
                                RD_SatUser pacSatUser = new RD_SatUser();
                                pacSatUser.SatUserName = reader.GetAttribute("SatUserName");
                                pacSatUser.SatUserAltitude = Convert.ToDouble(reader.GetAttribute("SatUserAltitude"));
                                pacSatUser.SatUserOrbitalInclination = Convert.ToDouble(reader.GetAttribute("SatUserOrbitalInclination"));
                                pacSatUser.SatUserRightAscensionOfAscendingNode = Convert.ToDouble(reader.GetAttribute("SatUserRightAscensionOfAscendingNode"));
                                pack = pacSatUser;
                                break;
                            case "S2SLinkAbility":
                                RD_S2SLinkAbility pacS2SLinkAbility = new RD_S2SLinkAbility();
                                pacS2SLinkAbility.SatName1_2 = reader.GetAttribute("SatName1_2");
                                pacS2SLinkAbility.UplinkTrafficBps = Convert.ToDouble(reader.GetAttribute("UpTraBps"));
                                pacS2SLinkAbility.DownlinkTrafficBps = Convert.ToDouble(reader.GetAttribute("DwTraBps"));
                                pacS2SLinkAbility.UplinkUtilizationRadio = Convert.ToDouble(reader.GetAttribute("UpUseRadio"));
                                pacS2SLinkAbility.DownlinkUtilizationRadio = Convert.ToDouble(reader.GetAttribute("DwUseRadio"));
                                pacS2SLinkAbility.simTime = Convert.ToDouble(reader.GetAttribute("SimTime"));
                                pack = pacS2SLinkAbility;
                                break;
                            case "NetTraffic":
                                RD_NetTraffic pacNetTraffic = new RD_NetTraffic();
                                pacNetTraffic.AppTrafficRcvd = Convert.ToDouble(reader.GetAttribute("AppTrafficRcvd"));
                                pacNetTraffic.simTime = Convert.ToDouble(reader.GetAttribute("SimTime"));
                                pack = pacNetTraffic;
                                break;
                            case "ResOccupancy":
                                RD_ResOccupancy pacResOccupancy = new RD_ResOccupancy();
                                pacResOccupancy.SatName1_5 = reader.GetAttribute("SatName1_5");
                                pacResOccupancy.ResourceOccupancyRate1_5 = reader.GetAttribute("ResourceOccupancyRate1_5");
                                pacResOccupancy.Type1 = reader.GetAttribute("Type1");
                                pacResOccupancy.simTime = Convert.ToDouble(reader.GetAttribute("SimTime"));
                                pack = pacResOccupancy;
                                break;
                            case "QosPerfomance":
                                RD_QosPerfomance pacQosPerfomance = new RD_QosPerfomance();
                                pacQosPerfomance.TrafficName_SD = reader.GetAttribute("TrafficName_SD");
                                pacQosPerfomance.AppTrafficSend = Convert.ToDouble(reader.GetAttribute("AppTrafficSend"));
                                pacQosPerfomance.AppTrafficRcvd = Convert.ToDouble(reader.GetAttribute("AppTrafficRcvd"));
                                pacQosPerfomance.DelayTime = Convert.ToDouble(reader.GetAttribute("DelayTime"));
                                pacQosPerfomance.DelayVar = Convert.ToDouble(reader.GetAttribute("DelayVar"));
                                pacQosPerfomance.simTime = Convert.ToDouble(reader.GetAttribute("SimTime"));
                                pack = pacQosPerfomance;
                                break;
                            case "AccessAbility":
                                RD_AccessAbility pacAccessAbility = new RD_AccessAbility();
                                pacAccessAbility.AccessSignalingCost = Convert.ToInt32(reader.GetAttribute("SignalingCost"));
                                pacAccessAbility.AccessTimeAverage = Convert.ToDouble(reader.GetAttribute("TimeAverage"));
                                pacAccessAbility.AccessSuccessRate = Convert.ToDouble(reader.GetAttribute("SuccessRate"));
                                pacAccessAbility.ChannelApplyAverage = Convert.ToDouble(reader.GetAttribute("ChannelApply"));
                                pack = pacAccessAbility;
                                break;
                            case "UserAllNum":
                                RD_UserAllNum pacUserAllNum = new RD_UserAllNum();
                                pacUserAllNum.UserAllNum = Convert.ToInt32(reader.GetAttribute("UserAllNum"));
                                pack = pacUserAllNum;
                                break;
                            case "UserOnline":
                                RD_UserOnline pacUserOnline = new RD_UserOnline();
                                pacUserOnline.UserOnlineNum = Convert.ToInt32(reader.GetAttribute("UserOnlineNum"));
                                pacUserOnline.simTime = Convert.ToDouble(reader.GetAttribute("SimTime"));
                                pack = pacUserOnline;
                                break;
                            case "PKLossRate":
                                RD_PKLossRate pacPKLossRate = new RD_PKLossRate();
                                pacPKLossRate.PkLossRatioValue = Convert.ToDouble(reader.GetAttribute("PkLossRatio"));
                                pack = pacPKLossRate;
                                break;
                            case "Mobility":
                                RD_Mobility pacMobility = new RD_Mobility();
                                pacMobility.MobileNodeName = reader.GetAttribute("MobileNodeName");
                                pacMobility.MobileStartTime = reader.GetAttribute("MobileStartTime");
                                pacMobility.EndLatitude = reader.GetAttribute("EndLatitude");
                                pacMobility.EndLongitude = reader.GetAttribute("EndLongitude");

                                pacMobility.StartLatitude = reader.GetAttribute("StartLatitude");
                                pacMobility.StartLongitude =reader.GetAttribute("StartLongitude");
                                pacMobility.MobileSpeed = reader.GetAttribute("MobileSpeed");
                                pack = pacMobility;
                                break;
                            case "LinkTraDesign":
                                RD_LinkTraDesign pacLinkTraDesign = new RD_LinkTraDesign();
                                pacLinkTraDesign.StogDownstrmDatarate = Convert.ToDouble(reader.GetAttribute("StogDwDataRate"));
                                pacLinkTraDesign.StogUpstrmDatarate = Convert.ToDouble(reader.GetAttribute("StogUpDataRate"));
                                pacLinkTraDesign.StosDatarate = Convert.ToDouble(reader.GetAttribute("StosDataRate"));
                                pack = pacLinkTraDesign;
                                break;
                            case "Finish":
                                RD_Finish pacFinish = new RD_Finish();
                                pack = pacFinish;
                                break;
                            case "InterSatellitePath":
                                RD_InterSatellitePath pacInterSatellitePath = new RD_InterSatellitePath();
                                pacInterSatellitePath.ISLPath = reader.GetAttribute("ISLPath");
                                pacInterSatellitePath.ISLid = Convert.ToInt16(reader.GetAttribute("ISLid"));
                                pack = pacInterSatellitePath;
                                break;
                            default:
                                continue;
                        }
                        if (DealPacketCallback != null)
                        {
                            try
                            {
                                DealPacketCallback(type, pack);
                            }
                            catch (Exception e) //(System.Threading.ThreadInterruptedException e)
                            {
                                //这里还是不要提示比较好了
                                //MessageBox.Show(e.ToString(),"唤起函数出错");
                            }

                        }
                    }
                }
                lock (this.stopRead)
                {
                    isStopRead = false;
                }
            }
        }
    }
    #region RD_Packet   
    public class RD_ChainInfo
    {
        public RD_ChainInfo()
        {
            PathNodes = new List<string>();
        }
        public string id;
        public double usetime;
        public List<string> PathNodes;
        public string StartOrEnd;
        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "ChainInfo");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("id", id);
            writer.WriteAttributeString("StartOrEnd", StartOrEnd);
            StringBuilder temp=new StringBuilder();
            for(int i=0;i<PathNodes.Count-1;i++)
            {
                temp.Append(PathNodes[i]).Append('-');
            }
            temp.Append(PathNodes[PathNodes.Count - 1]);
            writer.WriteAttributeString("PathNodes",temp.ToString());
            writer.WriteEndElement();
        }
    }
    /// <summary>
    /// OPNET推进时间
    /// </summary>
    public class RD_Scenset
    {
        //0519新添加了raanspread
        public string ScenarioName;
        public string StartTime;
        public string StopTime;
        public double StepTime;

        public double SatelliteAltitude;
        public double OrbitalInclination;
        public double RightAscensionOfAscendingNode;
        public int OrbitalNumber;
        public int InPlaneSatelliteNumber;
        public double PhaseParameters;
        //在赤经面上扩展多大的距离
        public double raanspread;
        public void SaveXml(XmlWriter writer,long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "StkScenarioIC");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("ScenarioName", ScenarioName);
            writer.WriteAttributeString("StartTime", StartTime);
            writer.WriteAttributeString("StopTime", StopTime);
            writer.WriteAttributeString("StepTime", StepTime.ToString());

            writer.WriteAttributeString("SatelliteAltitude", SatelliteAltitude.ToString());
            writer.WriteAttributeString("OrbitalInclination", OrbitalInclination.ToString());
            writer.WriteAttributeString("RightAscensionOfAscendingNode", RightAscensionOfAscendingNode.ToString());
            writer.WriteAttributeString("OrbitalNumber", OrbitalNumber.ToString());
            writer.WriteAttributeString("InPlaneSatelliteNumber", InPlaneSatelliteNumber.ToString());
            writer.WriteAttributeString("PhaseParameters", PhaseParameters.ToString());
            writer.WriteAttributeString("raanspread", raanspread.ToString());
            writer.WriteEndElement();
        }
    }
    public class RD_XGY
    {
        public string XGYHName;
        public string XGYHLongitude;
        public string XGYHLatitude;
        public string XGYHType;
        public void SaveXml(XmlWriter writer,long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "XGYHCoordinate");
            writer.WriteAttributeString("XGYHName", XGYHName);
            writer.WriteAttributeString("XGYHLongitude", XGYHLongitude.ToString());
            writer.WriteAttributeString("XGYHLatitude", XGYHLatitude.ToString());
            writer.WriteAttributeString("XGYHType", XGYHType.ToString());
            writer.WriteEndElement();
        }
    }
    public class RD_SatUser
    {
        public string SatUserName;
        public double SatUserAltitude;
        public double SatUserOrbitalInclination;
        public double SatUserRightAscensionOfAscendingNode;
        
        public int    SatUserOrbitalNumber;
        public int    SatUserInPlaneSatelliteNumber;
        public double SatUserPhaseParameters;
        public double SatUserRAANSpread;
        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "SatUserParameter");
            writer.WriteAttributeString("SatUserName", SatUserName);
            writer.WriteAttributeString("SatUserAltitude", SatUserAltitude.ToString());
            writer.WriteAttributeString("SatUserOrbitalInclination", SatUserOrbitalInclination.ToString());
            writer.WriteAttributeString("SatUserRightAscensionOfAscendingNode", SatUserRightAscensionOfAscendingNode.ToString());
            writer.WriteAttributeString("SatUserOrbitalNumber", SatUserOrbitalNumber.ToString());
            writer.WriteAttributeString("SatUserInPlaneSatelliteNumber", SatUserInPlaneSatelliteNumber.ToString());
            writer.WriteAttributeString("SatUserPhaseParameters", SatUserPhaseParameters.ToString());
            writer.WriteAttributeString("SatUserRAANSpread", SatUserRAANSpread.ToString());
            writer.WriteEndElement();
        }
    }
    public class RD_BeamParameter
    {
        public int BeamNumber = 0;
        public int BeamAzimuth = 0;
        public int BeamElevation = 0;
        public int BeamDiameter = 0;
        public string BeamType = null;
        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "BeamParameters");
            writer.WriteAttributeString("beamnumber", BeamNumber.ToString());
            writer.WriteAttributeString("beamazimuth", BeamAzimuth.ToString());
            writer.WriteAttributeString("beamelevation", BeamElevation.ToString());
            writer.WriteAttributeString("beamdiameter", BeamDiameter.ToString());
            writer.WriteAttributeString("beamtype", BeamType);
            writer.WriteEndElement();
        }
    }
    public class RD_InterSatellitePath
    {
        public string ISLPath = null;
        public int ISLid = 0;
        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "InterSatellitePath");
            writer.WriteAttributeString("ISLPath", ISLPath);
            writer.WriteAttributeString("ISLid", ISLid.ToString());
            writer.WriteEndElement();
        }
    }
    public class RD_Op
    {
        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "StartOpnetIC");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteEndElement();
        }

    }
    public class RD_SimTime
    {
        public double simeTime = 0; //当前OPNET推进到多少时间
        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "OpSimTime");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simeTime.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_RouteTraffic //星上路由器开销
    {
        //public String classType = "SatRouterCost";//类的代号
        public double SatRouteCostSent;
        public double SatRouteCostRcvd;
        public double simTime = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "RouteTraffic");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simTime.ToString());
            writer.WriteAttributeString("SatRouteCostSent", SatRouteCostSent.ToString());
            writer.WriteAttributeString("SatRouteCostRcvd", SatRouteCostRcvd.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_S2GLinkAbility    //各星对地链路传输能力
    {
        //public String classType = "S2GLinkAbility";//类的代号
        public String SatName = null;
        public int SatbeamID = -1;
        public double UplinkTrafficBps = 0;
        public double DownlinkTrafficBps = 0;
        public double simTime = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "S2GLinkAbility");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simTime.ToString());
            writer.WriteAttributeString("SatName", SatName);
            writer.WriteAttributeString("SatbeamID", SatbeamID.ToString());
            writer.WriteAttributeString("UpTraBps", UplinkTrafficBps.ToString());
            writer.WriteAttributeString("DwTraBps", DownlinkTrafficBps.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_S2SLinkAbility    //星间链路传输能力
    {
        //public String classType = "S2SLinkAbility";//类的代号
        public String SatName1_2 = null;
        public double UplinkTrafficBps = 0;
        public double UplinkUtilizationRadio = 0;
        public double DownlinkTrafficBps = 0;
        public double DownlinkUtilizationRadio = 0;
        public double simTime = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "S2SLinkAbility");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simTime.ToString());
            writer.WriteAttributeString("SatName1_2", SatName1_2);
            writer.WriteAttributeString("UpTraBps", UplinkTrafficBps.ToString());
            writer.WriteAttributeString("UpUseRadio", UplinkUtilizationRadio.ToString());
            writer.WriteAttributeString("DwTraBps", DownlinkTrafficBps.ToString());
            writer.WriteAttributeString("DwUseRadio", DownlinkUtilizationRadio.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_NetTraffic    //网络吞吐量
    {
        public double AppTrafficRcvd = 0;
        public double  simTime = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "NetTraffic");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simTime.ToString());
            writer.WriteAttributeString("AppTrafficRcvd", AppTrafficRcvd.ToString());
            writer.WriteEndElement();
        }
    }
    public class RD_ResOccupancy //各星资源占用率
    {
        public String Type1 = null;
        public String SatName1_5 = null;
        public String ResourceOccupancyRate1_5 = null;
        public double simTime = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "ResOccupancy");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simTime.ToString());
            writer.WriteAttributeString("Type1", Type1);
            writer.WriteAttributeString("SatName1_5", SatName1_5);
            writer.WriteAttributeString("ResourceOccupancyRate1_5", ResourceOccupancyRate1_5);

            writer.WriteEndElement();
        }
    }
    public class RD_QosPerfomance     //QOS性能:各条业务流的发送量、接收量、时延、时延抖动
    {
        public String TrafficName_SD = null;
        public double AppTrafficSend = 0;
        public double AppTrafficRcvd = 0;
        public double DelayTime = 0;
        public double DelayVar = 0;
        public double simTime = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "QosPerfomance");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simTime.ToString());
            writer.WriteAttributeString("TrafficName_SD", TrafficName_SD);
            writer.WriteAttributeString("AppTrafficSend", AppTrafficSend.ToString());
            writer.WriteAttributeString("AppTrafficRcvd", AppTrafficRcvd.ToString());
            writer.WriteAttributeString("DelayTime", DelayTime.ToString());
            writer.WriteAttributeString("DelayVar", DelayVar.ToString());

            writer.WriteEndElement();
        }

    }
    public class RD_UserAllNum   //用户总数
    {
        public int UserAllNum = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "UserAllNum");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("UserAllNum", UserAllNum.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_UserOnline //在线用户数目
    {
        public int UserOnlineNum = 0;
        public double simTime = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "UserOnline");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SimTime", simTime.ToString());
            writer.WriteAttributeString("UserOnlineNum", UserOnlineNum.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_AccessAbility //接入能力(用户的全局接入成功率)
    {
        public int AccessSignalingCost = 0;
        public double AccessTimeAverage = 0;
        public double AccessSuccessRate = 0;
        public double ChannelApplyAverage = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "AccessAbility");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("SignalingCost", AccessSignalingCost.ToString());
            writer.WriteAttributeString("TimeAverage", AccessTimeAverage.ToString());
            writer.WriteAttributeString("SuccessRate", AccessSuccessRate.ToString());
            writer.WriteAttributeString("ChannelApply", ChannelApplyAverage.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_Mobility
    {
        public string MobileNodeName;
        //起始点经纬度
        public string StartLongitude;
        public string StartLatitude;
        //终止点经纬度
        public string EndLatitude;
        public string EndLongitude;
        //起始时间
        public string MobileStartTime;
        //移动速度
        public string MobileSpeed;
        public string MobileEndTime;

        public void SaveXml(XmlWriter writer,long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "Mobility");
            writer.WriteAttributeString("MobileNodeName", MobileNodeName);
            writer.WriteAttributeString("StartLongitude", StartLongitude);
            writer.WriteAttributeString("StartLatitude", StartLatitude);
            writer.WriteAttributeString("MobileStartTime", MobileStartTime);
            writer.WriteAttributeString("EndLatitude", EndLatitude);
            writer.WriteAttributeString("EndLongitude", EndLongitude);

            writer.WriteAttributeString("MobileSpeed", MobileSpeed);
            writer.WriteEndElement();
        }
    }
    public class RD_PKLossRate    //全网物理层丢包率
    {
        public double PkLossRatioValue = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "PKLossRate");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("PkLossRatio", PkLossRatioValue.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_LinkTraDesign //链路传输能力设计指标
    {
        public double StogDownstrmDatarate = 0;
        public double StogUpstrmDatarate = 0;
        public double StosDatarate = 0;

        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "LinkTraDesign");
            writer.WriteAttributeString("Time", time.ToString());
            writer.WriteAttributeString("StogDwDataRate", StogDownstrmDatarate.ToString());
            writer.WriteAttributeString("StogUpDataRate", StogUpstrmDatarate.ToString());
            writer.WriteAttributeString("StosDataRate", StosDatarate.ToString());

            writer.WriteEndElement();
        }
    }
    public class RD_Finish
    {
        public void SaveXml(XmlWriter writer, long time)
        {
            writer.WriteStartElement("Packet");
            writer.WriteAttributeString("Type", "Finish");
            writer.WriteAttributeString("Time", time.ToString());

            writer.WriteEndElement();
        }
    }

    /*
    public class STK_Satellite
    {
        public String satellite_name = "";
        public String tle_first = "";
        public String tle_second = "";
        public char create_mode = ' '; 
    }
    public class STK_Facility
    {
        public String facility_name = "";
        public double facility_lat = 0;
        public double facility_lon = 0;
    }
    public class STK_Area
    {
        public String area_name = "";
        public double area_lat = 0;
        public double area_lon = 0;
        public double major_axis = 0;
        public double minor_axis = 0;
        public double area_bearing = 0;
    }
    public class STK_Vehicle
    {
        public String vehicle_name = "";
        public char vehicle_type = '\0';
    }
    public class STK_Chain
    {
        public String chain_name = "";
        public String object_name = "";
        public char object_type = '\0';
        public char create_mode = ' ';
    }
    public class STK_Constellation
    {
        public String constellation_name = "";
        public String object_name = "";
        public char object_type = '\0';
        public bool create_mode = true;
    }
    public class STK_Scale
    {
        public String object_name = "";
        public char object_type = '\0';
        public int object_scale = 0;
        public int max_distance = 0;
    }
    public class STK_Coverage
    {
        public String coverage_name = "";
        public String region_name = "";
        public char create_type = '\0';
        public bool create_mode = true;
        public double point_resolution = 0;
    }
    public class STK_Region
    {
        public String coverage_name = "";
        public String region_name = "";
        public int region_num = 0;
    }
    public class STK_AssignAsset
    {
        public String coverage_name = "";
        public String asset_name = "";
    }
    public class STK_ScenarioReady
    {
        public bool scenarioReady = true;
    }
    public class STK_Fom
    {
        public String coverage_name = "";
        public String fom_name = "";
        public int fom_type = 0;
        public double fom_threshold = 0;
    }
    public class STK_Sensor
    {
        public String sensor_name = "";
        public String object_name = "";
        public char sensor_type;
        public char object_type;
    }
    public class STK_Annotation
    {
        public String[] text_string = new String[10];
        public String annotation_name = "";
        public char create_mode = '\0';
        public int text_num = 0;
        public char coord_type = ' ', text_color = ' ', text_size = ' ';
        public double[] text_position = new double[3];
    }*/
    #endregion

}
