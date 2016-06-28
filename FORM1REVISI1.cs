using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Master
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rd = new Random();
        Stats stats = new Stats();
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Menambahkan random-random key ke dalam list
            listBox1.Items.Add((Keys)rd.Next(65, 90));
            if (listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game over");
                timer1.Stop();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if (timer1.Interval > 800)
                    timer1.Interval -= 10;
                if (timer1.Interval > 500)
                    timer1.Interval -= 7;
                if (timer1.Interval > 200)
                    timer1.Interval -= 2;
                difficultyProgressBar.Value = 800 - timer1.Interval;
                stats.Update(true);
            }
            else
            {
                stats.Update(false);
            }
            lblCorrect.Text = "Benar: " + stats.Correct;
            lblMissed.Text = "Salah: " + stats.Missed;
            lblTotal.Text = "Total: " + stats.Total;
            lblAccuracy.Text = "Akurasi: " + stats.Accuracy + "%";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void MenuNew_Click(object sender, EventArgs e)
        {
            stats.Correct = 0; stats.Missed = 0; 
            stats.Total = 0;   stats.Accuracy = 0;
            listBox1.Items.Clear();
            difficultyProgressBar.Value = 0;
            timer1.Interval = 800;
            timer1.Enabled = true;
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
