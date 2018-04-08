using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime;
using System.Diagnostics;

namespace STK_demonstration
{
    public partial class FormTest : Form
    {
        #region 数值区
        int para1;
        int para3;
        int para2=0;
        double para4;
        double para5;
        string filename, filename1, filename2, filename3;
        #endregion
        #region 对象区
        picture_form pf;
        #endregion
        public FormTest()
        {
            InitializeComponent();
        }
        //从csv读取数据返回table 
        public DataTable OpenCSV(string filePath) 
        {
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);

            //记录每次读取的一行记录  
            string strLine = "";
            //记录每行记录中的各字段内容  
            string[] aryLine = null;
            //标示列数  
            int columnCount = 0;
            //标示是否是读取的第一行  
            bool IsFirst = true;
            //逐行读取CSV中的数据  
            while ((strLine = sr.ReadLine()) != null)
            {
                aryLine = strLine.Split(',');
                if (IsFirst == true)
                {
                    IsFirst = false;
                    columnCount = aryLine.Length;
                    //创建列  
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(aryLine[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            sr.Close();
            fs.Close();
            return dt;
        }
        public DataTable OpenTXT(string filePath)
        {
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);

            //记录每次读取的一行记录  
            string strLine = "";
            //记录每行记录中的各字段内容  
            string[] aryLine = null;
            //标示列数  
            int columnCount = 4;
            int rowCount = 0;
            double hourCount = 0;
            string ColumnName = "";
            bool IsFirst = true;
            //逐行读取txt中的数据  
            while ((strLine = sr.ReadLine()) != null)
            {
                         
                rowCount++;
                //添加每列的信息
                if (IsFirst == true)
                {
                    IsFirst = false;                   
                    //创建列  
                    for (int i = 0; i < columnCount; i++)
                    {                        
                        switch (i)
                        {
                            case 0: ColumnName = "hour";
                                break;
                            case 1: ColumnName = "satelite1";
                                break;
                            case 2: ColumnName = "satelite2";
                                break;
                            case 3: ColumnName = "satelite3";
                                break;
                        }
                        DataColumn dc = new DataColumn(ColumnName);
                        dt.Columns.Add(dc);
                    }
                }
                if (rowCount >= 9)
                {
                    //aryLine = strLine.Split(',');
                    aryLine = Regex.Split(strLine, "  ", RegexOptions.IgnoreCase);
                    if (aryLine[0] == "")
                    {
                        for (int i = 0;i<3;i++)
                        {
                            aryLine[i] = aryLine[i + 1];
                        }
                    }                    
                    DataRow dr = dt.NewRow();
                    dr[0] = hourCount;                    
                    if (hourCount > 24)
                    {
                        hourCount = 24;
                    }
                    for (int j = 0; j < columnCount-1; j++)
                    {                                               
                        dr[j+1] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                    hourCount = hourCount + 0.01667;
                }                                      
            }
            sr.Close();
            fs.Close();
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            para2 = 0;

            if (radioButton1.Checked == true) para1 = 1;
            if (radioButton2.Checked == true) para1 = 2;
            if (radioButton3.Checked == true) para1 = 3;
            if (radioButton4.Checked == true) para1 = 4;
            if (radioButton5.Checked == true) para1 = 5;
            if (radioButton6.Checked == true) para1 = 6;
            if (radioButton7.Checked == true) para1 = 7;
            if (radioButton8.Checked == true) para1 = 8;
            if (radioButton9.Checked == true) para1 = 9;
            if (radioButton10.Checked == true) para1 = 10;
            if (radioButton11.Checked == true) para1 = 11;
            if (radioButton12.Checked == true) para1 = 12;

            if (checkBox1.Checked == true) para2 += 1;
            if (checkBox2.Checked == true) para2 += 2;
            if (checkBox3.Checked == true) para2 += 4;
            if (checkBox4.Checked == true) para2 += 8;

            if(radioButton13.Checked==true)
            {
                DateTime dt = dateTimePicker1.Value;
                double timeValue = jday(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                para3 = 1; para4 = timeValue;para5 = 0;
            }
            if(radioButton14.Checked==true)
            {
                para3 = 2;para4 = 0;para5 = 0;
            }
            if (radioButton15.Checked == true)
            {
                para3 = 3;
                para4 = Convert.ToDouble(textBox1.Text);
                para5 = Convert.ToDouble(textBox2.Text);
            }
            switch (para1)
            {
                case 1:
                    filename1 = "satnum";
                    break;
                case 2:
                    filename1 = "GDOP";
                    break;
                case 3:
                    filename1 = "PDOP";
                    break;
                case 4:
                    filename1 = "TDOP";
                    break;
                case 5:
                    filename1 = "ele";
                    break;
                case 6:
                    filename1 = "skyplot";
                    break;
                case 7:
                    filename1 = "sattrack";
                    break;
                case 8:
                    filename1 = "success";
                    break;
                case 9:
                    filename1 = "convergence";
                    break;
                case 10:
                    filename1 = "HPL";
                    break;
                case 11:
                    filename1 = "VPL";
                    break;
                case 12:
                    filename1 = "availability";
                    break;
            }
            filename2 = para2.ToString().PadLeft(2, '0');
            filename3 = para3.ToString();
            //合成图片文件的文件名 如 satnum023.jpg
            filename = "D:\\PNTSimdata\\" + filename1 + filename2 + filename3 + ".jpg";
            string args = string.Format("{0} {1} {2} {3} {4}", para1, para2, para3, para4, para5);
            //控制台连接
            try
            {
                //为了加快速度，就先注释掉这些
                //var pr = Process.Start("PNTSimu.exe", args);
            
                //label6.Text = "计算中";
                //pr.WaitForExit();
                label6.Text = "计算完毕";
            }
            catch { }
            pf = new picture_form();
            pf.Hide();
            pf.ShowPicture(filename);
            //pf.Show();
        }
        private double jday(double yr, double mon, double day, double hr, double min, double sec)
        {
            double jd = 367.0 * yr - Math.Floor((7 * (yr + Math.Floor((mon + 9) / 12.0))) * 0.25)+ Math.Floor(275 * mon / 9.0)
            + day + 1721013.5+ ((sec / 60.0 + min) / 60.0 + hr) / 24.0;
            return jd;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked== true)
            {
                radioButton15.Checked = false;
            }
            else
            {
                radioButton15.Checked = true;
            }

        }

        private void FormTest_Load(object sender, EventArgs e)
        { 
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
            }
            else
            {
                radioButton13.Enabled = true;
                radioButton14.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
            }
            else
            {
                radioButton13.Enabled = true;
                radioButton14.Enabled = false;
            }
        }
    }
}
