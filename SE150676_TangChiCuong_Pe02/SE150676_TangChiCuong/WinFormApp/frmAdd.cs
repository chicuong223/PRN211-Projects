using FacultyAssemblies;
using System;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class frmAdd : Form
    {
        public Faculty fa { get; set; }
        public FacultyDAO dao = new FacultyDAO();
        public frmAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string age = txtAge.Text;
                string addr = txtAddr.Text;
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(age) || string.IsNullOrWhiteSpace(addr))
                    throw new Exception("Please fill in all fields");
                if (int.TryParse(age, out _) == false)
                    throw new Exception("Age must be an integer");
                Faculty f = new Faculty
                {
                    FacultyId = int.Parse(txtID.Text),
                    FullName = name,
                    Age = int.Parse(age),
                    Address = addr
                };
                dao.Add(f);
                MessageBox.Show("Added successfully", "Add");
                this.Close();
            }
            catch(Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message, "Error Adding");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            txtID.Text = fa.FacultyId.ToString();
            txtID.Enabled = false;
        }
    }
}
