
namespace WinFormDemo
{
    partial class DataGridViewForm
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnDataTable = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(132, 85);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.Size = new System.Drawing.Size(395, 160);
            this.dgvProducts.TabIndex = 0;
            // 
            // btnDataTable
            // 
            this.btnDataTable.Location = new System.Drawing.Point(67, 376);
            this.btnDataTable.Name = "btnDataTable";
            this.btnDataTable.Size = new System.Drawing.Size(160, 23);
            this.btnDataTable.TabIndex = 1;
            this.btnDataTable.Text = "Binding with Data Table";
            this.btnDataTable.UseVisualStyleBackColor = true;
            this.btnDataTable.Click += new System.EventHandler(this.btnDataTable_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(306, 376);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(177, 23);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "Binding with List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // DataGridViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnDataTable);
            this.Controls.Add(this.dgvProducts);
            this.Name = "DataGridViewForm";
            this.Text = "DataGridViewForm";
            this.Load += new System.EventHandler(this.DataGridViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnDataTable;
        private System.Windows.Forms.Button btnList;
    }
}