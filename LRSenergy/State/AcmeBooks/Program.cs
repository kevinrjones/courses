using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleOrderWithState();

//            NoStateOrder order = new NoStateOrder();
            Order order = new Order();

            order.AddItem("foo");
            order.AddItem("bar");
            //order.Ship();


            order.SubmitOrder();

            order.SetDeliveryDetails("fdf");

            order.PickedItem("foo");
            order.PickedItem("bar");

            order.Ship();

        }

        private static void SimpleOrderWithState()
        {
            SimpleOrder order = new SimpleOrder();

            order.AddItem("foo");
            order.AddItem("bar");

            order.SubmitOrder();
            //order.Ship();

            order.SetDeliveryDetails("fdf");

            order.PickedItem("foo");
            order.PickedItem("bar");

            order.Ship();
        }
    }
}
