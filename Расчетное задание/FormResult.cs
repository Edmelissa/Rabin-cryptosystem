using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Расчетное_задание
{
    public partial class FormResult : Form
    {
        public Encoding enc_un = Encoding.Unicode;

        public FormResult()
        {
            InitializeComponent();
        }

        private void But_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Результат не сохранен");
                return;
            }
            else
            {
                string namefile = sfd.FileName;

                using (StreamWriter sw = new StreamWriter(namefile, false, enc_un))
                {
                    sw.WriteLine(TB_Result.Text);
                    Close();
                }
            }


        }
    }
}
