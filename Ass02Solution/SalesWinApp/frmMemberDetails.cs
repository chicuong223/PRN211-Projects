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
    public partial class frmMemberDetails : Form
    {
        public frmMemberDetails()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }
        public IMemberRepository Repository { get; set; }
        public bool InsertOrUpdate { get; set; }    //False: insert, True: Update
        public Member MemberInfo { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    throw new ArgumentException("Confirm password did not match");
                }
                Member mem = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    CompanyName = txtCompanyName.Text,
                    Email = txtEmail.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                if (InsertOrUpdate == false)
                {
                    Repository.AddMember(mem);
                }
                else
                {
                    Repository.UpdateMember(mem);
                }
                MemberInfo = mem;
                MessageBox.Show((InsertOrUpdate == false ? "Insert " : "Update ") + "Successfully");
                this.Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message, (InsertOrUpdate == false) ? "Add new Member" : "Update Member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberID.Enabled = !InsertOrUpdate;
            txtEmail.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberID.Text = MemberInfo.MemberId.ToString();
                txtCompanyName.Text = MemberInfo.CompanyName;
                txtEmail.Text = MemberInfo.Email;
                txtCountry.Text = MemberInfo.Country;
                txtCity.Text = MemberInfo.City;
                txtPassword.Text = MemberInfo.Password;
                txtConfirmPassword.Text = "";
            }
        }
    }
}
