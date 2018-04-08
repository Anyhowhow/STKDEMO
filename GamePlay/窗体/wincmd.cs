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
    public partial class wincmd : Form
    {
        public MFrm father;
        public wincmd(MFrm view)
        {
            father = view;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.father.root.ExecuteCommand(textBox1.Text);
                richTextBox1.Text = "cmd right";
            }
            catch(Exception er)
            {
                this.richTextBox1.Text = string.Format("cmd error:{0}", er);
            }
        }

        private void wincmd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
