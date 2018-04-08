using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STK_demonstration
{
    public partial class ShowUsers : Form
    {
        MFrm view;
        public ShowUsers(MFrm it)
        {
            view = it;
            InitializeComponent();
        }
        public void ShowTreeview(string thelink)
        {                     
                //将波束用户信息进行分离，存储在数组中            
                //每行都重置判断信息
                string[] data_detail = null;
                bool sat_build = true;
                bool first_build = true;
                bool boshu_build = true;
                bool boshu1_build = true;
                bool boshu2_build = true;
                bool user_build = true;
                //分割字符串，如YH6->[UL0]FX0509[FL0]->XG5分割为：YH6，[UL0]FX0509[FL0],XG5
                data_detail = thelink.Split(new string[] { "->" }, StringSplitOptions.None);
                for (int j = 0; j < data_detail.Length; j++)
                {
                    //判断是否为单波束
                    if (data_detail[j].Contains("FX") && data_detail[j].Length < 14)
                    {
                        //此时数据格式类似：FX0512[UL]->YH6
                        int boshu_length;
                        boshu_length = data_detail[j].Length - 8;
                        string sat = data_detail[j].Substring(0, 6);//取第1-6位的卫星名称
                        string boshu = data_detail[j].Substring(7, boshu_length); //第8位起，根据波束长度来取波束名称                      
                        string user = data_detail[j + 1];
                        //第一次建立全部的三级节点，防止遍历了null节点
                        if (first_build)
                        {
                            TreeNode nodesat = treeView1.Nodes.Add(sat);//添加根节点
                            TreeNode nodeboshu = nodesat.Nodes.Add(boshu);//添加第二级子节点
                            TreeNode nodeuser = nodeboshu.Nodes.Add(user);   //添加第三级子节点
                            first_build = false;
                        }
                        else //不是第一次建立，则开始遍历第一级节点,判断当前节点是否已在treeview中
                        {
                            //遍历已建立的根节点，并保存遍历信息
                            foreach (TreeNode sat_ever in treeView1.Nodes)
                            {
                                if (sat.Equals(sat_ever.Text))
                                {
                                    sat_build = false;
                                    treeView1.SelectedNode = sat_ever;
                                }
                            }
                            //新建根节点    
                            if (sat_build)
                            {
                                //新建对应的二级、三级子节点，防止遍历了null节点
                                TreeNode nodesat = treeView1.Nodes.Add(sat);//添加根节点
                                TreeNode nodeboshu = nodesat.Nodes.Add(boshu);//添加第二级子节点
                                TreeNode nodeuser = nodeboshu.Nodes.Add(user);   //添加第三级子节点
                            }
                            else//不需要新建根节点，则遍历第二级节点
                            {
                                foreach (TreeNode boshu_ever in treeView1.SelectedNode.Nodes)
                                {
                                    if (boshu.Equals(boshu_ever.Text))
                                    {
                                        boshu_build = false;
                                        treeView1.SelectedNode = boshu_ever;
                                    }
                                }
                                //新建二级子节点
                                if (boshu_build)
                                {
                                    //新建对应的三级节点，，防止遍历了null节点
                                    TreeNode nodeboshu = treeView1.SelectedNode.Nodes.Add(boshu);//添加第二级子节点
                                    TreeNode nodeuser = nodeboshu.Nodes.Add(user);//添加第三级子节点
                                }
                                else//不需要新建二级节点，则遍历第三级节点
                                {
                                    foreach (TreeNode user_ever in treeView1.SelectedNode.Nodes)
                                    {
                                        if (user.Equals(user_ever.Text))
                                        {
                                            user_build = false;
                                        }
                                    }
                                    if (user_build)
                                    {
                                        TreeNode nodeuser = treeView1.SelectedNode.Nodes.Add(user);   //添加第三级子节点
                                    }
                                }
                            }
                        }
                    }
                    //判断是否为双波束
                    else if (data_detail[j].Contains("FX") && data_detail[j].Length >= 14)
                    {
                        //此时数据格式类似：YH6->[UL0]FX0509[FL0]->XG5
                        int boshu_length1, boshu_length2;
                        if (data_detail[j].Length == 16)
                        {
                            boshu_length1 = boshu_length2 = 3;
                        }
                        else if (data_detail[j].Length == 17)
                        {
                            boshu_length1 = 3;
                            boshu_length2 = 4;
                        }
                        else
                        {
                            boshu_length1 = boshu_length2 = 4;
                        }
                        string boshu1 = data_detail[j].Substring(1, boshu_length1);//取左边的波束名称，如UL0
                        string sat = data_detail[j].Substring(boshu_length1 + 2, 6); //取卫星名称               
                        string boshu2 = data_detail[j].Substring(boshu_length1 + 9, boshu_length2);//取右边的波束名称，如FL0
                        string user1 = data_detail[j - 1];//取左边的用户名称
                        string user2 = data_detail[j + 1];//取右边的用户名称
                        //第一次建立全部的三级节点，防止遍历了null节点
                        if (first_build)
                        {
                            TreeNode nodesat = treeView1.Nodes.Add(sat);//添加根节点
                            TreeNode nodeboshu1 = nodesat.Nodes.Add(boshu1);//添加第二级子节点
                            TreeNode nodeuser1 = nodeboshu1.Nodes.Add(user1);//添加第三级子节点
                            TreeNode nodeboshu2 = nodesat.Nodes.Add(boshu2);//添加第二级子节点                        
                            TreeNode nodeuser2 = nodeboshu2.Nodes.Add(user2);//添加第三级子节点
                            first_build = false;
                        }
                        else //不是第一次建立，则开始遍历第一级节点,判断当前节点是否已在treeview中
                        {
                            //遍历已建立的根节点，并保存遍历信息
                            foreach (TreeNode sat_ever in treeView1.Nodes)
                            {
                                if (sat.Equals(sat_ever.Text))
                                {
                                    sat_build = false;
                                    treeView1.SelectedNode = sat_ever;
                                }
                            }
                            //新建根节点    
                            if (sat_build)
                            {
                                //新建对应的二级、三级子节点，防止遍历了null节点
                                TreeNode nodesat = treeView1.Nodes.Add(sat);//添加根节点
                                TreeNode nodeboshu1 = nodesat.Nodes.Add(boshu1);//添加左边波束的二级子节点
                                TreeNode nodeboshu2 = nodesat.Nodes.Add(boshu2);//添加右边波束的二级子节点
                                TreeNode nodeuser1 = nodeboshu1.Nodes.Add(user1);//添加左边用户的三级子节点
                                TreeNode nodeuser2 = nodeboshu2.Nodes.Add(user2);//添加右边用户的三级子节点
                            }
                            else//不需要新建根节点，则遍历第二级节点
                            {
                                //判断左边波束是否已在treeview中
                                foreach (TreeNode boshu_ever in treeView1.SelectedNode.Nodes)
                                {
                                    if (boshu1.Equals(boshu_ever.Text))
                                    {
                                        boshu1_build = false;
                                        treeView1.SelectedNode = boshu_ever;//为遍历下一层节点做准备
                                    }
                                }
                                //新建左边波束的二级子节点
                                if (boshu1_build)
                                {
                                    //新建对应的三级节点，防止遍历了null节点
                                    TreeNode nodeboshu = treeView1.SelectedNode.Nodes.Add(boshu1);//添加第二级子节点
                                    TreeNode nodeuser = nodeboshu.Nodes.Add(user1);//添加第三级子节点
                                }
                                else//不需要新建二级节点，则遍历第三级节点
                                {
                                    foreach (TreeNode user_ever in treeView1.SelectedNode.Nodes)
                                    {
                                        if (user1.Equals(user_ever.Text))
                                        {
                                            user_build = false;
                                        }
                                    }
                                    if (user_build)
                                    {
                                        TreeNode nodeuser = treeView1.SelectedNode.Nodes.Add(user1);//添加第三级子节点
                                    }
                                }
                                //判断右边波束是否已在treeview中
                                foreach (TreeNode boshu_ever in treeView1.SelectedNode.Nodes)
                                {
                                    if (boshu2.Equals(boshu_ever.Text))
                                    {
                                        boshu2_build = false;
                                        treeView1.SelectedNode = boshu_ever;//为遍历下一层节点做准备
                                    }
                                }
                                
                                //新建右边波束的二级子节点
                                if (boshu2_build)
                                {
                                    //新建对应的三级节点，防止遍历了null节点
                                    TreeNode nodeboshu = treeView1.SelectedNode.Nodes.Add(boshu2);//添加第二级子节点
                                    TreeNode nodeuser = nodeboshu.Nodes.Add(user2);//添加第三级子节点
                                }
                                else//不需要新建二级节点，则遍历第三级节点
                                {
                                    foreach (TreeNode user_ever in treeView1.SelectedNode.Nodes)
                                    {
                                        if (user2.Equals(user_ever.Text))
                                        {
                                            user_build = false;
                                        }
                                    }
                                    if (user_build)
                                    {
                                        TreeNode nodeuser = treeView1.SelectedNode.Nodes.Add(user2);   //添加第三级子节点
                                    }
                                }
                            }
                        }
                    }
                
            }
            treeView1.SelectedNode = null;
            //treeView1.ExpandAll();
        }
        public string GetLink(double currentTime)
        {
            #region 变量区
            string filePath;//path文件的路径            
            List<string> info_get = new List<string>();//path文件中读取到的链路
            DateTime tStart;//格式化后的开始时间
            DateTime tEnd;//格式化后的结束时间
            List<DateTime> time_start = new List<DateTime>();//链路开始时刻
            List<DateTime> time_end = new List<DateTime>();//链路结束时刻           
            string thelink = null;//当前时刻对应的链路
            #endregion
            filePath = Directory.GetCurrentDirectory() + "\\path.csv";
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
            //记录每次读取的一行记录  
            string strLine = "";
            //记录每行记录中的各字段内容  
            string[] aryLine = null;
            info_get.Clear();
            time_start.Clear();
            time_end.Clear();
            //逐行读取CSV中的数据  
            while ((strLine = sr.ReadLine()) != null && (strLine = sr.ReadLine()) != "")
            {
                //只保存第一列的波束用户数据               
                aryLine = strLine.Split(',');
                info_get.Add(aryLine[0]);
                //读取第二列的开始时间与第三列的结束时间，并转换为DateTime类型
                tStart = DateTime.ParseExact(aryLine[1], "yyyy:MM:dd:HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                tEnd = DateTime.ParseExact(aryLine[2], "yyyy:MM:dd:HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);                
                time_start.Add(tStart);
                time_end.Add(tEnd);
            }
            sr.Close();
            fs.Close();
            DateTime StartTime = view.dStartTime;
            for (int i = 0; i < time_start.Count; i++)
            {
                double realStart = (time_start[i]-StartTime).TotalSeconds;
                double realEnd = (time_end[i] - StartTime).TotalSeconds;
                if (currentTime >= realStart&&currentTime<=realEnd)
                {
                    thelink = info_get[i];
                    break;
                }
            }
            return thelink;
        }
        public void ClearTreeview()
        {
            treeView1.Nodes.Clear();
        }
    }
}
