using System.Collections.Generic;

namespace VKG.CodeFactory.DesignPrinciples.ISP
{
    public class InterfaceSegregationPrinciple
    {
        #region Common
        public class Customer
        {
        }
        public class Item
        {
        }
        #endregion  Common

        #region Violation
        public interface IOrderManager
        {
            void AddItem(Item item);
            void RemoveItem(Item item);
            IEnumerable<Item> GetItems();
            Customer Customer { get; set; }
            bool IsValid { get; }
            double GetTotalAmount();
            void UpdateOrder(IOrder order);
            void AttachCustomer(IOrder order);
            void Process(IOrder order);
        }

        #endregion  Violation

        #region Adherance
        public class Order : IOrder
        {
            public Customer Customer { get; set; }

            public bool IsValid { get; }

            public void AddItem(Item item)
            {
                //TODO: Implement goes here
            }

            public IEnumerable<Item> GetItems()
            {
                //TODO: Implement goes here
                return new List<Item>();
            }

            public double GetTotalAmount()
            {
                //TODO: Implement goes here
                return 0d;
            }

            public void RemoveItem(Item item)
            {
                //TODO: Implement goes here
            }
        }
        public interface IOrder
        {
            void AddItem(Item item);
            void RemoveItem(Item item);
            IEnumerable<Item> GetItems();
            Customer Customer { get; set; }
            bool IsValid { get; }
            double GetTotalAmount();
        }
        public interface IShoppingCart
        {
            void UpdateOrder(IOrder order);
        }
        public interface ICheckOut
        {
            void AttachCustomer(IOrder order);
        }
        public interface IOrderProcessor
        {
            void Process(IOrder order);
        }
        #endregion  Adherance
    }
}
