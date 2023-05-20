
namespace Расчетное_задание
{
    partial class PasswordParams
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
            this.CB_Lat = new System.Windows.Forms.CheckBox();
            this.CB_Kir = new System.Windows.Forms.CheckBox();
            this.CB_Num = new System.Windows.Forms.CheckBox();
            this.CB_Spec = new System.Windows.Forms.CheckBox();
            this.TB_PasswordLen = new System.Windows.Forms.TextBox();
            this.Lab_PasswordLen = new System.Windows.Forms.Label();
            this.But_Action = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CB_Lat
            // 
            this.CB_Lat.AutoSize = true;
            this.CB_Lat.Location = new System.Drawing.Point(12, 12);
            this.CB_Lat.Name = "CB_Lat";
            this.CB_Lat.Size = new System.Drawing.Size(332, 31);
            this.CB_Lat.TabIndex = 0;
            this.CB_Lat.Text = "Наличие символов латиницы";
            this.CB_Lat.UseVisualStyleBackColor = true;
            // 
            // CB_Kir
            // 
            this.CB_Kir.AutoSize = true;
            this.CB_Kir.Location = new System.Drawing.Point(12, 49);
            this.CB_Kir.Name = "CB_Kir";
            this.CB_Kir.Size = new System.Drawing.Size(348, 31);
            this.CB_Kir.TabIndex = 1;
            this.CB_Kir.Text = "Наличие символов кириллицы";
            this.CB_Kir.UseVisualStyleBackColor = true;
            // 
            // CB_Num
            // 
            this.CB_Num.AutoSize = true;
            this.CB_Num.Location = new System.Drawing.Point(12, 86);
            this.CB_Num.Name = "CB_Num";
            this.CB_Num.Size = new System.Drawing.Size(183, 31);
            this.CB_Num.TabIndex = 2;
            this.CB_Num.Text = "Наличие цифр";
            this.CB_Num.UseVisualStyleBackColor = true;
            // 
            // CB_Spec
            // 
            this.CB_Spec.AutoSize = true;
            this.CB_Spec.Location = new System.Drawing.Point(12, 123);
            this.CB_Spec.Name = "CB_Spec";
            this.CB_Spec.Size = new System.Drawing.Size(368, 31);
            this.CB_Spec.TabIndex = 3;
            this.CB_Spec.Text = "Наличие специальных символов";
            this.CB_Spec.UseVisualStyleBackColor = true;
            // 
            // TB_PasswordLen
            // 
            this.TB_PasswordLen.Location = new System.Drawing.Point(291, 170);
            this.TB_PasswordLen.Name = "TB_PasswordLen";
            this.TB_PasswordLen.Size = new System.Drawing.Size(100, 34);
            this.TB_PasswordLen.TabIndex = 4;
            // 
            // Lab_PasswordLen
            // 
            this.Lab_PasswordLen.AutoSize = true;
            this.Lab_PasswordLen.Location = new System.Drawing.Point(12, 173);
            this.Lab_PasswordLen.Name = "Lab_PasswordLen";
            this.Lab_PasswordLen.Size = new System.Drawing.Size(262, 27);
            this.Lab_PasswordLen.TabIndex = 5;
            this.Lab_PasswordLen.Text = "Длина парольной фразы";
            // 
            // But_Action
            // 
            this.But_Action.Location = new System.Drawing.Point(138, 210);
            this.But_Action.Name = "But_Action";
            this.But_Action.Size = new System.Drawing.Size(136, 35);
            this.But_Action.TabIndex = 6;
            this.But_Action.Text = "Применить";
            this.But_Action.UseVisualStyleBackColor = true;
            this.But_Action.Click += new System.EventHandler(this.But_Action_Click);
            // 
            // PasswordParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(432, 253);
            this.Controls.Add(this.But_Action);
            this.Controls.Add(this.Lab_PasswordLen);
            this.Controls.Add(this.TB_PasswordLen);
            this.Controls.Add(this.CB_Spec);
            this.Controls.Add(this.CB_Num);
            this.Controls.Add(this.CB_Kir);
            this.Controls.Add(this.CB_Lat);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PasswordParams";
            this.Text = "Параметры парольной фразы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CB_Lat;
        private System.Windows.Forms.CheckBox CB_Kir;
        private System.Windows.Forms.CheckBox CB_Num;
        private System.Windows.Forms.CheckBox CB_Spec;
        private System.Windows.Forms.TextBox TB_PasswordLen;
        private System.Windows.Forms.Label Lab_PasswordLen;
        private System.Windows.Forms.Button But_Action;
    }
}