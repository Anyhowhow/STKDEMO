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
    public partial class Django : Form
    {
        public MFrm view;
        public Django(MFrm fm)
        {
            view = fm;
            InitializeComponent();
        }
        /// <summary>
        /// 用来添加一个sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int sensorsize;
            if (radioButton1.Checked)
                sensorsize = 53;
            else
                sensorsize = 57;
            try
            {
                string a = string.Format("New / */Satellite/{0}/Sensor sens1", textBox1.Text);
                string b = string.Format("Define */Satellite/{0}/Sensor/sens1 SimpleCone {1}", textBox1.Text, sensorsize);
                view.root.ExecuteCommand(a);
                view.root.ExecuteCommand(b);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"请按照操作规范来进行操作");
            }
        }
        /// <summary>
        /// 用来移除一个sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                view.root.ExecuteCommand(string.Format("Unload / */Satellite/{0}/Sensor/sens1", textBox1.Text));
            }
            catch
            {
                MessageBox.Show("请按照操作规范来进行操作");
            }
        }
    }
}
