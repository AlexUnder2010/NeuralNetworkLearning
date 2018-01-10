using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public int[] input = new int[3];
        private Web NW1;

        public Form1()
        {
            InitializeComponent();
        }

        public void recognize()
        {
            NW1.Sum();
            if (NW1.Rez()) listBox1.Items.Add(" - True, Sum = " + Convert.ToString(NW1.sum));
            else listBox1.Items.Add(" - False, Sum = " + Convert.ToString(NW1.sum));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NW1 = new Web(3, input);
            openFileDialog1.Title = "Укажите файл весов";
            openFileDialog1.ShowDialog();
            var s = openFileDialog1.FileName;
            var sr = File.OpenText(s);
            string line;
            string[] s1;
            while ((line = sr.ReadLine()) != null)
            {
                s1 = line.Split(' ');
                for (var i = 0; i < s1.Length; i++)
                {
                    listBox1.Items.Add("");
                    NW1.weight[i] = Convert.ToInt32(s1[i]);
                    listBox1.Items[i] += Convert.ToString(NW1.weight[i]);
                }
            }
            sr.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //for (var i = 0; i <= 5; i++) listBox1.Items.Add(" ");
            for (var x = 0; x <= 2; x++)
            {
                var n = 0;
                var str = new StreamReader("cat.txt", Encoding.Default);
                while (!str.EndOfStream)
                {
                    var st = str.ReadLine();
                    if (st.StartsWith(textBox1.Text))
                    {
                        n = 1;
                        break;
                    }
                    n = 0;
                }
                listBox1.Items[x] = listBox1.Items[x] + "  " + Convert.ToString(n);
                input[x] = n;
            }
        }

        private class Web
        {
            public readonly int[] input;
            public readonly int limit = 9;
            public int sum;
            public readonly int[] weight;

            public Web(int size, int[] inP)
            {
                weight = new int[size];
                input = new int[size];
                input = inP;
            }

            public void Sum()
            {
                sum = 0;
                for (var x = 0; x <= 2; x++)
                    sum += input[x] * weight[x];
            }

            public bool Rez()
            {
                if (sum >= limit)
                    return true;
                return false;
            }

            public void incW(int[] inP)
            {
                for (var x = 0; x <= 2; x++)
                    weight[x] += inP[x];
            }

            public void decW(int[] inP)
            {
                for (var x = 0; x <= 2; x++)
                    weight[x] -= inP[x];
            }
        }
    }
}