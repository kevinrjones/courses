using System;
using System.Collections.Generic;
using System.Text;

namespace StockTicker
{
    public class Investment
    {
        public Investment(string symbol , int quantity)
        {
            Symbol = symbol;
            Quantity = quantity;
        }

        private string symbol;

        public string Symbol
        {
            get { return symbol; }
            private set { symbol = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
