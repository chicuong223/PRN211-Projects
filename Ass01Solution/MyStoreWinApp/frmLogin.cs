using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }
        public IMemberRepository Repository = new MemberRepository();
        private MemberObject login;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Please enter email");
                return;
            }
            if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Please enter password");
                return;
            }
            login = Repository.CheckLogin(txtEmail.Text, txtPassword.Text);
            if(login != null)
            {
                this.Close();
                Thread th = new Thread(OpenForm);
                th.Start();
            }
            else
            {
                MessageBox.Show("Incorrect email or password");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void OpenForm()
        {
            Application.Run(new frmMemberManagement
            {
                Text = "Members Management",
                Repository = Repository,
                login = login
            });
        }
    }
}
