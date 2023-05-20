using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.Security.Cryptography;
using System.IO;

using System.Windows.Forms;

namespace Расчетное_задание
{
    class Rabin
    {
        private BigInteger p;
        private BigInteger q;
        public BigInteger n;

        public Encoding enc_utf8 = Encoding.UTF8;
        public Encoding enc_un = Encoding.Unicode;

        //шифрование открытых ключей
        private TripleDESCryptoServiceProvider DES3; 
        private byte[] key;

        public byte[] DES3_Enc(string data)
        {
            DES3 = new TripleDESCryptoServiceProvider();
            DES3.Padding = PaddingMode.None;
            DES3.Mode = CipherMode.CFB; // установка режима блочного шифрования

            byte[] IV = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            DES3.Key = key;

            byte[] bdata = enc_un.GetBytes(data);

            ICryptoTransform encryptor = DES3.CreateEncryptor(DES3.Key, IV); // создание объекта шифрования

            MemoryStream mems = new MemoryStream();
            CryptoStream crypts = new CryptoStream(mems, encryptor, CryptoStreamMode.Write);

            crypts.Write(bdata, 0, bdata.Length);
            crypts.Close();

            byte[] result = mems.ToArray();

            mems.Close();

            DES3.Clear();

            return result;
        }

        public byte[] DES3_Dec(byte[] enc_data, int sizekey)
        {
            DES3 = new TripleDESCryptoServiceProvider();
            DES3.Padding = PaddingMode.None;
            DES3.Mode = CipherMode.CFB; // установка режима блочного шифрования

            byte[] IV = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            DES3.Key = key;

            ICryptoTransform decryptor = DES3.CreateDecryptor(DES3.Key, IV);

            MemoryStream mems = new MemoryStream(enc_data);

            CryptoStream crypts = new CryptoStream(mems, decryptor, CryptoStreamMode.Read);

            byte[] result = new byte[sizekey];

            crypts.Read(result, 0, result.Length);

            crypts.Close();
            mems.Close();

            return result;
        }

        private bool RabinMillerTest(BigInteger num, int k)
        {
            if (num == 2 || num == 3 || num == 5 || num == 7)
                return true;

            if (num < 2 || num % 2 == 0)
                return false;

            BigInteger t = num - 1;
            BigInteger s = 0;

            while (t % 2 == 0)
            {
                t = t / 2;
                s++;
            }

            //количество проверок
            for (int i = 0; i < k; i++)
            {
                var rng = new RNGCryptoServiceProvider(); //криптографический генератор случайных чисел
                byte[] bytes = new byte[num.ToByteArray().Length];

                rng.GetBytes(bytes);
                BigInteger a = new BigInteger(bytes);

                while (a < 2 || a > num - 2)
                {
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }

                BigInteger x = BigInteger.ModPow(a, t, num); //вычет

                if (x == 1 || x == num - 1)
                    continue;

                for (BigInteger r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, num);

                    if (x == 1)
                        return false;
                    if (x == num - 1)
                        break;
                }

                if (x != num - 1)
                    return false;
            }

            return true;
        }

        private (BigInteger, BigInteger) EuclideanAlgorithm()
        {
            BigInteger p_ = p;
            BigInteger q_ = q;
            BigInteger help = q_;

            BigInteger t = 1;
            BigInteger s = 0;
            BigInteger help1 = s;

            while (q_ != 0)
            {
                BigInteger koef = p_ / q_;

                q_ = p_ - koef * q_;
                p_ = help;
                help = q_;

                s = t - koef * s;
                t = help1;
                help1 = s;
            }

            help1 = t;

            if (q != 0)
                t = (p_ - t * p) / q;
            else
                t = 0;

            return (help1, t);
        }

        public Rabin(int p_keySize = 1024, int q_keySize = 1024)
        {
            var rng = new RNGCryptoServiceProvider(); //криптографический генератор случайных чисел
            byte[] p_bytes = new byte[p_keySize];
            rng.GetBytes(p_bytes);

            p = new BigInteger(p_bytes);

            while (!RabinMillerTest(p, 50) || p % 4 != 3)
            {
                p_bytes = new byte[p_keySize];
                rng.GetBytes(p_bytes);
                p = new BigInteger(p_bytes);
            }

            byte[] q_bytes = new byte[q_keySize];
            rng.GetBytes(q_bytes);
            q = new BigInteger(q_bytes);

            while (!RabinMillerTest(q, 50) || q % 4 != 3)
            {
                q_bytes = new byte[q_keySize];
                rng.GetBytes(q_bytes);
                q = new BigInteger(q_bytes);
            }

            n = p * q;

            Console.WriteLine("Закрытые ключи");
            Console.WriteLine(p);
            Console.WriteLine(q);
            Console.WriteLine("Открытый ключ");
            Console.WriteLine(n);
        }

