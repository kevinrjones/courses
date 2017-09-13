using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeBooks
{
    public partial class Order
    {
        private OrderState _state;

        private SelectingState _selectingState;
        private SupplyingDeliveryInfoState _supplyingDeliveryInfoState;
        private BeingPickedState _beingPickedState;
        private AllPickedState _allPickedState;
        private ShippedState _shippedState;

        public Order()
        {
            _selectingState = new SelectingState(this);
            _supplyingDeliveryInfoState = new SupplyingDeliveryInfoState(this);
            _beingPickedState = new BeingPickedState(this);
            _allPickedState = new AllPickedState(this);
            _shippedState = new ShippedState(this);

            _state = _selectingState;
        }

        private List<string> books = new List<string>();
        private int nPicked = 0;

        public void AddItem(string book)
        {
            _state.AddItem(book);
        }

        public void SubmitOrder()
        {
            _state.SubmitOrder();
        }

        public void SetDeliveryDetails(string address)
        {
            _state.SetDeliveryDetails(address);
        }


        public void PickedItem(string item)
        {
            _state.PickedItem(item);
        }


        public void Ship()
        {
            _state.Ship();
        }

        protected void InternalAddItem(string book)
        {
            Console.WriteLine("{0} added to order", book);
            books.Add(book);
        }

        protected void InternalSubmitOrder()
        {
            Console.WriteLine("Order submitted");
            _state = _supplyingDeliveryInfoState;
        }

        protected void InternalSetDeliveryDetails(string address)
        {
            Console.WriteLine("Delivery details supplied, being picked");
            _state = _beingPickedState;
        }

        protected void InternalPickedItem(string item)
        {
            nPicked++;
            Console.WriteLine("Picked item {0}", item);   
            if (nPicked == books.Count)
            {
                Console.WriteLine("All items picked.."); 
                _state = _allPickedState;
            }
        }

        protected void InternalShip()
        {
            Console.WriteLine("Books have been shipped");
            _state = _shippedState;
        }
    }
}
