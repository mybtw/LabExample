using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CW1505
{
    class Order
    {
        public int Discount { get; private set; }
        public int Number { get; private set; }
        public double TotalPrice { get; private set; }
        public Order(int discount, int number, int totalprice)
        {
            Discount = discount;
            Number = number;
            TotalPrice = totalprice;
        }
        public void Print()
        {
            WriteLine($"Скидка: {Discount}; Номер: {Number}; Общая цена: {TotalPrice}");
        }
        public void addOrderLine()
        {

        }
    }
}
