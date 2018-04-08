using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
namespace STK_demonstration
{
    public class ChartParam //保存初始化时添加到树控件Tag中的chart，用于接收RTI数据时快速更新
    {
        public int chartCount = 0;
        //***这里保存1层树节点的含曲线的Chart       
        public Chart mC_NetTra;//网络吞吐量的chart
        //***这里保存2层树节点的含多条曲线的多个Chart
        //***如果要添加新的用于索引的List，一定要注意在public ChartParam()中new，在public void Reset()中清空
        public List<String> mIx_S2SLink_Sat;
        public List<Chart> mCs_TraQos;//指定业务流Qos性能的chart
        public List<String> mIx_TraQos;
        #region 链路利用性能
        public List<Chart> mCs_S2GLink;//所有对地的链路传输速率的chart(有用到的波束都用一个chart)   
        public List<String> mIx_S2GLink_Sat;//卫星名，用于查找索引以获取chart或创建chart
        public List<List<int>> mIx_S2GLink_Beam;//波束号，用于确认是否该波束已累加过，每颗星对应一个List
        public List<List<double>> mDt_S2GLink_Up;//保存各星各波束的上行速率用于更改，单位字节，每颗星对应一个List
        public List<double> mDt_S2GLink_Up_Sum;//保存各星所有使用的波束的上行速率总和，单位字节
        public List<List<double>> mDt_S2GLink_Dw;//保存各波束的下行速率用于更改，单位字节，每颗星对应一个List
        public List<double> mDt_S2GLink_Dw_Sum;//保存各星所有使用的波束的下行速率总和，单位字节
        public List<Chart> mCs_G2SLink;//所有对空的链路传输速率的chart
        public List<String> mIx_G2SLink_Sat;//卫星名，用于查找索引以获取chart或创建chart
        public List<List<int>> mIx_G2SLink_Beam;//波束号，用于确认是否该波束已累加过，每颗星对应一个List
        public List<List<double>> mDt_G2SLink_Up;//保存各星各波束的上行速率用于更改，单位字节，每颗星对应一个List
        public List<double> mDt_G2SLink_Up_Sum;//保存各星所有使用的波束的上行速率总和，单位字节
        public List<List<double>> mDt_G2SLink_Dw;//保存各波束的下行速率用于更改，单位字节，每颗星对应一个List
        public List<double> mDt_G2SLink_Dw_Sum;//保存各星所有使用的波束的下行速率总和，单位字节
        #endregion
        public void Reset()
        {
            //注意：chart由父控件Dispose回收
            //-----------------------------
            //回收QOS
            foreach (Chart chart in mCs_TraQos)
                for (int i = 0; i < chart.Series.Count; i++)
                    chart.Series[i].Points.Clear();
            mCs_TraQos.Clear();
            mIx_TraQos.Clear();

            //-----------------------------
            //回收S2G
            foreach (Chart chart in mCs_S2GLink)
                for (int i = 0; i < chart.Series.Count; i++)
                    chart.Series[i].Points.Clear();
            mCs_S2GLink.Clear();

            mIx_S2GLink_Sat.Clear();
            foreach (List<int> list in mIx_S2GLink_Beam)
                list.Clear();
            mIx_S2GLink_Beam.Clear();
            foreach (List<double> list in mDt_S2GLink_Up)
                list.Clear();
            mDt_S2GLink_Up.Clear();
            mDt_S2GLink_Up_Sum.Clear();
            foreach (List<double> list in mDt_S2GLink_Dw)
                list.Clear();
            mDt_S2GLink_Dw.Clear();
            mDt_S2GLink_Dw_Sum.Clear();
            mIx_S2SLink_Sat.Clear();
            //------------------------------------
            //回收G2S
            foreach (Chart chart in mCs_G2SLink)
                for (int i = 0; i < chart.Series.Count; i++)
                    chart.Series[i].Points.Clear();
            mCs_G2SLink.Clear();

            mIx_G2SLink_Sat.Clear();
            foreach (List<int> list in mIx_G2SLink_Beam)
                list.Clear();
            mIx_G2SLink_Beam.Clear();
            foreach (List<double> list in mDt_G2SLink_Up)
                list.Clear();
            mDt_G2SLink_Up.Clear();
            mDt_G2SLink_Up_Sum.Clear();
            foreach (List<double> list in mDt_G2SLink_Dw)
                list.Clear();
            mDt_G2SLink_Dw.Clear();
            mDt_G2SLink_Dw_Sum.Clear();
            mIx_S2SLink_Sat.Clear();

        }
        //20160225建立n*1的竖型chartAreas
        public static Chart CreateChart(Chart chartTemplate, int areaCount, int serieCount = -1)//返回的Chart需要添加到Controls
        {
            int serPerAeraCount = 1;
            if (serieCount != -1)
                serPerAeraCount = serieCount / areaCount;
            Chart chart = new Chart();
            Legend legend = new Legend();
            ChartArea chartArea;
            Series series;
            for (int i = 0; i < areaCount; i++)
            {
                chartArea = new ChartArea();
                chartArea.Name = "ChartArea" + i.ToString();
                chartArea.AxisX.MajorGrid.Enabled = false;//不显示横线竖线
                chartArea.AxisY.MajorGrid.Enabled = false;
                chartArea.Axes[0].Minimum = 0;//设置X轴最小值为0
                for (int j = 0; j < serPerAeraCount; j++)
                {
                    series = new Series();
                    series.ChartArea = chartArea.Name;
                    series.ChartType = SeriesChartType.Line;
                    chart.Series.Add(series);
                }
                if (i != 0)//所有的竖型chartAreas的X轴都对齐到第一个chartAreas的X轴
                {
                    chartArea.AlignmentStyle = AreaAlignmentStyles.PlotPosition;
                    chartArea.AlignWithChartArea = chart.ChartAreas[0].Name;
                }
                //实现chartAreas的竖型显示
                float xD = 2.0F;//在2%处显示X轴
                float yD = 8.0F;//在8%处显示Y轴
                chartArea.Position.X = xD;//x方向在xD%处显示纵坐标
                chartArea.Position.Y = yD + i * (100 - yD) / areaCount;//y方向在yD%处显示纵坐标
                chartArea.Position.Width = (100 - xD);//左边预留xD%以显示纵坐标
                chartArea.Position.Height = (100 - yD) / areaCount;//上边预留yD%以显示legend图例，剩下的百分比平分给各aera
                chart.ChartAreas.Add(chartArea);
            }
            legend.Docking = Docking.Top;//上边显示legend图例
            chart.Legends.Add(legend);//添加图例说明
            chart.Location = chartTemplate.Location;
            chart.Name = "chart1";//所有chart名称要不一样？测试了不报错，这里先不区分，后面再赋值
            chart.Size = chartTemplate.Size;
            chart.Visible = false;
            return chart;
        }
        public ChartParam()
        {
            mCs_TraQos = new List<Chart>();
            mIx_TraQos = new List<string>();

            mCs_S2GLink = new List<Chart>();
            mIx_S2GLink_Sat = new List<string>();
            mIx_S2GLink_Beam = new List<List<int>>();
            mDt_S2GLink_Up = new List<List<double>>();
            mDt_S2GLink_Dw = new List<List<double>>();
            mDt_S2GLink_Up_Sum = new List<double>();
            mDt_S2GLink_Dw_Sum = new List<double>();

            mCs_G2SLink = new List<Chart>();
            mIx_G2SLink_Sat = new List<string>();
            mIx_G2SLink_Beam = new List<List<int>>();
            mDt_G2SLink_Up = new List<List<double>>();
            mDt_G2SLink_Dw = new List<List<double>>();
            mDt_G2SLink_Up_Sum = new List<double>();
            mDt_G2SLink_Dw_Sum = new List<double>();
        }
    }
    public class TreeNodeTag
    {
        public int Id;//0-不包含chart，只起标签作用；1-表格显示的指标；2-曲线显示的指标；
        //动态的chart且有父节点；不删除；不作单独的区分
        public int indexInParent;
        public System.Windows.Forms.ListView m_listView1;
        public System.Windows.Forms.ListView m_listView2;
        public Chart m_chart;//保存对应的chart便于直接绘图
        public TreeNodeTag(int type, Chart chart = null, int indexInParent = -1)
        {
            Id = type;
            m_chart = chart;
            m_listView1 = null;
            m_listView2 = null;
            indexInParent = -1;
        }
        public TreeNodeTag(int type, System.Windows.Forms.ListView listView1, System.Windows.Forms.ListView listView2)
        {
            Id = type;
            m_chart = null;
            m_listView1 = listView1;
            m_listView2 = listView2;
            indexInParent = -1;
        }
    }
}

