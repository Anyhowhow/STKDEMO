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
    public partial class picture_form : Form
    {
        public picture_form()
        {
            InitializeComponent();
        }
        public void ShowPicture(string filepath)
        {
            if (filepath != string.Empty)
            {
                try
                {
                    //this.pictureBox1.Load(pathname);
                    //通过输入文件目录，文件模式，访问模式等参数，通过流打开文件
                    FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    //通过调用系统的画笔工具，画出一个Image类型的数据，传给pictureBox。
                    Image im = System.Drawing.Bitmap.FromStream(fs);
                    pictureBox1.Image = im;
                    ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
