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
    public partial class frmMembers : Form
    {
        public MemberRepository repo = new MemberRepository();
        private BindingSource source;
        public frmMembers()
        {
            InitializeComponent();
        }

        private void LoadMembers()
        {
            var lst = repo.GetMembers();
            source = new BindingSource();
            source.DataSource = lst;
            dgvList.DataSource = null;
            dgvList.DataSource = source;
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            LoadMembers();
            dgvList.Columns["Orders"].Visible = false;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Member Details",
                InsertOrUpdate = true,
                MemberInfo = (Member)dgvList.CurrentRow.DataBoundItem,
                Repository = repo
            };
            frmMemberDetails.ShowDialog();
            if (frmMemberDetails.DialogResult == DialogResult.OK)
            {
                Member mem = frmMemberDetails.MemberInfo;
                DataGridViewRow row = dgvList.CurrentRow;
                row.Cells["CompanyName"].Value = mem.CompanyName;
                row.Cells["Email"].Value = mem.Email;
                row.Cells["City"].Value = mem.City;
                row.Cells["Country"].Value = mem.Country;
                row.Cells["Password"].Value = mem.Password;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Member member = (Member)dgvList.CurrentRow.DataBoundItem;
            var result = MessageBox.Show("Are you sure ?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repo.DeleteMember(member);
                    dgvList.Rows.Remove(dgvList.CurrentRow);
                    MessageBox.Show("Member Is Removed", "Delete Member");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This member has at least 1 order\nCould not remove");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtID.Text, out _))
                {
                    throw new Exception("Input must be a number!");
                }
                Member member = repo.GetMemberByID(int.Parse(txtID.Text));
                DataGridViewRow row = dgvList.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => int.Parse(r.Cells["MemberId"].Value.ToString()) == member.MemberId)
                    .Single();
                dgvList.CurrentCell = row.Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
