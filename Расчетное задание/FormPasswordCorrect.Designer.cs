
namespace Расчетное_задание
{
    partial class FormPasswordCorrect
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
            this.Lab_Pas = new System.Windows.Forms.Label();
            this.TB_Pas = new System.Windows.Forms.TextBox();
            this.But_Action = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lab_Pas
            // 
            this.Lab_Pas.AutoSize = true;
            this.Lab_Pas.Location = new System.Drawing.Point(12, 19);
            this.Lab_Pas.Name = "Lab_Pas";
            this.Lab_Pas.Size = new System.Drawing.Size(87, 27);
            this.Lab_Pas.TabIndex = 1;
            this.Lab_Pas.Text = "Пароль";
            // 
            // TB_Pas
            // 
            this.TB_Pas.Location = new System.Drawing.Point(207, 16);
            this.TB_Pas.Name = "TB_Pas";
            this.TB_Pas.PasswordChar = '*';
            this.TB_Pas.Size = new System.Drawing.Size(265, 34);
            this.TB_Pas.TabIndex = 3;
            // 
            // But_Action
            // 
            this.But_Action.Location = new System.Drawing.Point(133, 59);
            this.But_Action.Name = "But_Action";
            this.But_Action.Size = new System.Drawing.Size(200, 32);
            this.But_Action.TabIndex = 5;
            this.But_Action.Text = "ОК";
            this.But_Action.UseVisualStyleBackColor = true;
            this.But_Action.Click += new System.EventHandler(this.But_Action_Click);
            // 
            // FormPasswordCorrect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(482, 103);
            this.Controls.Add(this.But_Action);
            this.Controls.Add(this.TB_Pas);
            this.Controls.Add(this.Lab_Pas);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FormPasswordCorrect";
            this.Text = "Проверка парольной фразы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab_Pas;
        private System.Windows.Forms.TextBox TB_Pas;
        private System.Windows.Forms.Button But_Action;
    }
}