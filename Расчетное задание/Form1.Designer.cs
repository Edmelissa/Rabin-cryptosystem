
namespace Расчетное_задание
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.задатьОграниченияПарольнойФразыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GB_Enc_Dec = new System.Windows.Forms.GroupBox();
            this.GB_Info = new System.Windows.Forms.GroupBox();
            this.CB_Password = new System.Windows.Forms.CheckBox();
            this.Lab_File = new System.Windows.Forms.Label();
            this.But_Action = new System.Windows.Forms.Button();
            this.TB_Info = new System.Windows.Forms.TextBox();
            this.RB_TextBox = new System.Windows.Forms.RadioButton();
            this.RB_File = new System.Windows.Forms.RadioButton();
            this.RB_Dec = new System.Windows.Forms.RadioButton();
            this.RB_Enc = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.GB_Enc_Dec.SuspendLayout();
            this.GB_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(13, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(882, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.задатьОграниченияПарольнойФразыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // задатьОграниченияПарольнойФразыToolStripMenuItem
            // 
            this.задатьОграниченияПарольнойФразыToolStripMenuItem.Name = "задатьОграниченияПарольнойФразыToolStripMenuItem";
            this.задатьОграниченияПарольнойФразыToolStripMenuItem.Size = new System.Drawing.Size(352, 26);
            this.задатьОграниченияПарольнойФразыToolStripMenuItem.Text = "Задать параметры парольной фразы";
            this.задатьОграниченияПарольнойФразыToolStripMenuItem.Click += new System.EventHandler(this.задатьОграниченияПарольнойФразыToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(352, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // GB_Enc_Dec
            // 
            this.GB_Enc_Dec.Controls.Add(this.GB_Info);
            this.GB_Enc_Dec.Controls.Add(this.RB_Dec);
            this.GB_Enc_Dec.Controls.Add(this.RB_Enc);
            this.GB_Enc_Dec.Location = new System.Drawing.Point(10, 40);
            this.GB_Enc_Dec.Name = "GB_Enc_Dec";
            this.GB_Enc_Dec.Size = new System.Drawing.Size(860, 500);
            this.GB_Enc_Dec.TabIndex = 1;
            this.GB_Enc_Dec.TabStop = false;
            this.GB_Enc_Dec.Text = "Режим работы";
            // 
            // GB_Info
            // 
            this.GB_Info.Controls.Add(this.CB_Password);
            this.GB_Info.Controls.Add(this.Lab_File);
            this.GB_Info.Controls.Add(this.But_Action);
            this.GB_Info.Controls.Add(this.TB_Info);
            this.GB_Info.Controls.Add(this.RB_TextBox);
            this.GB_Info.Controls.Add(this.RB_File);
            this.GB_Info.Location = new System.Drawing.Point(6, 107);
            this.GB_Info.Name = "GB_Info";
            this.GB_Info.Size = new System.Drawing.Size(848, 387);
            this.GB_Info.TabIndex = 2;
            this.GB_Info.TabStop = false;
            this.GB_Info.Text = "Формат данных";
            // 
            // CB_Password
            // 
            this.CB_Password.AutoSize = true;
            this.CB_Password.Location = new System.Drawing.Point(484, 53);
            this.CB_Password.Name = "CB_Password";
            this.CB_Password.Size = new System.Drawing.Size(358, 31);
            this.CB_Password.TabIndex = 5;
            this.CB_Password.Text = "Использовать парольную фразу";
            this.CB_Password.UseVisualStyleBackColor = true;
            this.CB_Password.CheckedChanged += new System.EventHandler(this.CB_Password_CheckedChanged);
            // 
            // Lab_File
            // 
            this.Lab_File.Location = new System.Drawing.Point(125, 35);
            this.Lab_File.Name = "Lab_File";
            this.Lab_File.Size = new System.Drawing.Size(328, 29);
            this.Lab_File.TabIndex = 4;
            // 
            // But_Action
            // 
            this.But_Action.Location = new System.Drawing.Point(325, 340);
            this.But_Action.Name = "But_Action";
            this.But_Action.Size = new System.Drawing.Size(180, 38);
            this.But_Action.TabIndex = 3;
            this.But_Action.Text = "Действие";
            this.But_Action.UseVisualStyleBackColor = true;
            this.But_Action.Click += new System.EventHandler(this.But_Action_Click);
            // 
            // TB_Info
            // 
            this.TB_Info.Location = new System.Drawing.Point(6, 107);
            this.TB_Info.MaxLength = 10000000;
            this.TB_Info.Multiline = true;
            this.TB_Info.Name = "TB_Info";
            this.TB_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Info.Size = new System.Drawing.Size(836, 220);
            this.TB_Info.TabIndex = 2;
            // 
            // RB_TextBox
            // 
            this.RB_TextBox.AutoSize = true;
            this.RB_TextBox.Location = new System.Drawing.Point(6, 70);
            this.RB_TextBox.Name = "RB_TextBox";
            this.RB_TextBox.Size = new System.Drawing.Size(189, 31);
            this.RB_TextBox.TabIndex = 1;
            this.RB_TextBox.TabStop = true;
            this.RB_TextBox.Text = "Текстовое поле";
            this.RB_TextBox.UseVisualStyleBackColor = true;
            this.RB_TextBox.CheckedChanged += new System.EventHandler(this.RB_TextBox_CheckedChanged);
            // 
            // RB_File
            // 
            this.RB_File.AutoSize = true;
            this.RB_File.Location = new System.Drawing.Point(6, 33);
            this.RB_File.Name = "RB_File";
            this.RB_File.Size = new System.Drawing.Size(87, 31);
            this.RB_File.TabIndex = 0;
            this.RB_File.TabStop = true;
            this.RB_File.Text = "Файл";
            this.RB_File.UseVisualStyleBackColor = true;
            this.RB_File.CheckedChanged += new System.EventHandler(this.RB_File_CheckedChanged);
            // 
            // RB_Dec
            // 
            this.RB_Dec.AutoSize = true;
            this.RB_Dec.Location = new System.Drawing.Point(6, 70);
            this.RB_Dec.Name = "RB_Dec";
            this.RB_Dec.Size = new System.Drawing.Size(264, 31);
            this.RB_Dec.TabIndex = 1;
            this.RB_Dec.TabStop = true;
            this.RB_Dec.Text = "Расшифровать данные";
            this.RB_Dec.UseVisualStyleBackColor = true;
            this.RB_Dec.CheckedChanged += new System.EventHandler(this.RB_Dec_CheckedChanged);
            // 
            // RB_Enc
            // 
            this.RB_Enc.AutoSize = true;
            this.RB_Enc.Location = new System.Drawing.Point(6, 33);
            this.RB_Enc.Name = "RB_Enc";
            this.RB_Enc.Size = new System.Drawing.Size(234, 31);
            this.RB_Enc.TabIndex = 0;
            this.RB_Enc.TabStop = true;
            this.RB_Enc.Text = "Шифровать данные";
            this.RB_Enc.UseVisualStyleBackColor = true;
            this.RB_Enc.CheckedChanged += new System.EventHandler(this.RB_Enc_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Расчетное_задание.Properties.Resources.Back;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.GB_Enc_Dec);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "Расчетное задание";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GB_Enc_Dec.ResumeLayout(false);
            this.GB_Enc_Dec.PerformLayout();
            this.GB_Info.ResumeLayout(false);
            this.GB_Info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.GroupBox GB_Enc_Dec;
        private System.Windows.Forms.GroupBox GB_Info;
        private System.Windows.Forms.TextBox TB_Info;
        private System.Windows.Forms.RadioButton RB_TextBox;
        private System.Windows.Forms.RadioButton RB_File;
        private System.Windows.Forms.RadioButton RB_Dec;
        private System.Windows.Forms.RadioButton RB_Enc;
        private System.Windows.Forms.Button But_Action;
        private System.Windows.Forms.Label Lab_File;
        private System.Windows.Forms.ToolStripMenuItem задатьОграниченияПарольнойФразыToolStripMenuItem;
        private System.Windows.Forms.CheckBox CB_Password;
    }
}

