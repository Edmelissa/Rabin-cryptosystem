using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Расчетное_задание
{
    public partial class PasswordParams : Form
    {
        public MainForm mf;
        public PasswordParams()
        {
            InitializeComponent();
        }

        private void But_Action_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TB_PasswordLen.Text, out int result))
            {
                if (Convert.ToInt32(TB_PasswordLen.Text) >= 5)
                {
                    mf.Is_Kir = CB_Kir.Checked;
                    mf.Is_Lat = CB_Lat.Checked;
                    mf.Is_Num = CB_Num.Checked;
                    mf.Is_Spec = CB_Spec.Checked;

                    mf.Pass_Len = Convert.ToInt32(TB_PasswordLen.Text);

                    MessageBox.Show("Параметры парольной фразы установлены");
                    Close();
                }
                else
                {
                    MessageBox.Show("Длина парольной фразы должна быть больше или равна 5");
                }
            }
            else
            {
                MessageBox.Show("Длина пароля - число типа int");
            }
        }
    }
}
