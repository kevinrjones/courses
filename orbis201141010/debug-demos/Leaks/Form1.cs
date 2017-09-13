using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Leaks
{
    public partial class Form1 : Form
    {
        public event EventHandler ClickerClick;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClickerClick != null)
                ClickerClick(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Counter c = new Counter(this);
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}