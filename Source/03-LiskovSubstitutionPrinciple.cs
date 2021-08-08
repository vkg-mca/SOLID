using System;
using System.Collections.Generic;

using Xunit;

namespace VKG.CodeFactory.DesignPrinciples.LSP
{

    #region Violation
    #region Example-1
    public class Order
    {
        private readonly List<Item> _items = new List<Item>();
        public virtual bool IsValid { get { return CheckIsValid(); } }

        private bool CheckIsValid()
        {
            var isValid = true;
            _items.ForEach(item =>
            {
                if (!item.IsInStock)
                    isValid = false;
            });
            return isValid;
        }
    }
    public class PriorityOrder : Order
    {
        private readonly List<Item> _items = new List<Item>();
        public override bool IsValid { get { return AreItemsInStock(); } }

        private bool AreItemsInStock()
        {
            _items.ForEach(item =>
            {
                if (!item.IsInStock)
                    throw new Exception("No items in stock");
            });
            return true;
        }
    }
    #endregion Example-1

    #region Example-2
    public class Rectangle
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
    }
    public class Square : Rectangle
    {
        public override double Width { get; set; }
        public override double Height { get { return Width; } set { Width = value; } }
    }
    public class SomeOtherClassMakingAssumption
    {
        public void CalculateSurface(Rectangle rectangle)
        {
            rectangle.Width = 4;
            rectangle.Height = 2;
            Assert.Equal(8, rectangle.Width * rectangle.Height);
        }
    }
    #endregion Example-2

    #endregion  Violation

    #region Adherance

    #endregion  Adherance

    #region Common
    public class Item
    {
        public bool IsInStock { get; internal set; }
    }
    #endregion  Common

}