        public Rabin(string filename, byte[] newkey)
        {
            key = newkey;
            using (StreamReader sr = new StreamReader(filename, enc_utf8))
            {
                int p_len_enc = Convert.ToInt32(sr.ReadLine());
                char[] p_enc = new char[p_len_enc];
                sr.Read(p_enc, 0, p_len_enc);

                sr.ReadLine();

                int q_len_enc = Convert.ToInt32(sr.ReadLine());
                char[] q_enc = new char[q_len_enc];
                sr.Read(q_enc, 0, q_len_enc);

                sr.ReadLine();

                int p_len = Convert.ToInt32(sr.ReadLine());
                int q_len = Convert.ToInt32(sr.ReadLine());

                int n_len = Convert.ToInt32(sr.ReadLine());
                char[] n_ = new char[n_len];
                sr.Read(n_, 0, n_len);

                byte[] p_ = DES3_Dec(BigInteger.Parse(new string(p_enc)).ToByteArray(), p_len);
                byte[] q_ = DES3_Dec(BigInteger.Parse(new string(q_enc)).ToByteArray(), q_len);

                p = BigInteger.Parse(enc_un.GetString(p_));
                q = BigInteger.Parse(enc_un.GetString(q_));
                n = BigInteger.Parse(new string(n_));
            }

        }

        public void SaveKey(byte[] newkey)
        {
            MessageBox.Show("Выберите контейнер для хранения ключей");

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "bin files (*.bin)|*.bin";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Контейнер не выбран");
                return;
            }
            else
            {
                string namefile = sfd.FileName;

                key = newkey;

                string p_ = p.ToString();
                string strp = "";

                while (p_.Length % 8 != 0)
                {
                    p_ = '0' + p_;
                    strp += '0';
                }

                string q_ = q.ToString();
                string strq = "";

                while (q_.Length % 8 != 0)
                {
                    q_ = '0' + q_;
                    strq += '0';
                }


                byte[] enc_p = DES3_Enc(p_);
                byte[] enc_q = DES3_Enc(q_);          

                using (StreamWriter sw = new StreamWriter(namefile, false, enc_utf8))
                {
                    sw.WriteLine(new BigInteger(enc_p).ToString().Length);
                    sw.WriteLine(new BigInteger(enc_p));

                    sw.WriteLine(new BigInteger(enc_q).ToString().Length);
                    sw.WriteLine(new BigInteger(enc_q));

                    sw.WriteLine(enc_un.GetBytes(strp + p.ToString()).Length);
                    sw.WriteLine(enc_un.GetBytes(strq + q.ToString()).Length);

                    sw.WriteLine(n.ToString().Length);
                    sw.WriteLine(n);
                }
            }
        }

        public string RabinEncrypt(byte[] data)
        {
            BigInteger int_data = new BigInteger(data);
            BigInteger enc_data = BigInteger.ModPow(int_data, 2, n);

            Console.WriteLine("Данные для шифрования");
            Console.WriteLine(int_data);

            Console.WriteLine("Данные для расшифрования");
            Console.WriteLine(enc_data);

            return enc_data.ToString();
        }

        public (byte[],byte[],byte[],byte[]) RabinDecrypt(string enc_data)
        {
            BigInteger m_p;
            BigInteger m_q;

            BigInteger int_enc_data = BigInteger.Parse(enc_data);

            m_p = BigInteger.ModPow(int_enc_data, ((p + 1) / 4), p);
            m_q = BigInteger.ModPow(int_enc_data, ((q + 1) / 4), q);

            BigInteger y_p;
            BigInteger y_q;

            (y_p, y_q) = EuclideanAlgorithm();

            BigInteger r1;
            BigInteger r2;
            BigInteger r3;
            BigInteger r4;

            r1 = (y_p * p * m_q + y_q * q * m_p) % n < 0 ? n + (y_p * p * m_q + y_q * q * m_p) % n : (y_p * p * m_q + y_q * q * m_p) % n;
            r2 = n - r1;
            r3 = (y_p * p * m_q - y_q * q * m_p) % n < 0 ? n + (y_p * p * m_q - y_q * q * m_p) % n : (y_p * p * m_q - y_q * q * m_p) % n;
            r4 = n - r3;

            //Console.WriteLine("Данные для расшифрования");
            //Console.WriteLine(int_enc_data);

            //Console.WriteLine("Коэффициенты");
            //Console.WriteLine(m_p);
            //Console.WriteLine(m_q);

            //Console.WriteLine("Коэффициенты Безу");
            //Console.WriteLine(y_p);
            //Console.WriteLine(y_q);

            //Console.WriteLine("Результат дешифрования");
            //Console.WriteLine(r1);
            //Console.WriteLine(r2);
            //Console.WriteLine(r3);
            //Console.WriteLine(r4);

            return (r1.ToByteArray(), r2.ToByteArray(), r3.ToByteArray(), r4.ToByteArray());
        }

    }
}
