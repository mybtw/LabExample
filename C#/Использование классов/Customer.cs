using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CW1505
{
    class Customer
    {
        private string adress;
        private int discount;
        private string name;
        public string Adress
        {
            get
            { return adress; }


            private set
            {
                if (value != "")
                    adress = value;
                else adress = "None";

            }

        }
        public int Discount {
            get
            { return discount; }
            private set
            {
                if (value >= 0 && value < 100)
                    discount = value;
                else discount = 0;
            }

        }
        public string Name
        {
            get
            { return name; }


            private set
            {
                if (value != "")
                    name = value;
                else name = "None";
            }
        }

        public override string ToString()
        {
            return ($"Адресс:{Adress}; Скидка:{Discount}; Имя:{Name}");
        }

        public Customer(string adress, int discount, string name)
        {
            Adress = adress;
            Discount = discount;
            Name = name;
        }
    }
    
}
