using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeBooks
{
    public class SimpleOrder
    {
        enum OrderStates
        {
            SELECTING,
            SUPPLYING_DELIVERY_INFO,
            BEING_PICKED,
            ALL_PICKED,
            SHIPPED
        };

        private OrderStates State = OrderStates.SELECTING;

        private List<string> books = new List<string>();
        private int nPicked = 0;

        public void AddItem(string book)
        {
            if (State == OrderStates.SELECTING)
            {
                books.Add(book);
                Console.WriteLine("{0} added to order", book);
            }
            else
            {
                throw new InvalidOperationException("AddItem");
            }
        }

        public void SubmitOrder()
        {
            if (State == OrderStates.SELECTING)
            {
                State = OrderStates.SUPPLYING_DELIVERY_INFO;
                Console.WriteLine("Order submitted");

            }
            else
            {
                throw new InvalidOperationException("SubmitOrder");
            }

        }

        public void SetDeliveryDetails(string address)
        {
            if (State == OrderStates.SUPPLYING_DELIVERY_INFO)
            {

                Console.WriteLine("Delivery details supplied, being picked");
                State = OrderStates.BEING_PICKED;
            }
            else
            {
                throw new InvalidOperationException("SetDeliveryDetails");
            }

        }

       
        public void PickedItem(string item)
        {
            if (State == OrderStates.BEING_PICKED)
            {
                nPicked++;

                Console.WriteLine("Picked item {0}", item);        


                if (nPicked == books.Count)
                {
                    Console.WriteLine("All items picked.."); 
                   State = OrderStates.ALL_PICKED;                   
                }
            }
            else
            {
                throw new InvalidOperationException("PickedItem");
            }
        }

       
        public void Ship()
        {
            if (State == OrderStates.ALL_PICKED)
            {
                State = OrderStates.SHIPPED;
                Console.WriteLine("Books have been shipped");
            }
            else
            {
                throw new InvalidOperationException("Ship");
            }
        }

    }
}
