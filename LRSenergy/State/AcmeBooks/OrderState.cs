using System;

namespace AcmeBooks
{
    public partial class Order
    {
        public abstract class OrderState
        {
            protected readonly Order Order;

            public OrderState(Order order)
            {
                Order = order;
            }

            public virtual void AddItem(string book)
            {
                throw new InvalidOperationException();
            }

            public virtual void SubmitOrder()
            {
                throw new InvalidOperationException();
            }

            public virtual void SetDeliveryDetails(string address)
            {
                throw new InvalidOperationException();
            }


            public virtual void PickedItem(string item)
            {
                throw new InvalidOperationException();
            }


            public virtual void Ship()
            {
                throw new InvalidOperationException();
            }
        }

        public class SelectingState : OrderState
        {
            public SelectingState(Order order)
                : base(order)
            {
            }

            public override void AddItem(string book)
            {
                Order.InternalAddItem(book);
            }

            public override void SubmitOrder()
            {
                Order.InternalSubmitOrder();
            }
        }

        public class SupplyingDeliveryInfoState : OrderState
        {
            public SupplyingDeliveryInfoState(Order order)
                : base(order)
            {
            }

            public override void SetDeliveryDetails(string address)
            {
                Order.InternalSetDeliveryDetails(address);
            }
        }

        public class BeingPickedState : OrderState
        {
            public BeingPickedState(Order order)
                : base(order)
            {
            }

            public override void PickedItem(string item)
            {
                Order.InternalPickedItem(item);
            }
        }

        public class AllPickedState : OrderState
        {
            public AllPickedState(Order order)
                : base(order)
            {
            }

            public override void Ship()
            {
                Order.InternalShip();
            }
        }

        public class ShippedState : OrderState
        {
            public ShippedState(Order order)
                : base(order)
            {
            }
        }
    }
}