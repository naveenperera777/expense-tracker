namespace Expense_Manager.View
{
    partial class AddCategory
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
            System.Windows.Forms.TextBox textBox2;
            this.label1 = new System.Windows.Forms.Label();
            this.categoryNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.incomeButton = new System.Windows.Forms.RadioButton();
            this.expenseButton = new System.Windows.Forms.RadioButton();
            this.Limit = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(287, 165);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(165, 20);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // categoryNameInput
            // 
            this.categoryNameInput.Location = new System.Drawing.Point(287, 76);
            this.categoryNameInput.Name = "categoryNameInput";
            this.categoryNameInput.Size = new System.Drawing.Size(165, 20);
            this.categoryNameInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // incomeButton
            // 
            this.incomeButton.AutoSize = true;
            this.incomeButton.Location = new System.Drawing.Point(287, 113);
            this.incomeButton.Name = "incomeButton";
            this.incomeButton.Size = new System.Drawing.Size(60, 17);
            this.incomeButton.TabIndex = 3;
            this.incomeButton.TabStop = true;
            this.incomeButton.Text = "Income";
            this.incomeButton.UseVisualStyleBackColor = true;
            this.incomeButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // expenseButton
            // 
            this.expenseButton.AutoSize = true;
            this.expenseButton.Location = new System.Drawing.Point(287, 136);
            this.expenseButton.Name = "expenseButton";
            this.expenseButton.Size = new System.Drawing.Size(66, 17);
            this.expenseButton.TabIndex = 4;
            this.expenseButton.TabStop = true;
            this.expenseButton.Text = "Expense";
            this.expenseButton.UseVisualStyleBackColor = true;
            // 
            // Limit
            // 
            this.Limit.AutoSize = true;
            this.Limit.Location = new System.Drawing.Point(174, 165);
            this.Limit.Name = "Limit";
            this.Limit.Size = new System.Drawing.Size(28, 13);
            this.Limit.TabIndex = 5;
            this.Limit.Text = "Limit";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Limit);
            this.Controls.Add(this.expenseButton);
            this.Controls.Add(this.incomeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryNameInput);
            this.Controls.Add(this.label1);
            this.Name = "AddCategory";
            this.Text = "AddCategory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox categoryNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton incomeButton;
        private System.Windows.Forms.RadioButton expenseButton;
        private System.Windows.Forms.Label Limit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}