using System;
using System.Collections.Generic;
using System.Text;

namespace CW1505
{
    class Product
    {
        private string title;
        private double price;
        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                if (value != "")
                    title = value;
                else title = "None";

            }

        }

        public double Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value >= 0)
                    price = value;
                else price = 0;
            }
        }
        public Product(string title, double price)
        {
            Title = title;
            Price = price;
        }
        public override string ToString()
        {
            return ($"Название: {Title}; Цена: {Price};");
        }
    }
}
