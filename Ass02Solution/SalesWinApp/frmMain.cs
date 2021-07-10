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
    public partial class frmMain : Form
    {
        public Member member = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Add Member",
                InsertOrUpdate = false,
                Repository = new MemberRepository()
            };
            frmMemberDetails.MdiParent = this;
            frmMemberDetails.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(member.MemberId != 0)
            {
                frmMemberDetails frmMemberDetails = new frmMemberDetails
                {
                    InsertOrUpdate = true,
                    MemberInfo = member,
                    Repository = new MemberRepository()
                };
                frmMemberDetails.ShowDialog();
                if(frmMemberDetails.DialogResult == DialogResult.OK)
                {
                    member = frmMemberDetails.MemberInfo;
                }
            }
            else
            {
                frmMembers frmMembers = new frmMembers();
                frmMembers.MdiParent = this;
                frmMembers.Show();
            }
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductDetails productDetails = new frmProductDetails
            {
                Text = "Add a Product",
                InsertOrUpdate = false,
                product = new BusinessObjects.Product(),
                repo = new ProductRepository()
            };
            productDetails.MdiParent = this;
            productDetails.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProducts productsView = new frmProducts
            {
                Text = "View Products",
            };
            productsView.MdiParent = this;
            productsView.Show();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders();
            frmOrders.MdiParent = this;
            frmOrders.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private bool Login()
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
            if(login.DialogResult == DialogResult.OK)
            {
                this.member = login.member;
                return true;
            }
            return false;
        }

        private void viewSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportDate frm = new frmReportDate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ownOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport
            {
                member = this.member
            };
            frm.MdiParent = this;
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            member = null;
            LoadForm();
        }

        private void LoadForm(){
            menuStrip1.Enabled = false;
            if(Login() == true)
            {
                menuStrip1.Enabled = true;
            }
            if(!member.Email.Equals("admin@fstore.com"))
            {
                addMemberToolStripMenuItem.Enabled = false;
                productToolStripMenuItem.Enabled = false;
                manageToolStripMenuItem.Enabled = false;
                viewSalesReportToolStripMenuItem.Enabled = false;
            }
            else{
                addMemberToolStripMenuItem.Enabled = true;
                productToolStripMenuItem.Enabled = true;
                manageToolStripMenuItem.Enabled = true;
                viewSalesReportToolStripMenuItem.Enabled = true;
            }
        }
    }
}
