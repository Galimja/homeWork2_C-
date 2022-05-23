namespace HomeWork7_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonNewForm = new System.Windows.Forms.Button();
            this.labelUserNum = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonReset.Location = new System.Drawing.Point(217, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(113, 52);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "New game";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonNewForm
            // 
            this.buttonNewForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonNewForm.Location = new System.Drawing.Point(217, 85);
            this.buttonNewForm.Name = "buttonNewForm";
            this.buttonNewForm.Size = new System.Drawing.Size(113, 52);
            this.buttonNewForm.TabIndex = 2;
            this.buttonNewForm.Text = "Enter number";
            this.buttonNewForm.UseVisualStyleBackColor = true;
            this.buttonNewForm.Click += new System.EventHandler(this.buttonNewForm_Click);
            // 
            // labelUserNum
            // 
            this.labelUserNum.AutoSize = true;
            this.labelUserNum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUserNum.Location = new System.Drawing.Point(5, 43);
            this.labelUserNum.Name = "labelUserNum";
            this.labelUserNum.Size = new System.Drawing.Size(147, 21);
            this.labelUserNum.TabIndex = 3;
            this.labelUserNum.Text = "Введенное число:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCount.Location = new System.Drawing.Point(30, 102);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(122, 20);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Число попыток:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 183);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelUserNum);
            this.Controls.Add(this.buttonNewForm);
            this.Controls.Add(this.buttonReset);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonNewForm;
        private System.Windows.Forms.Label labelUserNum;
        private System.Windows.Forms.Label labelCount;
    }
}
