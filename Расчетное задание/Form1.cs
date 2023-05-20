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
    public partial class MainForm : Form
    {        
        public bool Is_Kir = false;
        public bool Is_Lat = false;
        public bool Is_Num = false;
        public bool Is_Spec = false;
        public int Pass_Len = 5;

        Encoding enc_cur;
        Encoding enc_un = Encoding.Unicode;

        public string password = "";
        public string message = "";

        public string cor_password = "";

        private bool Action_Type; // true - шифровать false - расшифровывать
        private bool Format_Info; // true - файл false - текстовое поле

        private OpenFileDialog ofd;
        private string FilePath = "";

        private byte[] key;

        public void ClearForm()
        {
            RB_Enc.Checked = false;
            RB_Dec.Checked = false;
            RB_File.Checked = false;
            RB_TextBox.Checked = false;

            GB_Info.Enabled = false;

            But_Action.Enabled = false;
            Lab_File.Visible = false;

            CB_Password.Visible = false;
            CB_Password.Checked = false;

            TB_Info.Text = "";
            Lab_File.Text = "";

            FilePath = "";
            password = "";
            cor_password = "";
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) // о программе
        {
            FormAbout fa = new FormAbout();
            fa.ShowDialog();
        }

        private void MainForm_Shown(object sender, EventArgs e) // при первой загрузке окна (начальные данные)
        {
            RB_Enc.Checked = false;
            RB_Dec.Checked = false;
            RB_File.Checked = false;
            RB_TextBox.Checked = false;

            GB_Info.Enabled = false;

            But_Action.Enabled = false;
            Lab_File.Visible = false;

            CB_Password.Visible = false;

            key = new byte[24];

            int i = 0;
            while (i < 24)
            {
                byte[] k = enc_un.GetBytes("Мария");

                int j = 0;
                while(j < k.Length && i < 24)
                {
                    key[i] = k[j];

                    i++;
                    j++;
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // закрытие программы при нажатии на пункт меню
        {
            Close();
        }

        private void задатьОграниченияПарольнойФразыToolStripMenuItem_Click(object sender, EventArgs e) // настройка парольной фразы при нажатии на пункт меню
        {
            PasswordParams FormPP = new PasswordParams();
            FormPP.mf = this;
            FormPP.ShowDialog();
        }

        private void CB_Password_CheckedChanged(object sender, EventArgs e) // Чекбокс использования парольной фразы
        {
            if (CB_Password.Checked)
            {
                FormPassword FormPass = new FormPassword();
                FormPass.mf = this;
                FormPass.ShowDialog();
            }
        }

        private void RB_Enc_CheckedChanged(object sender, EventArgs e) // Радиобатон шифрования
        {
            if (RB_Enc.Checked)
            {
                Action_Type = true;
                GB_Info.Enabled = true;
                CB_Password.Visible = true;

                But_Action.Text = Action_Type ? "Шифровать" : "Расшифровать";
            }
        }
        
        private void RB_Dec_CheckedChanged(object sender, EventArgs e) // Радиобатон дешифрования
        {
            if (RB_Dec.Checked)
            {
                Action_Type = false;
                GB_Info.Enabled = true;
                CB_Password.Visible = false;

                But_Action.Text = Action_Type ? "Шифровать" : "Расшифровать";
            }
        }

        private void RB_File_CheckedChanged(object sender, EventArgs e) // Радиобатон использования файла
        {
            if (RB_File.Checked)
            {
                using (ofd = new OpenFileDialog())
                {
                    ofd.RestoreDirectory = true;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {                       
                        FilePath = ofd.FileName;

                        Format_Info = true;

                        Lab_File.Visible = true;
                        Lab_File.Text = Path.GetFileName(FilePath);

                        But_Action.Enabled = true;
                    }
                    else
                    {
                        FilePath = "";
                        MessageBox.Show("Файл не задан");
                        return;
                    }
                }
            }
        }

        private void RB_TextBox_CheckedChanged(object sender, EventArgs e) // Радиобатон использования текстового поля
        {
            if (RB_TextBox.Checked)
            {
                Format_Info = false;
                But_Action.Enabled = true;
            }
        }

        private void But_Action_Click(object sender, EventArgs e)
        {
            try
            {
                if (Action_Type) // шифрование
                {
                    if (CB_Password.Checked) // с парольной фразой
                    {
                        if (password != "")
                        {
                            if (Format_Info)
                            {
                                if (FilePath == "")
                                {
                                    MessageBox.Show("Файл не задан");
                                    return;
                                }
                                else
                                {
                                    using (StreamReader sr = new StreamReader(FilePath, true))
                                    {
                                        enc_cur = sr.CurrentEncoding;
                                    }

                                    using (StreamReader sr = new StreamReader(FilePath, enc_cur, true))
                                    {
                                        message = sr.ReadToEnd();
                                    }

                                    DialogResult dr = MessageBox.Show("Удалить файл после использования?", "Удаление файла", MessageBoxButtons.YesNo);
                                    switch (dr)
                                    {
                                        case DialogResult.Yes:
                                            File.Delete(FilePath);
                                            break;
                                        case DialogResult.No:
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                message = TB_Info.Text;
                            }

                            int KeySize = password.Length * 10 + (Is_Kir ? 1 : 0) + (Is_Lat ? 2 : 1) + (Is_Num ? 3 : 2) + (Is_Spec ? 4 : 3);

                            Rabin r = new Rabin(KeySize, KeySize);
                            r.SaveKey(key);

                            FormResult fr = new FormResult();

                            int mes_len = message.Length;
                            int blocks = r.n.ToString().Length / 8;
                            blocks -= 26 + password.Length;

                            Console.WriteLine(blocks);

                            int i = 0;
                            while (mes_len > 0)
                            {
                                string sub_message = "Rabin" + "Password" + password + "Password" + message.Substring(i * blocks, mes_len > blocks ? blocks : mes_len) + "Rabin";

                                byte[] enc_un_sub_data = enc_un.GetBytes(sub_message);

                                string sub_data = r.RabinEncrypt(enc_un_sub_data);

                                fr.TB_Result.Text += sub_data + "\r\n";

                                mes_len -= mes_len > blocks ? blocks : mes_len;
                                i++;
                            }

                            fr.ShowDialog();

                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Парольная фраза не задана");
                        }
                    }
                    else
                    {
                        if (Format_Info)
                        {
                            if (FilePath == "")
                            {
                                MessageBox.Show("Файл не задан");
                                return;
                            }
                            else
                            {
                                using (StreamReader sr = new StreamReader(FilePath, true))
                                {
                                    enc_cur = sr.CurrentEncoding;
                                }

                                using (StreamReader sr = new StreamReader(FilePath, enc_cur, true))
                                {
                                    message = sr.ReadToEnd();
                                }

                                DialogResult dr = MessageBox.Show("Удалить файл после использования?", "Удаление файла", MessageBoxButtons.YesNo);
                                switch (dr)
                                {
                                    case DialogResult.Yes:
                                        File.Delete(FilePath);
                                        break;
                                    case DialogResult.No:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            message = TB_Info.Text;
                        }

                        int KeySize = 100;

                        Rabin r = new Rabin(KeySize, KeySize);
                        r.SaveKey(key);

                        FormResult fr = new FormResult();
                      

                        int mes_len = message.Length;
                        int blocks = r.n.ToString().Length / 9;
                        blocks -= 10;

                        Console.WriteLine(blocks);

                        int i = 0;
                        while (mes_len > 0)
                        {
                            string sub_message = "Rabin" + message.Substring(i * blocks, mes_len > blocks ? blocks : mes_len) + "Rabin";
                            byte[] enc_un_sub_data = enc_un.GetBytes(sub_message);

                            string sub_data = r.RabinEncrypt(enc_un_sub_data);

                            fr.TB_Result.Text += sub_data + "\r\n";

                            mes_len -= mes_len > blocks ? blocks : mes_len;
                            i++;
                        }

                        fr.ShowDialog();

                        ClearForm();
                    }
                }

                if (!Action_Type) // дешифрование
                {
                    if (Format_Info)
                    {
                        if (FilePath == "")
                        {
                            MessageBox.Show("Файл не задан");
                            return;
                        }
                        else
                        {
                            using (StreamReader sr = new StreamReader(FilePath, true))
                            {
                                enc_cur = sr.CurrentEncoding;
                            }

                            using (StreamReader sr = new StreamReader(FilePath, enc_cur, true))
                            {
                                message = sr.ReadToEnd();
                            }

                            DialogResult dr = MessageBox.Show("Удалить файл после использования?", "Удаление файла", MessageBoxButtons.YesNo);
                            switch (dr)
                            {
                                case DialogResult.Yes:
                                    File.Delete(FilePath);
                                    break;
                                case DialogResult.No:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        message = TB_Info.Text;
                    }

                    MessageBox.Show("Выберите контейнер ключей");
                    string filename;

                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "bin files (*.bin)|*.bin";
                    ofd.RestoreDirectory = true;

                    if (ofd.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Контейнер не выбран");
                        return;
                    }
                    else
                    {
                        filename = ofd.FileName;
                    }

                    Console.WriteLine(filename);

                    Rabin r = new Rabin(filename, key);

                    FormResult fr = new FormResult();

                    bool istruebin = true;

                    while (istruebin && message != "")
                    {
                        string sub_message = message.Substring(0, message.IndexOf("\r\n"));

                        if (!sub_message.Equals("\n") && !sub_message.Equals("\r") && !sub_message.Equals("\r\n") && !sub_message.Equals(""))
                        {

                            (byte[] data1, byte[] data2, byte[] data3, byte[] data4) = r.RabinDecrypt(sub_message);

                            string mesdat1 = enc_un.GetString(data1);
                            string mesdat2 = enc_un.GetString(data2);
                            string mesdat3 = enc_un.GetString(data3);
                            string mesdat4 = enc_un.GetString(data4);

                            //Console.WriteLine(mesdat1);
                            //Console.WriteLine(mesdat2);
                            //Console.WriteLine(mesdat3);
                            //Console.WriteLine(mesdat4);

                            if (mesdat1.Length > 10 && mesdat1.Substring(0, 5).Equals("Rabin"))
                            {
                                string message1 = mesdat1.Substring(5, mesdat1.Length - 10);
                                if (message1.Length > 16 && message1.Substring(0, 8).Equals("Password"))
                                {
                                    message1 = message1.Substring(8);

                                    string password1 = message1.Substring(0, message1.IndexOf("Password"));

                                    if (cor_password.Equals(""))
                                    {
                                        FormPasswordCorrect fpc = new FormPasswordCorrect();
                                        fpc.mf = this;
                                        fpc.ShowDialog();
                                    }

                                    if (!password1.Equals(cor_password))
                                    {
                                        istruebin = false;
                                    }

                                    message1 = message1.Substring(message1.IndexOf("Password") + 8);
                                }

                                fr.TB_Result.Text += message1;
                                Console.Write(message1);
                            }
                            else if (mesdat2.Length > 10 && mesdat2.Substring(0, 5).Equals("Rabin"))
                            {
                                string message2 = mesdat2.Substring(5, mesdat2.Length - 10);
                                if (message2.Length > 16 && message2.Substring(0, 8).Equals("Password"))
                                {
                                    message2 = message2.Substring(8);

                                    string password2 = message2.Substring(0, message2.IndexOf("Password"));

                                    if (cor_password.Equals(""))
                                    {
                                        FormPasswordCorrect fpc = new FormPasswordCorrect();
                                        fpc.mf = this;
                                        fpc.ShowDialog();
                                    }

                                    if (!password2.Equals(cor_password))
                                    {
                                        istruebin = false;
                                    }

                                    message2 = message2.Substring(message2.IndexOf("Password") + 8);
                                }

                                fr.TB_Result.Text += message2;
                                Console.Write(message2);
                            }
                            else if (mesdat3.Length > 10 && mesdat3.Substring(0, 5).Equals("Rabin"))
                            {
                                string message3 = mesdat3.Substring(5, mesdat3.Length - 10);
                                if (message3.Length > 16 && message3.Substring(0, 8).Equals("Password"))
                                {
                                    message3 = message3.Substring(8);

                                    string password3 = message3.Substring(0, message3.IndexOf("Password"));

                                    if (cor_password.Equals(""))
                                    {
                                        FormPasswordCorrect fpc = new FormPasswordCorrect();
                                        fpc.mf = this;
                                        fpc.ShowDialog();
                                    }

                                    if (!password3.Equals(cor_password))
                                    {
                                        istruebin = false;
                                    }

                                    message3 = message3.Substring(message3.IndexOf("Password") + 8);
                                }

                                fr.TB_Result.Text += message3;
                                Console.Write(message3);
                            }
                            else if (mesdat4.Length > 10 && mesdat4.ToString().Substring(0, 5).Equals("Rabin"))
                            {
                                string message4 = mesdat4.Substring(5, mesdat4.Length - 10);
                                if (message4.Length > 16 && message4.Substring(0, 8).Equals("Password"))
                                {
                                    message4 = message4.Substring(8);

                                    string password4 = message4.Substring(0, message4.IndexOf("Password"));

                                    if (cor_password.Equals(""))
                                    {
                                        FormPasswordCorrect fpc = new FormPasswordCorrect();
                                        fpc.mf = this;
                                        fpc.ShowDialog();
                                    }

                                    if (!password4.Equals(cor_password))
                                    {
                                        istruebin = false;
                                    }

                                    message4 = message4.Substring(message4.IndexOf("Password") + 8);
                                }

                                fr.TB_Result.Text += message4;
                                Console.Write(message4);
                            }
                            else
                            {
                                istruebin = false;
                            }
                        }
                        message = message.Substring(message.IndexOf("\r\n") + 2);
                    }

                    if (istruebin)
                    {
                        fr.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные");
                    }

                    ClearForm();

                    Console.WriteLine("");
                }
            }
            catch
            {
                MessageBox.Show("Необработанная ошибка");
            }
        }
    }
}
