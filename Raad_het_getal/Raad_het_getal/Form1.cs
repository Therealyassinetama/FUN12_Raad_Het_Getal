using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raad_het_getal
{
    public partial class Form1 : Form
    {

        List<int> rndgetallen = new List<int>();

        public static Random r = new Random();

        int lives = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lives = 5;
            generate(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }

        public void generate(int min, int max)
        {
            label4.Text = "YOUR LIVES: " + lives.ToString();
            rndgetallen.Clear();
            listBox1.Items.Clear();
            int treshhold = (max - min) / 2;
            for (int i = 0; i < treshhold; i++)
            {
               int c = (r.Next(min, max));
                if(rndgetallen.Contains(c))
                {
                    c = (r.Next(min, max + 1));
                }
               rndgetallen.Add(c);
            }
            foreach (int i in rndgetallen)
            {
                listBox1.Items.Add((i).ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guess(Convert.ToInt32(textBox3.Text));
        }

        public void guess (int guess)
        {
            if (lives > 0)
            {
                if (rndgetallen.Contains(guess))
                {
                    label4.Text = "YOUR LIVES: " + lives.ToString();
                    MessageBox.Show("It contains it");
                    int index = rndgetallen.IndexOf(guess);
                    rndgetallen.RemoveAt(index);
                    listBox1.Items.Clear();
                    foreach (int i in rndgetallen)
                    {
                        listBox1.Items.Add((i).ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No it doesn't");
                    lives--;
                    label4.Text = "YOUR LIVES: " + lives.ToString();
                }
            }
            else
            {
                MessageBox.Show("Your dead kiddo");
            }
        }
    }
}
