using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InterTransfer
{
    public partial class TransferForm : Form
    {
        object[] _locks = new object[1];
        private long[] cells = new long[1];
        private int numberOfTransfersRemaining;
        private TransferTestDefinition testDefinition = new TransferTestDefinition();
        private long expectedTotal = 0;

        public TransferForm()
        {
            InitializeComponent();


            testDefinition.NumberOfCells = 1000000;
            testDefinition.NumberOfTransfers = 10000000;
            testDefinition.NumberofWorkers = 1;


            transferTestDefinitionBindingSource.DataSource = testDefinition;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            manualAuditButton.Enabled = false;


            cells = new long[testDefinition.NumberOfCells];
            _locks = new object[testDefinition.NumberOfCells];

            expectedTotal = 0;

            for (int nCell = 0; nCell < cells.Length; nCell++)
            {
                expectedTotal += cells[nCell] = 1000;
                _locks[nCell] = new object();
            }

            bankTotal.Text = expectedTotal.ToString();

            numberOfTransfersRemaining = testDefinition.NumberOfTransfers;

            for (int nThread = 0; nThread < testDefinition.NumberofWorkers; nThread++)
            {
                Thread worker = new Thread(DoTransfer);

                worker.Start();
            }

            auditTimer.Start();
        }
        private object cellLock = new object();

        private void DoTransfer()
        {
            Random rnd = new Random();

            while (numberOfTransfersRemaining > 0)
            {
                int src = rnd.Next(cells.Length);
                int dest = rnd.Next(cells.Length);

                int amount = rnd.Next(1000);

                MoveValue(src, dest, amount);

                numberOfTransfersRemaining--;
            }

        }



        private void DoAudit(object sender, EventArgs e)
        {
            PerformAudit();


            if (numberOfTransfersRemaining <= 0)
            {
                numberOfTransfersRemaining = 0;
                manualAuditButton.Enabled = true;
                button1.Enabled = true;
                auditTimer.Stop();

                PerformAudit();
            }

            noTransfersLabel.Text = numberOfTransfersRemaining.ToString();
        }

        private void PerformAudit()
        {
            long total = 0;

            lock (cellLock)
            {

                for (int nCell = 0; nCell < cells.Length; nCell++)
                {
                    total += cells[nCell];
                }
            }

            auditTotal.Text = total.ToString();

            if (total == expectedTotal)
            {
                auditTotal.ForeColor = Color.Black;
            }
            else
            {
                auditTotal.ForeColor = Color.Red;
            }
        }


        private void MoveValue(int src, int dest, int amount)
        {
            if (src == dest)
            {
                return;
            }

            int first = Math.Max(src, dest);
            int second = Math.Min(src, dest);

            try
            {
                Monitor.Enter(_locks[first]);
                Monitor.Enter(_locks[second]);
                {
                    cells[dest] += amount;
                    cells[src] -= amount;
                }
            }
            finally
            {
                Monitor.Exit(_locks[second]);
                Monitor.Exit(_locks[first]);
            }
        }
    }
}