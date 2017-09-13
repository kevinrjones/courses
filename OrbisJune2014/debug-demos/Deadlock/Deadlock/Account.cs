using System;

namespace Deadlock
{
    class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }

        public void Spin()
        {
            int sum = 0;
            DateTime start = DateTime.Now;
            while (DateTime.Now - start < TimeSpan.FromMilliseconds(50))
                sum++;

        }

        public void TransferTo(Account other, double amount)
        {
            //Account a = (other.Id > this.Id) ? this : other;
            //Account b = (other.Id <= this.Id) ? this : other;

            lock (this)
            {
                Spin();
                lock (other)
                {
                    Spin();
                    this.Balance -= amount;
                    other.Balance += amount;
                }
            }
        }
    }
}