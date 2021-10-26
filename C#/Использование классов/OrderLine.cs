using System;
using System.Collections.Generic;
using System.Text;

namespace CW1505
{
    class OrderLine
    {
        public int  Quantity{get;private set;}
        public Product aProduct { get; private set; }
        public OrderLine(int quantity, Product aproduct)
        {
            Quantity = quantity;
            aProduct = aproduct;
        }
        public override string ToString()
        {
            return ($"Количество: {Quantity};  {aProduct}");
        }
        public double TotalPrice()
        {
            return Quantity * aProduct.Price;
        }
    }
}
