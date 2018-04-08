using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STK_demonstration
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            //Application.Run(new Form1());//已被while替换，为了能处理RTI的消息
            MFrm frm = new MFrm();
            frm.Show();
            System.Threading.Thread.CurrentThread.Name = "MainThread";
            while (frm.Created)
            {
                if (frm.simulation != null)
                    frm.DoSimulation();
                Application.DoEvents();
                System.Threading.Thread.Sleep(20);//important!防止while循环占用CPU过高
            }
        }
    }
}
