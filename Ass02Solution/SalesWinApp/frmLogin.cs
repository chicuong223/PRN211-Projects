using BusinessObjects;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        private IMemberRepository repository = new MemberRepository();
        public Member member;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Member mem = repository.CheckLogin(txtEmail.Text, txtPassword.Text);
                member = mem;
                Close();
            }
            catch(Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Incorrect Email or Password", ex.Message);
            }
        }

    }
}
