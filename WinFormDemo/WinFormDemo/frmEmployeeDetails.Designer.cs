
namespace WinFormDemo
{
    partial class frmEmployeeDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbEmpID = new System.Windows.Forms.Label();
            this.lbEmpName = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.lbDegree = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.gboGender = new System.Windows.Forms.GroupBox();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.cboDegree = new System.Windows.Forms.ComboBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.gboGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.Location = new System.Drawing.Point(148, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Padding = new System.Windows.Forms.Padding(10);
            this.lbTitle.Size = new System.Drawing.Size(202, 52);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Employee Details";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbTitle.UseMnemonic = false;
            this.lbTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbEmpID
            // 
            this.lbEmpID.AutoSize = true;
            this.lbEmpID.Location = new System.Drawing.Point(71, 94);
            this.lbEmpID.Name = "lbEmpID";
            this.lbEmpID.Size = new System.Drawing.Size(66, 15);
            this.lbEmpID.TabIndex = 1;
            this.lbEmpID.Text = "Emplyee ID";
            this.lbEmpID.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbEmpName
            // 
            this.lbEmpName.AutoSize = true;
            this.lbEmpName.Location = new System.Drawing.Point(71, 128);
            this.lbEmpName.Name = "lbEmpName";
            this.lbEmpName.Size = new System.Drawing.Size(94, 15);
            this.lbEmpName.TabIndex = 2;
            this.lbEmpName.Text = "Employee Name";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(71, 164);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(41, 15);
            this.lbPhone.TabIndex = 3;
            this.lbPhone.Text = "Phone";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Location = new System.Drawing.Point(71, 202);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(45, 15);
            this.lbGender.TabIndex = 4;
            this.lbGender.Text = "Gender";
            // 
            // lbDegree
            // 
            this.lbDegree.AutoSize = true;
            this.lbDegree.Location = new System.Drawing.Point(71, 239);
            this.lbDegree.Name = "lbDegree";
            this.lbDegree.Size = new System.Drawing.Size(44, 15);
            this.lbDegree.TabIndex = 5;
            this.lbDegree.Text = "Degree";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(181, 91);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(212, 23);
            this.txtEmpID.TabIndex = 6;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(181, 125);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(212, 23);
            this.txtEmpName.TabIndex = 7;
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(181, 161);
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(212, 23);
            this.mtxtPhone.TabIndex = 8;
            // 
            // gboGender
            // 
            this.gboGender.Controls.Add(this.rdFemale);
            this.gboGender.Controls.Add(this.rdMale);
            this.gboGender.Location = new System.Drawing.Point(181, 190);
            this.gboGender.Name = "gboGender";
            this.gboGender.Size = new System.Drawing.Size(212, 37);
            this.gboGender.TabIndex = 9;
            this.gboGender.TabStop = false;
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Location = new System.Drawing.Point(118, 12);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(63, 19);
            this.rdFemale.TabIndex = 10;
            this.rdFemale.TabStop = true;
            this.rdFemale.Text = "Female";
            this.rdFemale.UseVisualStyleBackColor = true;
            this.rdFemale.CheckedChanged += new System.EventHandler(this.rdFemale_CheckedChanged);
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Location = new System.Drawing.Point(0, 12);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(51, 19);
            this.rdMale.TabIndex = 0;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            this.rdMale.UseVisualStyleBackColor = true;
            this.rdMale.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // cboDegree
            // 
            this.cboDegree.FormattingEnabled = true;
            this.cboDegree.Items.AddRange(new object[] {
            "Ph. D.",
            "Master",
            "Engineer",
            "Bachelor",
            "Technician"});
            this.cboDegree.Location = new System.Drawing.Point(181, 236);
            this.cboDegree.Name = "cboDegree";
            this.cboDegree.Size = new System.Drawing.Size(212, 23);
            this.cboDegree.TabIndex = 11;
            this.cboDegree.Text = "-- Select Degree --";
            this.cboDegree.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("Laura");
            this.domainUpDown1.Items.Add("Jason");
            this.domainUpDown1.Items.Add("Bruce");
            this.domainUpDown1.Items.Add("Lara");
            this.domainUpDown1.Items.Add("Maureen");
            this.domainUpDown1.Items.Add("Joshua");
            this.domainUpDown1.Items.Add("Oliver");
            this.domainUpDown1.Location = new System.Drawing.Point(181, 274);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(212, 23);
            this.domainUpDown1.TabIndex = 12;
            this.domainUpDown1.Text = "domainUpDown1";
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // frmEmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 318);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.cboDegree);
            this.Controls.Add(this.gboGender);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.lbDegree);
            this.Controls.Add(this.lbGender);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbEmpName);
            this.Controls.Add(this.lbEmpID);
            this.Controls.Add(this.lbTitle);
            this.Name = "frmEmployeeDetails";
            this.Text = "frmEmployee";
            this.gboGender.ResumeLayout(false);
            this.gboGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbEmpID;
        private System.Windows.Forms.Label lbEmpName;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.Label lbDegree;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.GroupBox gboGender;
        private System.Windows.Forms.RadioButton rdFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.ComboBox cboDegree;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
    }
}