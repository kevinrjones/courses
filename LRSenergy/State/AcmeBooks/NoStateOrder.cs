using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeBooks
{
    public class NoStateOrder
    {
        private List<string> books = new List<string>();
        private int nPicked = 0;

        public void AddItem(string book)
        {

            books.Add(book);
            Console.WriteLine("{0} added to order", book);
        }

        public void SubmitOrder()
        {
            Console.WriteLine("Order submitted");
        }

        public void SetDeliveryDetails(string address)
        {
            Console.WriteLine("Delivery details supplied");
        }


        public void PickedItem(string item)
        {

            Console.WriteLine("Picked item {0}" , item );        
            nPicked++;

            if (nPicked == books.Count)
            {
                Console.WriteLine("All items picked..");

            }
   
        }


        public void Ship()
        {
           Console.WriteLine("Books have been shipped");
           
        }

    }
}
