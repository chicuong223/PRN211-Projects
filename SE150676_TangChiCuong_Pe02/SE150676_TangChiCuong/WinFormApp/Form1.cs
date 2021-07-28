using FacultyAssemblies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        private BindingSource source = null;
        public FacultyDAO dao = new FacultyDAO();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Faculty fa = new Faculty();
            List<Faculty> lst = dao.GetAll();
            if (lst.Count() <= 0)
                fa.FacultyId = 1;
            else
                fa.FacultyId = lst.Max(f => f.FacultyId) + 1;
            frmAdd frm = new frmAdd
            {
                fa = fa
            };
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                LoadList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Faculty fa = (Faculty)dgvFaculties.CurrentRow.DataBoundItem;
                dao.Delete(fa.FacultyId);
                MessageBox.Show("Deleted Successfully", "Delete Faculty");
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<Faculty> lst = dao.Search(txtSearch.Text);
                if (lst.Count() <= 0)
                    throw new Exception("Not found");
                //source = null;
                source.DataSource = lst;
                dgvFaculties.DataSource = source;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Search");
            }
        }

        private void LoadList()
        {
            source = new BindingSource();
            List<Faculty> lst = dao.GetAll();
            source.DataSource = lst;
            dgvFaculties.DataSource = null;
            dgvFaculties.DataSource = source;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
