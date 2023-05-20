using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace Расчетное_задание
{   
    public partial class FormPassword : Form
    {
        public MainForm mf;

        public FormPassword()
        {
            InitializeComponent();
        }

        private void But_Action_Click(object sender, EventArgs e)
        {
            string password = TB_Pas.Text.Trim();
            string password_conf = TB_Conf.Text.Trim();

            if(password == password_conf)
            {
                if(password != "")
                {
                    if (password.Length == mf.Pass_Len)
                    {
                        if (mf.Is_Kir)
                        {
                            Regex regex = new Regex(@"[А-Яа-яЁё]");
                            MatchCollection matches = regex.Matches(password);
                            if (matches.Count == 0)
                            {
                                MessageBox.Show("Пароль не содержит символов кириллицы");
                                return;
                            }                  
                        } 
                        
                        if (mf.Is_Lat)
                        {
                            Regex regex = new Regex(@"[A-Za-z]");
                            MatchCollection matches = regex.Matches(password);
                            if (matches.Count == 0)
                            {
                                MessageBox.Show("Пароль не содержит символов латиницы");
                                return;
                            }
                        }

                        if (mf.Is_Num)
                        {
                            Regex regex = new Regex(@"[0-9]");
                            MatchCollection matches = regex.Matches(password);
                            if (matches.Count == 0)
                            {
                                MessageBox.Show("Пароль не содержит цифры");
                                return;
                            }
                        }

                        if (mf.Is_Spec)
                        {
                            Regex regex = new Regex(@"[\\!$%&'()*+,\-./:;<=>?@[ \]^_`{|}~# ]");
                            MatchCollection matches = regex.Matches(password);
                            if (matches.Count == 0)
                            {
                                MessageBox.Show("Пароль не содержит специальные символы");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не соответствует длине " + mf.Pass_Len);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Пароль не может быть пустой строкой");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Пароль и подтверждение не совпадают");
                return;
            }

            mf.password = password;
            MessageBox.Show("Пароль задан");
            Close();
        }
    }
}
