using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Leaks
{
    public partial class Counter : Form
    {
        #region initialize
        int[] bigBuffer = new int[1000000];
        #endregion
        int _count;
        private Form1 _mainForm;

        public Counter(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mainForm.ClickerClick += CounterClickerClick;
        }

        void CounterClickerClick(object sender, EventArgs e)
        {
            _count++;
            label1.Text = _count.ToString();

            for (int i = 0; i < bigBuffer.Length; i++)
            {
                bigBuffer[i] = i;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
//            _mainForm.ClickerClick -= CounterClickerClick;
            base.OnClosing(e);
        }

        private void Counter_Load(object sender, EventArgs e)
        {

        }
    }
}