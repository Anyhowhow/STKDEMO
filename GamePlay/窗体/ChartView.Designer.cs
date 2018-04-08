namespace STK_demonstration
{
    partial class ChartView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView_zhibiao = new System.Windows.Forms.ListView();
            this.listView_jieru = new System.Windows.Forms.ListView();
            this.listView_yonghu = new System.Windows.Forms.ListView();
            this.panel_listView = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel_listView.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(181, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(593, 643);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(177, 645);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // listView_zhibiao
            // 
            this.listView_zhibiao.BackColor = System.Drawing.Color.White;
            this.listView_zhibiao.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView_zhibiao.Location = new System.Drawing.Point(0, 238);
            this.listView_zhibiao.Name = "listView_zhibiao";
            this.listView_zhibiao.Size = new System.Drawing.Size(593, 119);
            this.listView_zhibiao.TabIndex = 0;
            this.listView_zhibiao.UseCompatibleStateImageBehavior = false;
            // 
            // listView_jieru
            // 
            this.listView_jieru.BackColor = System.Drawing.Color.White;
            this.listView_jieru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_jieru.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView_jieru.Location = new System.Drawing.Point(0, 119);
            this.listView_jieru.Name = "listView_jieru";
            this.listView_jieru.Size = new System.Drawing.Size(593, 119);
            this.listView_jieru.TabIndex = 1;
            this.listView_jieru.UseCompatibleStateImageBehavior = false;
            // 
            // listView_yonghu
            // 
            this.listView_yonghu.BackColor = System.Drawing.Color.White;
            this.listView_yonghu.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView_yonghu.Location = new System.Drawing.Point(0, 0);
            this.listView_yonghu.Name = "listView_yonghu";
            this.listView_yonghu.Size = new System.Drawing.Size(593, 119);
            this.listView_yonghu.TabIndex = 2;
            this.listView_yonghu.UseCompatibleStateImageBehavior = false;
            // 
            // panel_listView
            // 
            this.panel_listView.Controls.Add(this.listView_zhibiao);
            this.panel_listView.Controls.Add(this.listView_jieru);
            this.panel_listView.Controls.Add(this.listView_yonghu);
            this.panel_listView.Location = new System.Drawing.Point(184, 0);
            this.panel_listView.Name = "panel_listView";
            this.panel_listView.Size = new System.Drawing.Size(593, 643);
            this.panel_listView.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ChartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 645);
            this.Controls.Add(this.panel_listView);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartView";
            this.Text = "指标显示";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel_listView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel_listView;
        private System.Windows.Forms.ListView listView_yonghu;
        private System.Windows.Forms.ListView listView_jieru;
        private System.Windows.Forms.ListView listView_zhibiao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}