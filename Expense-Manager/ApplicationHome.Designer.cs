namespace Expense_Manager
{
    partial class ApplicationHome
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
            this.categoryViewBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryViewBtn
            // 
            this.categoryViewBtn.Location = new System.Drawing.Point(38, 50);
            this.categoryViewBtn.Name = "categoryViewBtn";
            this.categoryViewBtn.Size = new System.Drawing.Size(245, 96);
            this.categoryViewBtn.TabIndex = 0;
            this.categoryViewBtn.Text = "Category";
            this.categoryViewBtn.UseVisualStyleBackColor = true;
            this.categoryViewBtn.Click += new System.EventHandler(this.categoryViewBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 91);
            this.button2.TabIndex = 1;
            this.button2.Text = "Transactions";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(38, 194);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(245, 96);
            this.reportBtn.TabIndex = 2;
            this.reportBtn.Text = "Reports";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 91);
            this.button1.TabIndex = 3;
            this.button1.Text = "Predictions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 677);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.categoryViewBtn);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button categoryViewBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Button button1;
    }
}