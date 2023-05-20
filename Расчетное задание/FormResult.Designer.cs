
namespace Расчетное_задание
{
    partial class FormResult
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
            this.TB_Result = new System.Windows.Forms.TextBox();
            this.But_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_Result
            // 
            this.TB_Result.Location = new System.Drawing.Point(12, 12);
            this.TB_Result.MaxLength = 10000000;
            this.TB_Result.Multiline = true;
            this.TB_Result.Name = "TB_Result";
            this.TB_Result.ReadOnly = true;
            this.TB_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Result.Size = new System.Drawing.Size(560, 290);
            this.TB_Result.TabIndex = 3;
            // 
            // But_Save
            // 
            this.But_Save.Location = new System.Drawing.Point(200, 308);
            this.But_Save.Name = "But_Save";
            this.But_Save.Size = new System.Drawing.Size(180, 38);
            this.But_Save.TabIndex = 4;
            this.But_Save.Text = "Сохранить";
            this.But_Save.UseVisualStyleBackColor = true;
            this.But_Save.Click += new System.EventHandler(this.But_Save_Click);
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.But_Save);
            this.Controls.Add(this.TB_Result);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormResult";
            this.Text = "Результат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button But_Save;
        public System.Windows.Forms.TextBox TB_Result;
    }
}