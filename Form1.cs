using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UstroistvaLAB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mx, gx = "x^4 + x^2 + x^1 + 1";
            char[] g = { '1', '0', '1', '1', '1'};
            int d = 4, k = 3, n = 7, r = 4, xr10 = 16, mxxr, pe = 0, c = 0;
            try
            {
                char[] m = new char[3];
                while (c <= 100)
                {
                    m[0] = '1';
                    // char[] m = textBox1.Text.ToCharArray();
                    for (int i = 1; i < m.Length; i++)
                    {
                        Random rand = new Random();
                        double new_e;
                        int rand_e = rand.Next(0, 2147483646);
                        new_e = (double)rand_e;
                        new_e = new_e / 2147483646.0;
                        if (new_e < 0.5)
                        {
                            m[i] = '0';
                        }
                        else if (new_e >= 0.5)
                        {
                            m[i] = '1';
                        }
                    }
                    string ttm = new string(m);
                    textBox1.Text = ttm;
                    double p = Convert.ToDouble(textBox7.Text);
                    //if (m.Length == 0)
                    //{
                    //    throw new ArgException1("Вы ничего не ввели");
                    //}
                    //if (m[0] == '0')
                    //{
                    //    throw new ArgException2("Число должно начинаться с 1");
                    //}
                    //for (int i = 0; i < m.Length; i++)
                    //{
                    //    if (m[i] == '1' || m[i] == '0')
                    //    {
                    //        continue;
                    //    }
                    //    else throw new ArgException3("Число должно быть в двоичной системе счисления");
                    //}
                    if (p < 0 || p > 1)
                    {
                        throw new ArgException4("Точность должна быть от 0 до 1");
                    }
                    mx = Perevod(m);
                    textBox2.Text = mx;
                    string m2 = new string(m);
                    int int_m = Convert.ToInt32(m2, 2);
                    string m10 = Convert.ToString(int_m);
                    textBox3.Text = m10;
                    // string str = Convert.ToString(125, 2);
                    mxxr = int_m * xr10;
                    string mxxr_string = Convert.ToString(mxxr, 2);
                    textBox4.Text = mxxr_string;
                    char[] mxxr2 = mxxr_string.ToCharArray();
                    char[] cx2 = Delenie(mxxr2, g);
                    textBox5.Text = Perevod(cx2);
                    string str_cx = new string(cx2);
                    int cx = Convert.ToInt32(str_cx, 2);
                    int ax = mxxr + cx;
                    string str_ax = Convert.ToString(ax, 2);
                    char[] ax2 = str_ax.ToCharArray();
                    textBox6.Text = Perevod(ax2);
                    int ax_length = ax2.Length;
                    char[] E = new char[ax_length];
                    for (int i = 0; i < ax_length; i++)
                    {
                        Random rand = new Random();
                        double new_e;
                        int rand_e = rand.Next(0, 2147483646);
                        new_e = (double)rand_e;
                        new_e = new_e / 2147483646.0;
                        // double new_e = (double)((rand.Next(0, 2147483646))/2147483646);
                        if (new_e < p)
                        {
                            E[i] = '1';
                        }
                        else if (new_e >= p)
                        {
                            E[i] = '0';
                        }
                    }
                    char[] b = new char[ax_length];
                    for (int i = 0; i < ax_length; i++)
                    {
                        if (E[i] == '1' && ax2[i] == '1')
                        {
                            b[i] = '0';
                        }
                        else if (E[i] == '1' && ax2[i] == '0')
                        {
                            b[i] = '1';
                        }
                        else b[i] = ax2[i];
                    }
                    string e_str = new string(E);
                    int e10 = Convert.ToInt32(e_str, 2);

                    string b_str = new string(b);
                    textBox8.Text = "a = " + str_ax + ", e = " + e_str + ", b = " + b_str;
                    char[] s = Delenie(b, g);
                    if (s.Length == 1 && s[0] == '0' && e10 > 0)
                    {
                        pe++;
                        // textBox9.Text = "Ошибки не обнаружены";
                    }
                    c++;
                    // else textBox9.Text = "Ошибки обнаружены";
                }
                double pec = (double)pe / (double)c;
                textBox9.Text = pec.ToString();
            }
            //catch (ArgException1 arg1)
            //{
            //    MessageBox.Show($"Ошибка: {arg1.Message}");
            //    textBox1.Clear();
            //    textBox2.Clear();
            //    textBox1.Focus();
            //}
            //catch (ArgException2 arg2)
            //{
            //    MessageBox.Show($"Ошибка: {arg2.Message}");
            //    textBox1.Clear();
            //    textBox2.Clear();
            //    textBox1.Focus();
            //}
            //catch (ArgException3 arg3)
            //{
            //    MessageBox.Show($"Ошибка: {arg3.Message}");
            //    textBox1.Clear();
            //    textBox2.Clear();
            //    textBox1.Focus();
            //}
            catch (ArgException4 arg4)
            {
                MessageBox.Show($"Ошибка: {arg4.Message}");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите десятичную дробь от 0 до 1");
                textBox1.Clear();
                textBox2.Clear();
                textBox7.Clear();
                textBox7.Focus();
            }
        }

        public string Perevod(char[] a)
        {
            string xx = "x^" + (a.Length - 1);
            if (a.Length == 1)
            {
                xx = "1";
            }
            for (int i = a.Length - 2, j = 1; i >= 0; i--, j++)
            {
                if (i == 0 && a[j] == '1')
                {
                    xx = xx + " + 1";
                }
                else if (a[j] == '1')
                {
                    xx = xx + " + x^" + i;
                }
            }
            return xx;
        }
        public char[] Delenie(char[] a, char[] b)
        {
            int a_length = a.Length;
            int b_length = b.Length;
            string a_string = new string(a);
            string b_string = new string(b);
            string d = "";
            string new_b;
            int raz;
            int new_a_deg = a.Length;
            char[] new_a_char = a;
            while (new_a_deg >= b_length)
            {
                raz = new_a_char.Length - b_length;
                for (int i = 0; i < raz; i++)
                {
                    d = d + "0";
                }
                new_b = b_string + d;
                char[] new_b_char = new_b.ToCharArray();
                string new_a_string = "";
                for (int i = 0; i < new_a_char.Length; i++)
                {
                    if (new_a_char[i] == new_b_char[i])
                    {
                        new_a_string = new_a_string + "0";
                    }
                    else if (new_a_char[i] != new_b_char[i])
                    {
                        new_a_string = new_a_string + "1";
                    }
                }
                new_a_string = new_a_string.TrimStart('0');
                if (new_a_string.Length == 0)
                {
                    new_a_string = "0";
                }
                new_a_deg = new_a_string.Length;
                new_a_char = new_a_string.ToCharArray();
            }
            return new_a_char;
        }
    }
    class ArgException1 : ArgumentException
    {
        public ArgException1(string message)
            : base(message)
        { }
    }
    class ArgException2 : ArgumentException
    {
        public ArgException2(string message)
            : base(message)
        { }
    }
    class ArgException3 : ArgumentException
    {
        public ArgException3(string message)
            : base(message)
        { }
    }
    class ArgException4 : ArgumentException
    {
        public ArgException4(string message)
            : base(message)
        { }
    }
}
