using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De1_Form
{
    static class Program
    {
        //Them: lan anh
        //xoa + help : nhung
        //tim kiem : diep
        //sua : lan
        //dang nhap + ghep noi : hue
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
