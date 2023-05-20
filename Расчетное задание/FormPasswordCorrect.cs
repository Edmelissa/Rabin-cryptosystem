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
    public partial class FormPasswordCorrect : Form
    {
        public MainForm mf;
        public FormPasswordCorrect()
        {
            InitializeComponent();
        }

        private void But_Action_Click(object sender, EventArgs e)
        {
            mf.cor_password = TB_Pas.Text;
            Close();
        }
    }
}
