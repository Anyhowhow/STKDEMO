using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace STK_demonstration
{
    public partial class ChartView : Form
    {
        public ChartView()
        {
            InitializeComponent();//VS自行实现的初始化函数
            Initial();//自定义的初始化函数
            timer1.Enabled = true;
        }
        public System.Windows.Forms.ListViewItem m_listItem_zhibiao;
        public System.Windows.Forms.ListViewItem m_listItem_jieru;
        public System.Windows.Forms.ListViewItem m_listItem_yonghu;
        public ChartParam m_chartParam;
        public bool isSeriesGet = false;//GEO、IGSO等的Series Name只要设置一次
        public int AddNodeOn2(TreeNode node, String parent) //将node添加到parent指定的顶层节点下面,返回其索引
        {           //要检查是否已添加顶层树节点，如果没有先添加顶层节点20160225
            int index = 0;
            for (; index < this.treeView1.Nodes.Count; index++)//treeView1.Nodes表示第一层的树节点集合，treeView1.Nodes[0].Nodes表示第一层的第一个树节点的子节点集合
                if (this.treeView1.Nodes[index].Text.Equals(parent))
                    break;
            if (index == this.treeView1.Nodes.Count)//没有对应顶层节点，先添加顶层节点
            {
                TreeNode node1 = new TreeNode(parent);
                TreeNodeTag nodeTag = new TreeNodeTag(0);//给顶层树节点绑定一个tag起到标识和保存一些参数的作用，可以在点击树节点的响应函数中取出，0-不包含chart，只起标签作用
                node1.Tag = nodeTag;
                this.treeView1.Nodes.Add(node1);//暂时去掉对地链路指标
            }
            this.treeView1.Nodes[index].Nodes.Add(node);
            return this.treeView1.Nodes[index].Nodes.Count - 1;
        }
        /// <summary>
        /// 初始化表格和图表的大小、位置
        /// </summary>
        public void Initial()
        {
            this.Text = "指标显示";
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//不显示chart的横竖线
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.Name = "chartTemplate";
            chart1.Visible = false;
            m_chartTemplate = chart1;//暂存chart1用于删除chart后恢复默认视图，主要用于保存chart大小和位置
            listView_zhibiao.Visible = true;
            listView_zhibiao.View = View.Details;
            listView_jieru.Visible = true;
            listView_jieru.View = View.Details;
            listView_yonghu.Visible = true;
            listView_yonghu.View = View.Details;

            panel_listView.Location = m_chartTemplate.Location;
            panel_listView.Size = m_chartTemplate.Size;
            panel_listView.Visible = false;

            int listViewCount = 3;  //panel中表格个数，这里目前只有listView_zhibiao listView_jieru listView_yonghu三个
            int listViewHeight = panel_listView.Height / listViewCount;
            //3个表格的大小和位置
            listView_zhibiao.Location = new Point(0, panel_listView.Location.Y + listViewHeight * 0);//listView_zhibiao是以子窗体的形式加入到panel，计算相对坐标
            listView_zhibiao.Height = listViewHeight;
            listView_zhibiao.Width = panel_listView.Width;
            listView_yonghu.Location = new Point(0, panel_listView.Location.Y + listViewHeight * 1);
            listView_yonghu.Height = listViewHeight;
            listView_yonghu.Width = panel_listView.Width;
            listView_jieru.Location = new Point(0, panel_listView.Location.Y + listViewHeight * 2);
            listView_jieru.Height = listViewHeight;
            listView_jieru.Width = panel_listView.Width;
            //设置各表格的各列
            int column = 4;
            int wid = panel_listView.Width / column;
            listView_zhibiao.Columns.Add("星地下行设计速率", wid, HorizontalAlignment.Left);
            listView_zhibiao.Columns.Add("星地上行设计速率", wid, HorizontalAlignment.Left);
            listView_zhibiao.Columns.Add("星间传输设计速率", wid, HorizontalAlignment.Left);
            m_listItem_zhibiao = new ListViewItem(new string[] {
                    "",
                    "",
                    ""
                  }, 0);
            listView_zhibiao.Items.Add(m_listItem_zhibiao);
            listView_jieru.Columns.Add("全局接入成功率(%)", wid, HorizontalAlignment.Left);
            listView_jieru.Columns.Add("用户平均接入时间", wid, HorizontalAlignment.Left);
            listView_jieru.Columns.Add("业务平均接入时间", wid, HorizontalAlignment.Left);
            listView_jieru.Columns.Add("接入管理信令开销", wid, HorizontalAlignment.Left);
            m_listItem_jieru = new ListViewItem(new string[] {
                    "",
                    "",
                    "",
                    ""
                  }, 0);
            listView_jieru.Items.Add(m_listItem_jieru);
            listView_yonghu.Columns.Add("移动用户总数", wid, HorizontalAlignment.Left);
            listView_yonghu.Columns.Add("在线用户数目", wid, HorizontalAlignment.Left);
            //listView_yonghu.Columns.Add("网络丢包率(%)", wid, HorizontalAlignment.Left);
            m_listItem_yonghu = new ListViewItem(new string[] {
                    "0",
                    "0",
                    ""
                  }, 0);
            listView_yonghu.Items.Add(m_listItem_yonghu);

            m_chartParam = new ChartParam();
            TreeNode node;
            TreeNodeTag nodeTag;
            Chart chart;
            //-------------"表格显示的指标"--------------------
            node = new TreeNode("表格显示的指标");
            nodeTag = new TreeNodeTag(1, listView_zhibiao, listView_jieru);
            node.Tag = nodeTag;
            this.treeView1.Nodes.Add(node); //暂时去掉表格的指标
            //-------------"网络吞吐量"--------------------
            chart = ChartParam.CreateChart(m_chartTemplate, 1);//有几个chartarea（series）就设几个
            m_chartParam.mC_NetTra = chart;
            chart.Name = "chart" + (m_chartParam.chartCount++).ToString();//所有chart名称不一样
            chart.ChartAreas[0].Position.Auto = false;
            chart.ChartAreas[0].Position.Height = 50F;//因为只有一张表所以只设为50%的大小
            chart.ChartAreas[0].Position.Width = 70F;
            chart.ChartAreas[0].Position.X = 10F; //x方向在10%处显示纵坐标
            chart.ChartAreas[0].Position.Y = 20F;
            chart.Series[0].Name = "吞吐量(kb/s)";

            this.Controls.Add(chart);
            node = new TreeNode("网络吞吐量");
            nodeTag = new TreeNodeTag(2, chart);//绑定tag
            node.Tag = nodeTag;
            this.treeView1.Nodes.Add(node);
            /*//不再程序启动就新建此顶层节点，而是在第一次收到相应包才新建
            //-------------"各星资源占用"--------------------
            node = new TreeNode("各星资源占用率");
            nodeTag = new TreeNodeTag(0);//0-不包含chart，只起标签作用
            node.Tag = nodeTag;
            this.treeView1.Nodes.Add(node);
            //-------------"对地链路传输能力"--------------------
            node = new TreeNode("对地链路传输能力");
            nodeTag = new TreeNodeTag(0);//0-不包含chart，只起标签作用
            node.Tag = nodeTag;
            this.treeView1.Nodes.Add(node);//暂时去掉对地链路指标
            //-------------"星间链路传输能力"--------------------
            node = new TreeNode("星间链路传输能力");
            nodeTag = new TreeNodeTag(0);//0-不包含chart，只起标签作用
            node.Tag = nodeTag;
            this.treeView1.Nodes.Add(node);//暂时去掉星间链路指标
            //-------------"业务流Qos性能"--------------------
            node = new TreeNode("业务流Qos性能");
            nodeTag = new TreeNodeTag(0);//0-不包含chart，只起标签作用
            node.Tag = nodeTag;
            this.treeView1.Nodes.Add(node);
            */
        }
        public void Reset()
        {
            m_chartParam.Reset();
        }
        public Chart m_chartTemplate;//暂存chart1用于删除chart后恢复默认视图
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNodeTag tag = (TreeNodeTag)e.Node.Tag;

            if (tag.Id == 0)
            {
                chart1.Enabled = false;//防止闪烁
                chart1.Visible = false;
                panel_listView.Enabled = false;
                panel_listView.Visible = false;
            }
            else if (tag.Id == 1)
            {
                chart1.Enabled = false;//防止闪烁
                chart1.Visible = false;
                panel_listView.Enabled = true;
                panel_listView.Visible = true;
                return;
            }
            else if (tag.Id == 2)
            {
                panel_listView.Enabled = false;
                panel_listView.Visible = false;
                chart1.Enabled = false;//防止闪烁
                //m_charts[i].Enabled = false;
                chart1.Visible = false;
                tag.m_chart.Visible = true;
                chart1 = tag.m_chart;//保存，以待下次切换时隐藏
                chart1.Enabled = true;
                //m_charts[i].Enabled = true;
            }
        }

        private void ChartView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //尝试刷新图标
            if(chart1.Visible)
            {
                chart1.BeginInit();
                chart1.Show();
                chart1.EndInit();
            }
        }
    }
}

