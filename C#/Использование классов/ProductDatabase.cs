using System;
using System.Collections.Generic;
using System.Text;

namespace CW1505
{
    class ProductDatabase
    {
        private Dictionary<string, Product> database;
        public ProductDatabase()
        {
            database = new Dictionary<string, Product>();
        }
        public void AddProduct(Product p)
        {
            Random r = new Random();
            var c = (char)((int)'A' + r.Next(26));
            var numb = r.Next(100, 999).ToString();
            string key = c + numb;
            while (database.ContainsKey(key))
            {
                 c = (char)((int)'A' + r.Next(26));
                 numb = r.Next(100, 999).ToString();
                 key = c + numb;
            }
            database.Add(key, p);
        }
    }
}
