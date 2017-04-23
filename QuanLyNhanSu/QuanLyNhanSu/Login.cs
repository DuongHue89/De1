using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //   Load += Form3_Load;
            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += BtnExit_Click;
        }
        //Click Exit
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Click Login
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //if(txtUser.Text==user && txtPassword.Text == password)
            //{
            //    Form_Main form1 = new Form_Main();
            //    Visible = false;
            //    form1.ShowDialog();
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid user name or password!");
            //}

            Form_Main form1 = new Form_Main();
            Visible = false;
            form1.ShowDialog();
            Close();
        }

    }
}
