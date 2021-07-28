
namespace WinFormApp
{
    partial class frmAdd
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbAddr = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(112, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 23);
            this.txtID.TabIndex = 0;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(112, 114);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(100, 23);
            this.txtAddr.TabIndex = 1;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(112, 85);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 23);
            this.txtAge.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 23);
            this.txtName.TabIndex = 3;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(38, 30);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 15);
            this.lbID.TabIndex = 4;
            this.lbID.Text = "ID";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(38, 59);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 15);
            this.lbName.TabIndex = 5;
            this.lbName.Text = "Name";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Location = new System.Drawing.Point(38, 88);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(28, 15);
            this.lbAge.TabIndex = 6;
            this.lbAge.Text = "Age";
            // 
            // lbAddr
            // 
            this.lbAddr.AutoSize = true;
            this.lbAddr.Location = new System.Drawing.Point(38, 122);
            this.lbAddr.Name = "lbAddr";
            this.lbAddr.Size = new System.Drawing.Size(49, 15);
            this.lbAddr.TabIndex = 7;
            this.lbAddr.Text = "Address";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(38, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 202);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbAddr);
            this.Controls.Add(this.lbAge);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.txtID);
            this.Name = "frmAdd";
            this.Text = "frmAdd";
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbAddr;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}