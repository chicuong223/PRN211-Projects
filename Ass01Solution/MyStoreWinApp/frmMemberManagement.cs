using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        public frmMemberManagement()
        {
            InitializeComponent();
        }

        //public IMemberRepository Repository { get; set; }
        public IMemberRepository Repository = new MemberRepository();
        private BindingSource source;
        public MemberObject login { get; set; }

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            if (login.MemberID != 0)
            {
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                panelFilter.Enabled = false;
                panelSearch.Enabled = false;
            }
            LoadMemberList();
            AddCountriesToCbo();
            cboCountries.SelectedIndex = 0;
            cboSearchType.SelectedIndex = 0;
            cboSort.SelectedIndex = 0;
        }

        private void LoadMemberList()
        {
            try
            {
                source = new BindingSource();
                if(login.MemberID != 0)
                {
                    source.DataSource = Repository.GetMemberByID(login.MemberID);
                }
                else
                {
                    var memberLst = Repository.GetMembers();
                    if (memberLst.Count() < 1)
                    {
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                    }
                    source.DataSource = memberLst;
                }
                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Members");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Add a member",
                InsertOrUpdate = false,
                Repository = Repository
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
            }
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberObject mem = GetMember();
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Update Member's Info",
                MemberInfo = mem,
                InsertOrUpdate = true,
                Repository = Repository
            };
            frmMemberDetails.Show();

            if (frmMemberDetails.DialogResult == DialogResult.OK)
            {
                LoadMemberList();
            }
        }

        private void FilterCity()
        {
            //source = new BindingSource();
            source.DataSource = Repository.FilterMembersByCity(cboCities.Text);
            //dgvMemberList.DataSource = null;
            //dgvMemberList.DataSource = source;
        }

        private void FilterCountry()
        {
            source.DataSource = Repository.FilterMembersByCountry(cboCountries.Text);
        }

        private void AddCountriesToCbo()
        {
            cboCountries.Items.Add("(All)");
            foreach (string country in Repository.GetCountries())
            {
                cboCountries.Items.Add(country);
            }
        }

        private void cboCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCities.Items.Clear();
            cboCities.Text = "";
            if (cboCountries.SelectedIndex == 0)
            {
                LoadMemberList();
            }
            else
            {
                FilterCountry();
                cboCities.Items.Clear();
                cboCities.Text = "";
                foreach (string city in Repository.GetCities(cboCountries.Text))
                {
                    cboCities.Items.Add(city);
                }
            }
        }

        private void cboCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCity();
        }

        private MemberObject GetMemberID()
        {
            return Repository.GetMemberByID(int.Parse(txtSearch.Text));
        }

        private MemberObject GetMember()
        {
            return (MemberObject)dgvMemberList.SelectedRows[0].DataBoundItem;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MemberObject mem = GetMember();
                Repository.DeleteMember(mem.MemberID);
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cboCountries.SelectedIndex = 0;
            try
            {
                if (cboSearchType.SelectedIndex == 0)
                {
                    if (!int.TryParse(txtSearch.Text, out _))
                    {
                        throw new Exception("ID must be an integer");
                    }
                    MemberObject mem = GetMemberID();
                    if (mem == null)
                    {
                        throw new Exception("Member ID not found!");
                    }
                    foreach (DataGridViewRow row in dgvMemberList.Rows)
                    {
                        if (row.Cells[0].Value.Equals(mem.MemberID))
                        {
                            row.Selected = true;
                            dgvMemberList.FirstDisplayedScrollingRowIndex = row.Index;
                        }
                        else
                        {
                            row.Selected = false;
                        }
                    }
                }
                else
                {
                    IEnumerable<MemberObject> memList = Repository.GetMembersByName(txtSearch.Text);
                    if(memList.Count() < 1)
                    {
                        throw new Exception("Name not found");
                    }
                    source.DataSource = memList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSearch.Text = cboSearchType.Text;
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cboCountries.SelectedIndex = 0;
            cboSearchType.SelectedIndex = 0;
            txtSearch.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(() =>
            {
                {
                    Application.Run(new frmLogin
                    {
                        Text = "Login",
                    });
                }
            });
            th.Start();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repository.Sort(cboSort.SelectedIndex);
            LoadMemberList();
        }
    }
}
