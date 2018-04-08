using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace STK_demonstration
{
    //用来存储解析stk场景里面的对象
    public class STKScenObjs
    {
        //主视窗
        public MFrm view;
        //颜色
        public int sensorcolor_index;
        //物体表
        public List<STKObject> stkObjs;
        //城市表
        public List<City> stkcities;
        //固定用户表
        public List<City> stkusers;
        //业务流表
        public List<chain_path> all_path;  //保存全部的在线业务流
        //线目标表
        public List<string> LineTargets;
        //信令表
        public List<Msg> msglist;
        //传感器色彩选择
        public String[] LJ_sensorcolor = { "red", "orange", "yellow", "green", "blue", "pink", "purple" };
        public int LJ_sensorcolor_index = 0;
        public String LJ_sensorFilePath = null;
        //卫星模型的选择
        public string LJ_modulePath;
        #region 动态添加方法gez2017/2/20
        public bool newsat(string objname, double radius, double incline, double raan)
        {
            StringBuilder sat = new StringBuilder();
            StringBuilder orb = new StringBuilder();
            try
            {
                sat.AppendFormat("New / */Satellite {0}", objname);
                orb.AppendFormat("SetState */Satellite/{5} Classical J2Perturbation  \"{0}\" \"{1}\" 60 J2000 \"{0}\" {2} 0.0 {3} 0.0 {4} 360.0 ", view.startTime, view.endTime, radius, incline, raan, objname);
                this.view.root.ExecuteCommand(sat.ToString());
                this.view.root.ExecuteCommand(orb.ToString());//这句话很卡，相当占内存...已修复
                STKObject temp = new STKObject();
                temp.ClassName = "Satellite";
                temp.Level = 1;
                temp.ObjName = objname;
                temp.ParentObjName = "*";
                this.stkObjs.Add(temp);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),"添加卫星失败");
                return false;
            }
        }
        public bool newsat(string objname,double radius,double incline ,double raan,string mdlpath)
        {
            StringBuilder sat = new StringBuilder();
            StringBuilder orb = new StringBuilder();
            StringBuilder mdl = new StringBuilder();
            try
            {
                sat.AppendFormat("New / */Satellite {0}", objname);
                orb.AppendFormat("SetState */Satellite/{5} Classical J2Perturbation  \"{0}\" \"{1}\" 60 J2000 \"{0}\" {2} 0.0 {3} 0.0 {4} 360.0 ", view.startTime, view.endTime, radius, incline, raan, objname);
                mdl.AppendFormat("VO */Satellite/{1} Model File \"{0}\"", mdlpath, objname);
                this.view.root.ExecuteCommand(sat.ToString());
                view.root.ExecuteCommand(mdl.ToString());
                this.view.root.ExecuteCommand(orb.ToString());//这句话很卡，相当占内存...已修复
                STKObject temp = new STKObject();
                temp.ClassName = "Satellite";
                temp.Level = 1;
                temp.ObjName = objname;
                temp.ParentObjName = "*";
                this.stkObjs.Add(temp);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "添加卫星失败");
                return false;
            }
        }
        public bool newcity(string objname, string lat, string lon)
        {
            try
            {
                StringBuilder nam = new StringBuilder();
                StringBuilder loc = new StringBuilder();
                nam.AppendFormat("New / */Facility {0}", objname);
                loc.AppendFormat("SetPosition */Facility/{0} Geodetic {1} {2} 0.0", objname, lat, lon);
                this.view.root.ExecuteCommand(nam.ToString());
                //用来关闭所有的可视阈值
                view.root.ExecuteCommand(string.Format("VO */Facility/{0} ModelDetail Off", objname));
                //view.root.ExecuteCommand(string.Format("VO */Facility/{0} ScaleLog 3.5", objname));
                this.view.root.ExecuteCommand(loc.ToString());
                STKObject temp = new STKObject();
                City fac = new City();
                temp.ClassName = "Facility";
                temp.ObjName = objname;
                fac.name = objname;

                temp.Level = 1;
                temp.xpos = Convert.ToDouble(lat);
                fac.lat = Convert.ToDouble(lat);

                temp.ypos = Convert.ToDouble(lon);
                fac.lon = Convert.ToDouble(lon);

                temp.ParentObjName = "*";
                stkObjs.Add(temp);
                stkcities.Add(fac);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool newuser(string objname, string lat, string lon)
        {
            try
            {
                StringBuilder nam = new StringBuilder();
                StringBuilder loc = new StringBuilder();
                //下面这句话弃置不用，使用新的load语句
                nam.AppendFormat("New / */Facility {0}", objname);
                loc.AppendFormat("SetPosition */Facility/{0} Geodetic {1} {2} 0.0", objname, lat, lon);
                this.view.root.ExecuteCommand(nam.ToString());
                //用来关闭所有的可视阈值
                view.root.ExecuteCommand(string.Format("VO */Facility/{0} ModelDetail Off", objname));
                this.view.root.ExecuteCommand(loc.ToString());
                STKObject temp = new STKObject();
                City fac = new City();
                temp.ClassName = "Facility";
                temp.ObjName = objname;
                fac.name = objname;

                temp.Level = 1;
                temp.xpos = Convert.ToDouble(lat);
                fac.lat = Convert.ToDouble(lat);

                temp.ypos = Convert.ToDouble(lon);
                fac.lon = Convert.ToDouble(lon);

                temp.ParentObjName = "*";
                stkObjs.Add(temp);
                stkusers.Add(fac);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool newwalker(string sat, int planes, int pnum, double deg,double raanspread)
        {
            try
            {
                string cmd;
                cmd = string.Format("Walker */Satellite/{0} {1} {2} {3} {4} No", sat, planes, pnum, deg, raanspread);
                this.view.root.ExecuteCommand(cmd);
                int i, j;
                if (planes < 10 && pnum < 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置,这里一定要改
                            temp.ObjName = string.Format("FX{0:D1}{1:D1}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                else if(planes >= 10 && pnum >= 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置
                            temp.ObjName = string.Format("FX{0:D2}{1:D2}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                else if (planes < 10 && pnum >= 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置
                            temp.ObjName = string.Format("FX{0:D1}{1:D2}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                else if (planes >= 10 && pnum < 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置
                            temp.ObjName = string.Format("FX{0:D2}{1:D1}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool newwalker_SatUser(string sat, int planes, int pnum, double deg, double raanspread)
        {
            try
            {
                string cmd;
                cmd = string.Format("Walker */Satellite/{0} {1} {2} {3} {4} No", sat, planes, pnum, deg, raanspread);
                this.view.root.ExecuteCommand(cmd);
                int i, j;
                if (planes < 10 && pnum < 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置,这里一定要改
                            temp.ObjName = string.Format("RS{0:D1}{1:D1}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                else if (planes >= 10 && pnum >= 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置
                            temp.ObjName = string.Format("RS{0:D2}{1:D2}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                else if (planes < 10 && pnum >= 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置
                            temp.ObjName = string.Format("RS{0:D1}{1:D2}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                else if (planes >= 10 && pnum < 10)
                {
                    for (i = 1; i <= planes; i++)
                        for (j = 1; j <= pnum; j++)
                        {
                            STKObject temp = new STKObject();
                            temp.ClassName = "Satellite";
                            temp.Level = 1;
                            temp.ParentObjName = "*";
                            //星座名称的设置
                            temp.ObjName = string.Format("RS{0:D2}{1:D1}", i, j);
                            stkObjs.Add(temp);
                        }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool delsat(string obj)//删除某个卫星
        {
            try
            {
                string cmd;
                cmd = string.Format("Unload / */Satellite/{0}", obj);
                this.view.root.ExecuteCommand(cmd);

                var tobdel = stkObjs.Find(c => (c.ObjName == obj));
                stkObjs.Remove(tobdel);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool targetcircle(string objname, double lat, double lon, double radius)
        {
            string cmd;
            try
            {
                //执行新建
                cmd = string.Format("New / */AreaTarget {0}", objname);
                view.root.ExecuteCommand(cmd);

                //设置位置
                cmd = string.Format("SetPosition */AreaTarget/{2} Geodetic {0} {1} 0", lat, lon, objname);
                view.root.ExecuteCommand(cmd);

                //设置形状
                //radius *= 1000;
                cmd = string.Format("SetBoundary */AreaTarget/{1} Ellipse {0} {0} 0", radius, objname);
                view.root.ExecuteCommand(cmd);

                //设置颜色
                cmd = string.Format("Graphics */AreaTarget/{0} SetColor green", objname);
                view.root.ExecuteCommand(cmd);

                //设置填充
                cmd = string.Format("VO */AreaTarget/{0} Fill On", objname);
                view.root.ExecuteCommand(cmd);

                //设置隐藏字体
                cmd = string.Format("Graphics */AreaTarget/{0} Label Show Off", objname);
                view.root.ExecuteCommand(cmd);

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool delcircle(string objname)
        {
            string cmd;
            try
            {
                cmd = string.Format("Unload / */AreaTarget/{0}", objname);
                view.root.ExecuteCommand(cmd);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("大圆移除失败", e.ToString());
                return false;
            }
        }
        public void newveh(string obj)//添加一个新的交通工具
        {
            string cmd;
            cmd = string.Format("New / */Aircraft {0}", obj);
            view.root.ExecuteCommand(cmd);
        }
        /// <summary>
        /// 创造一条路径
        /// </summary>
        /// <param name="obj">对象名</param>
        /// <param name="x">纬度</param>
        /// <param name="y">经度</param>
        /// <param name="v">速度</param>
        public void vehway(string obj, string x, string y, string v)
        {
            string cmd;
            cmd = string.Format("AddWaypoint */Ship/{0} DetTimeAccFromVel {1} {2} 0 ｛3}", obj, x, y, v);
        }
        /// <summary>
        /// 设置路径的起始时间，一定要在vehway前面执行
        /// </summary>
        /// <param name="obj">物体名</param>
        /// <param name="time">开始行进的时间</param>
        public void vehtime(string obj, string time)
        {
            string cmd;
            cmd = string.Format("SetGreatArcStart */Ship/{0} \"{1}\"", obj, time);
            view.root.ExecuteCommand(cmd);
        }
        /// <summary>
        /// 用来放大卫星使得用户卫星明确地显示出来
        /// </summary>
        /// <param name="obj">该用户卫星的名字</param>
        public void hlSatUser(string obj)
        {
            try
            {
                view.root.ExecuteCommand(string.Format("VO */Satellite/{0} ModelDetail Off", obj));
                view.root.ExecuteCommand(string.Format("VO */Satellite/{0} ScaleLog 5", obj));
            }
            catch(Exception e)
            {}               
        }
        /// <summary>
        /// 用来设置一个地面站是否需要放大显示
        /// </summary>
        /// <param name="obj">地面站的名字</param>
        /// <param name="exe">true进行放大，false则是返回原型</param>
        public void hlSatSets(string obj,bool exe)
        {
            try
            {
                if (exe)
                {
                    view.root.ExecuteCommand(string.Format("VO */Satellite/{0} ModelDetail Off", obj));
                    view.root.ExecuteCommand(string.Format("VO */Satellite/{0} ScaleLog 4.5", obj));
                }
                else
                {
                    view.root.ExecuteCommand(string.Format("VO */Satellite/{0} ScaleLog 0.0", obj));
                }
            }
            catch (Exception e)
            { }
        }
        public void hlFaci(string obj,bool exe)
        {
            try
            {
                if (exe)
                {
                    if (obj.Contains("XG"))
                    {
                        string filepath1 = Directory.GetCurrentDirectory() + "\\model\\mce.mdl";
                        view.root.ExecuteCommand(string.Format("VO */Facility/{0} Model File {1}", obj, filepath1));
                        //view.root.ExecuteCommand(string.Format("VO */Facility/{0} Model Color blue", obj));
                        view.root.ExecuteCommand(string.Format("VO */Facility/{0} ScaleLog 4.5", obj));
                    }
                    else
                    {
                        string filepath2 = Directory.GetCurrentDirectory() + "\\model\\facility.mdl";
                        view.root.ExecuteCommand(string.Format("VO */Facility/{0} Model File {1}", obj, filepath2));
                        view.root.ExecuteCommand(string.Format("VO */Facility/{0} ScaleLog 4", obj));
                    }
                    //view.root.ExecuteCommand(string.Format("VO */Facility/{0} ScaleLog 4", obj));

                }
                else
                {
                    view.root.ExecuteCommand(string.Format("VO */Facility/{0} ScaleLog 0.0", obj));
                }
            }
            catch(Exception e)
            {}
        }
        #endregion
        public STKScenObjs(MFrm it)
        {
            view = it;
            this.stkObjs = new List<STKObject>();
            all_path = new List<chain_path>();  //保存全部的在线业务流
            LJ_sensorFilePath = Directory.GetCurrentDirectory() + "\\演示单元模型库\\Sensor0.sn";
            LJ_modulePath = Directory.GetCurrentDirectory() + "\\演示单元模型库\\Satellite2.sa";
            LineTargets = new List<string>();
            stkcities = new List<City>();
            msglist = new List<Msg>();
        }
        /// <summary>
        /// 获取所有对象，目前没有使用
        /// </summary>
        /// <param name="theName">对象的名称</param>
        /// <returns>返回对象的引用</returns>
        public STKObject GetObjByName(string theName)
        {
            foreach (STKObject obj in stkObjs)
            {
                if (obj.ObjName.Equals(theName))
                    return obj;
            }
            return null;
        }
        //链路通断定时处理
        public void setupchain(chain_path trafficPath,int diameter)
        {
            StringBuilder cmdCreate = new StringBuilder();
            StringBuilder cmdSensorRename = new StringBuilder();
            StringBuilder cmdSensorGraphics = new StringBuilder();
            StringBuilder cmdCommon = new StringBuilder();
            //在树视图上增加节点
            try
            {
                TreeNode node = new TreeNode(trafficPath.sensor_name);
                trafficPath.path_node = node;
                node.Tag = trafficPath;
                node.NodeFont = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Bold); //默认是显示该链路，用粗体
                view.trafficView.AddTreeNodeOnLev1(node);
                if (this.LJ_sensorcolor_index == this.LJ_sensorcolor.Length)
                    this.LJ_sensorcolor_index = 0;
                trafficPath.colorIndex = this.LJ_sensorcolor_index++;

                for (int i = 0; i < trafficPath.path.Count; i++)
                {
                    TreeNode node2 = new TreeNode(trafficPath.path[i]);
                    trafficPath.path_node.Nodes.Add(node2);
                }
            }
            catch
            {
            }
            //一个一个的增加传感器
            for (int i = 0; i < trafficPath.path_Objs.Count - 1; i++)
            {
                cmdCreate.Clear();
                cmdSensorRename.Clear();
                cmdSensorRename.Append("Rename */");
                cmdSensorGraphics.Clear();
                cmdCommon.Clear();
                if (trafficPath.path_Objs[i].ClassName.Equals("Facility") && trafficPath.path_Objs[i + 1].ClassName.Equals("Facility"))
                {                 
                        string namestr = trafficPath.path_Objs[i].ObjName + trafficPath.sensor_name;
                        cmdCreate.Append("New / */LineTarget " + namestr);
                        view.root.ExecuteCommand(cmdCreate.ToString());
                        LineTargets.Add(namestr);
                        string str = (2).ToString() + " " + trafficPath.path_Objs[i].ypos.ToString() + " " + trafficPath.path_Objs[i].xpos.ToString()
                                               + " " + trafficPath.path_Objs[i + 1].ypos.ToString() + " " + trafficPath.path_Objs[i + 1].xpos.ToString();
                        view.root.ExecuteCommand("SetLine */LineTarget/" + namestr + " LatLon " + str);
                        // this.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " LineStyle dashed");
                        view.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " LineWidth 8");
                        view.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " SetColor " + LJ_sensorcolor[trafficPath.colorIndex]);
                        view.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " Label Show Off");                   
                }
                else
                {
                        //星地的接口，这里显示波束
                        if((trafficPath.path_Objs[i].ClassName.Equals("Satellite") && trafficPath.path_Objs[i + 1].ClassName.Equals("Facility"))||(i>0)&&(trafficPath.path_Objs[i].ClassName.Equals("Satellite") && trafficPath.path_Objs[i - 1].ClassName.Equals("Facility")))
                        {
                            STKObject seled = trafficPath.path_Objs[i];
                            if(seled.LinkIndex==0)
                            {
                                string cmd,cmd2;
                                double temp_diameter = diameter/2.0;
                                int halfdiameter = (int)Math.Round(temp_diameter);
                                int smallhalfdiameter = (int)Math.Round(halfdiameter * 0.93);
                                cmd = string.Format("New / */Satellite/{0}/Sensor cov1",seled.ObjName);
                                cmd2= string.Format("New / */Satellite/{0}/Sensor cov2", seled.ObjName);
                                view.root.ExecuteCommand(cmd);
                                view.root.ExecuteCommand(cmd2);
                                cmd = string.Format("Define */Satellite/{0}/Sensor/cov1 SimpleCone {1}", seled.ObjName,halfdiameter);
                                cmd2 = string.Format("Define */Satellite/{0}/Sensor/cov2 SimpleCone {1}", seled.ObjName,smallhalfdiameter);
                                view.root.ExecuteCommand(cmd);
                                view.root.ExecuteCommand(cmd2);
                                cmd = string.Format("Define */Satellite/{0}/Sensor/cov1 SimpleCone {1}", seled.ObjName,halfdiameter);
                                cmd2 = string.Format("Define */Satellite/{0}/Sensor/cov2 SimpleCone {1}", seled.ObjName,smallhalfdiameter);
                                view.root.ExecuteCommand(cmd);
                                view.root.ExecuteCommand(cmd2);
                                //设置传感器的颜色
                                cmd = string.Format("Graphics */Satellite/{0}/Sensor/cov1 SetColor white", seled.ObjName);
                                cmd2 = string.Format("Graphics */Satellite/{0}/Sensor/cov2 SetColor red", seled.ObjName);
                                view.root.ExecuteCommand(cmd);
                                view.root.ExecuteCommand(cmd2);
                            }
                            seled.LinkIndex++;
                        }
                        //用来高亮显示地面的信关站
                        if(trafficPath.path_Objs[i].ClassName.Equals("Facility"))
                        {
                            try
                            {
                                hlFaci(trafficPath.path_Objs[i].ObjName, true);
                            }
                            catch { }
                        }
                        //用来显示星间的波束链路
                        cmdCreate.Append("Load / */").Append(trafficPath.path_Objs[i].ClassName).Append("/").Append(trafficPath.path_Objs[i].ObjName).Append("/Sensor ").Append(LJ_sensorFilePath);
                        cmdSensorRename.Append(trafficPath.path_Objs[i].ClassName).Append("/").Append(trafficPath.path_Objs[i].ObjName).Append("/Sensor/Sensor0 ").Append(trafficPath.sensor_name);
                        cmdCommon.Append(trafficPath.path_Objs[i].ClassName).Append("/").Append(trafficPath.path_Objs[i].ObjName).Append("/Sensor/").Append(trafficPath.sensor_name);
                        view.root.ExecuteCommand(cmdCreate.ToString());
                        view.root.ExecuteCommand(cmdSensorRename.ToString());
                        trafficPath.path_Objs[i].SensorName.Add(trafficPath.sensor_name.ToString());
                        cmdSensorGraphics.Clear();
                        cmdSensorGraphics.Append("Point */").Append(cmdCommon).Append(" Targeted Tracking ").Append(trafficPath.path_Objs[i + 1].ClassName)
                                .Append("/").Append(trafficPath.path_Objs[i + 1].ObjName).Append(" Hold ");
                        view.root.ExecuteCommand(cmdSensorGraphics.ToString());
                        cmdSensorGraphics.Clear();
                        cmdSensorGraphics.Append("VO */").Append(cmdCommon).Append(" Pulse Show On Amplitude 1 Smooth Off");
                        view.root.ExecuteCommand(cmdSensorGraphics.ToString());
                        cmdSensorGraphics.Clear();
                        cmdSensorGraphics.Append("VO */").Append(cmdCommon).Append(" Pulse PulseLength 300 Frequency 0.1 Style Box");
                        view.root.ExecuteCommand(cmdSensorGraphics.ToString());
                        cmdSensorGraphics.Clear();
                        cmdSensorGraphics.Append("Graphics */").Append(cmdCommon).Append(" SetColor ").Append(LJ_sensorcolor[trafficPath.colorIndex]);
                        view.root.ExecuteCommand(cmdSensorGraphics.ToString());
                        //cmdSensorGraphics.Clear();
                        //cmdSensorGraphics.Append("Graphics */").Append(cmdCommon_temp).Append(" LineWidth 10");//这只是设置投射到地面的边缘线的宽度
                        //this.root.ExecuteCommand(cmdSensorGraphics.ToString());
                        cmdSensorGraphics.Clear();
                        cmdSensorGraphics.Append("Graphics */").Append(cmdCommon).Append(" Show On");
                        view.root.ExecuteCommand(cmdSensorGraphics.ToString());
                        //用来显示链路上的卫星
                        if (trafficPath.path_Objs[i].ClassName == "Satellite")
                            hlSatSets(trafficPath.path_Objs[i].ObjName, true);
                        //给遥感卫星添加传感器
                        if (trafficPath.path_Objs[i].ObjName.IndexOf("RS")!=-1)
                        {
                            string cmd;
                            STKObject seled = trafficPath.path_Objs[i];
                            //安装传感器
                            cmd = string.Format("New / */Satellite/{0}/Sensor rscov1", seled.ObjName);

                            view.root.ExecuteCommand(cmd);

                            //设置波束形状
                            cmd = string.Format("Define */Satellite/{0}/Sensor/rscov1 Rectangular 45 1", seled.ObjName);

                            view.root.ExecuteCommand(cmd);

                            cmd = string.Format("Define */Satellite/{0}/Sensor/rscov1 Rectangular 45 1", seled.ObjName);

                            view.root.ExecuteCommand(cmd);

                            //设置传感器的颜色
                            cmd = string.Format("Graphics */Satellite/{0}/Sensor/rscov1 SetColor white", seled.ObjName);

                            view.root.ExecuteCommand(cmd);

                            //显示传感器
                            cmd = string.Format("Graphics */Satellite/{0}/Sensor/rscov1 Show On", seled.ObjName);

                            view.root.ExecuteCommand(cmd);

                        }
                }
            }
            //如果是最后一个目标的话
            if (trafficPath.path_Objs[trafficPath.path_Objs.Count - 1].ClassName.Equals("Facility"))
            {
                try
                {
                    hlFaci(trafficPath.path_Objs[trafficPath.path_Objs.Count - 1].ObjName, true);
                }
                catch { }
            }
        }               
        public void RemoveAllSensorOnPath(chain_path trafficPath)
        {
                String cmdSensorRemove_beg = "Unload / */";
                StringBuilder cmdSensorRemove = new StringBuilder();
                for (int i = 0; i < trafficPath.path_Objs.Count - 1; i++)//20151014
                {
                    if (trafficPath.path_Objs[i].SensorName.Contains(trafficPath.sensor_name))
                    {
                        trafficPath.path_Objs[i].SensorName.Remove(trafficPath.sensor_name);
                        cmdSensorRemove.Append(cmdSensorRemove_beg).Append(trafficPath.path_Objs[i].ClassName).Append("/").Append(trafficPath.path_Objs[i].ObjName)
                            .Append("/Sensor/").Append(trafficPath.sensor_name);
                        try
                        {
                            this.view.root.ExecuteCommand(cmdSensorRemove.ToString());
                        }
                        catch
                        {
                            MessageBox.Show("STK Command命令出错:" + "无法删除传感器");
                        }
                        cmdSensorRemove.Clear();
                    }
                    else if (trafficPath.path_Objs[i].ClassName.Equals("Facility") && trafficPath.path_Objs[i + 1].ClassName.Equals("Facility"))
                    {
                        try
                        {
                            string namestr = trafficPath.path_Objs[i].ObjName + trafficPath.sensor_name;
                            string str = "Unload / */LineTarget/" + namestr;
                            this.view.root.ExecuteCommand(str);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Unload / */LineTarget: \r\n" + e.Message);
                        }
                    }
                    //gez20170406删除波束
                    if((trafficPath.path_Objs[i].ClassName.Equals("Satellite") && trafficPath.path_Objs[i + 1].ClassName.Equals("Facility"))||(i>0)&&(trafficPath.path_Objs[i].ClassName.Equals("Satellite") && trafficPath.path_Objs[i - 1].ClassName.Equals("Facility")))
                    {
                        STKObject seled = trafficPath.path_Objs[i];
                        if(seled.LinkIndex==1)
                        {
                            string cmd, cmd2;
                            cmd = string.Format("Unload / */Satellite/{0}/Sensor/cov1",seled.ObjName);
                            cmd2= string.Format("Unload / */Satellite/{0}/Sensor/cov2",seled.ObjName);
                            view.root.ExecuteCommand(cmd);
                            view.root.ExecuteCommand(cmd2);
                        }
                        seled.LinkIndex--;
                    }
                    //gez20171116删除中继站类型的地面站的放大
                    if (trafficPath.path_Objs[i].ClassName.Equals("Facility"))
                    {
                        try
                        {
                            hlFaci(trafficPath.path_Objs[i].ObjName, false);
                        }
                        catch { }
                    }
                    if (trafficPath.path_Objs[i].ClassName.Equals("Satellite"))
                    {
                        hlSatSets(trafficPath.path_Objs[i].ObjName, false);
                    }
                    //移除遥感卫星的传感器
                    if (trafficPath.path_Objs[i].ObjName.IndexOf("RS") != -1)
                    {
                        string cmd;
                        STKObject seled = trafficPath.path_Objs[i];
                        cmd = string.Format("Unload / */Satellite/{0}/Sensor/rscov1 ", seled.ObjName);

                        view.root.ExecuteCommand(cmd);

                    }
                }
                //最后一个如果是facility的话才会有特殊效果
                if (trafficPath.path_Objs[trafficPath.path_Objs.Count - 1].ClassName.Equals("Facility"))
                {
                    try
                    {
                        hlFaci(trafficPath.path_Objs[trafficPath.path_Objs.Count - 1].ObjName, false);
                    }
                    catch { }
                }
        }
        /// <summary>
        /// 封包函数，用来制作回放包
        /// </summary>
        public RD_ChainInfo MakePacket(Msg msge)
        {
            view.RdXml.sw.Stop();
            RePlayData rpd = new RePlayData("ChainInfo", view.RdXml.sw.ElapsedMilliseconds);
            view.RdXml.sw.Start();
            RD_ChainInfo rd = new RD_ChainInfo();
            if (msge != null)
            {
                rd.id = msge.id;
                rd.PathNodes = msge.PathNodes;
                //rd.StartOrEnd = msge.StartOrEnd;
                rd.usetime = msge.time;
                rpd.packet = rd;
                view.RdXml.allPackets.Add(rpd);
                view.RdXml.packetAllNum++;
                return rd;
            }
            else return null;
        }
    }

    //用来存储单个STK object
    public class STKObject
    {
        public int Level;
        public string ObjName;
        public string ClassName;
        public string ParentObjName;
        public int LinkIndex;//代表连接的次数，降到0的时候就要减去掉它的传感器
        public List<string> SensorName;//直接由SrcDestIP构成，例如192.1.1-192.1.2 => Sensor1921119212
        public double xpos;//地面实体的坐标
        public double ypos;
        public STKObject()
        {
            Level = -1;
            ObjName = "";
            ClassName = "";
            ParentObjName = "";
            SensorName = new List<string>();
            LinkIndex = 0;
            xpos = 0;
            ypos = 0;
        }
        public STKObject(int lev, string objName, string className, string parentName)
        {
            Level = lev;
            ObjName = objName;
            ClassName = className;
            ParentObjName = parentName;
            SensorName = new List<string>();
            xpos = 0;
            ypos = 0;
        }
    }
    public class chain_path
    {
        public TreeNode path_node;//保存treeView窗体中的树节点
        public List<STKObject> path_Objs;//保存这条链路上的全部STKObject
        public List<String> path;//保存链路上收到的各元素对象的名称(即STKObject.objName) A->D
        public String sensor_name;//该链路经过的节点上必有这样一个sensor
        public int colorIndex;
        StringBuilder cmdSensorGraphics;
        private MFrm mainForm;
        public chain_path(MFrm frm)
        {
            mainForm = frm;
            cmdSensorGraphics = new StringBuilder();
            path = new List<string>();
            path_Objs = new List<STKObject>();
            colorIndex = 0;            
        }
        public void ShowOnSensorOnPath()
        {
            for (int i = 0; i < path_Objs.Count - 1; i++)   //最后一个obj没有sensor
            {
                if (path_Objs[i].ClassName.Equals("Facility") && path_Objs[i + 1].ClassName.Equals("Facility"))
                {
                    try
                    {
                        string namestr = path_Objs[i].ObjName + this.sensor_name;
                        if (mainForm.Scenemana.LineTargets.Contains(namestr) == false)
                        {
                            string cmdCreate = "New / */LineTarget " + namestr;
                            mainForm.root.ExecuteCommand(cmdCreate.ToString());
                            mainForm.Scenemana.LineTargets.Add(namestr);
                            string str = (2).ToString() + " " + path_Objs[i].ypos.ToString() + " " + path_Objs[i].xpos.ToString()
                                            + " " + path_Objs[i + 1].ypos.ToString() + " " + path_Objs[i + 1].xpos.ToString();
                            mainForm.root.ExecuteCommand("SetLine */LineTarget/" + namestr + " LatLon " + str);
                            mainForm.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " LineStyle dashed");
                            mainForm.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " LineWidth 5");
                            mainForm.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " SetColor " + mainForm.Scenemana.LJ_sensorcolor[colorIndex]);
                            mainForm.root.ExecuteCommand("Graphics */LineTarget/" + namestr + " Label Show Off");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("ShowOnSensorOnPath---Show On LineTarget: \r\n" + e.Message);
                    }
                    continue;//检测下一个path_Objs
                }               
                cmdSensorGraphics.Clear();
                cmdSensorGraphics.Append("Graphics */").Append(path_Objs[i].ClassName).Append("/").Append(path_Objs[i].ObjName).Append("/Sensor/")
                    .Append(sensor_name).Append(" Show On");
                try
                {
                    this.mainForm.root.ExecuteCommand(cmdSensorGraphics.ToString());
                }
                catch
                {
                    MessageBox.Show("STK Command命令出错:" + "无法显示链路");
                }
            }
        }
        public void ShowOffSensorOnPath()
        {
            for (int i = 0; i < path_Objs.Count - 1; i++)   //最后一个obj没有sensor
            {
                if (path_Objs[i].ClassName.Equals("Facility") && path_Objs[i + 1].ClassName.Equals("Facility"))
                {
                    try
                    {
                        string namestr = path_Objs[i].ObjName + this.sensor_name;
                        if (mainForm.Scenemana.LineTargets.Contains(namestr))
                        {
                            string str = "Unload / */LineTarget/" + namestr;
                            this.mainForm.root.ExecuteCommand(str);
                            mainForm.Scenemana.LineTargets.Remove(namestr);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("ShowOnSensorOnPath---Show Off LineTarget: \r\n" + e.Message);
                    }
                    continue;//检测下一个path_Objs
                }        
          

                cmdSensorGraphics.Clear();
                cmdSensorGraphics.Append("Graphics */").Append(path_Objs[i].ClassName).Append("/").Append(path_Objs[i].ObjName).Append("/Sensor/").Append(sensor_name).Append(" Show Off");
                try
                {
                    this.mainForm.root.ExecuteCommand(cmdSensorGraphics.ToString());
                }
                catch
                {
                    MessageBox.Show("STK Command命令出错:" + "无法隐藏链路");
                }
            }
        }
    }       
    /// <summary>
    /// 用于覆盖显示的城市类
    /// </summary>
    public class City
    {
        public string name;
        public double lat;
        public double lon;
    }
}
