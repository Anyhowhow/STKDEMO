using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STK_demonstration
{
    public partial class TrafficView : Form
    {
        public TrafficView()
        {
            InitializeComponent();
        }
        public void AddTreeNodeOnLev1(TreeNode node)
        {
            this.treeView1.Nodes.Add(node);
        }
        public bool DelTreeNodeByName(String nodeName)
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
                if (treeView1.Nodes[i].Text.Equals(nodeName))
                {
                    treeView1.Nodes.Remove(treeView1.Nodes[i]);
                    return true;
                }
            return false;
        }
        private void TrafficView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
                if (treeView1.Nodes[i].NodeFont.Bold == false)
                {
                    treeView1.Nodes[i].NodeFont = new Font("宋体", 9, FontStyle.Bold);
                    ((chain_path)(treeView1.Nodes[i].Tag)).ShowOnSensorOnPath();
                }
            treeView1.EndUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
                if (treeView1.Nodes[i].NodeFont.Bold == true)   //已显示
                {
                    treeView1.Nodes[i].NodeFont = new Font("宋体", 9, FontStyle.Regular);
                    ((chain_path)(treeView1.Nodes[i].Tag)).ShowOffSensorOnPath();
                }
            treeView1.EndUpdate();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.BeginUpdate();
            if (e.Node.Level == 0)
            {
                if (e.Node.NodeFont.Bold == true)   //已显示
                {
                    e.Node.NodeFont = new Font("宋体", 9, FontStyle.Regular);
                    ((chain_path)(e.Node.Tag)).ShowOffSensorOnPath();
                }
                else
                {
                    e.Node.NodeFont = new Font("宋体", 9, FontStyle.Bold);
                    ((chain_path)(e.Node.Tag)).ShowOnSensorOnPath();
                }
            }
            treeView1.EndUpdate();
        }
    }
}

