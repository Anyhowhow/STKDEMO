using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace STK_demonstration
{
    public partial class WaitForm : Form
    {
        public string buttonClicked = null;
        public WaitForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            buttonClicked = "buttonYes";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            buttonClicked = "buttonNo";
        }
    }
}
