using QuanLyNhanSu.UC;
using System;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlMain.Controls.Add(new Personnel());
        }

        //Show Usercontrol lên panelmain
        private void showcontrol(System.Windows.Forms.Control object_)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(object_);
            object_.Dock = DockStyle.Fill;
        }
        //click vào các node của treeview
        private void tre_AfterSelect(object sender, TreeViewEventArgs e)
        {
            User_HuongDan us = new User_HuongDan();
            if (e.Node.Name == "huongdan")
            {
                showcontrol(us);
            }
            if (e.Node.Name == "chucnang")
            {
                Personnel per = new Personnel();
                showcontrol(per);
            }
        }
    }
}
