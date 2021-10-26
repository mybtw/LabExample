using System;
using static System.Console;
using System.Collections.Generic;

namespace CW1505
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Task 2");
            List<Product> list = new List<Product>() { new Product("Порох", 100), new Product("Ром", 654), new Product("Каша", 8) };
            foreach (var t in list)
                WriteLine(t);
            WriteLine("Task 4");
            List<OrderLine> list1 = new List<OrderLine>() { new OrderLine(5, new Product("Мыло", 77)), new OrderLine(10, new Product("Крупа", 777)) };
            foreach (var x in list1)
                WriteLine(x);
            WriteLine("Task 6");
            var database = new ProductDatabase();
            foreach (var x in list)
                database.AddProduct(x);
            WriteLine("Адресс:");
            var adress =ReadLine();
            WriteLine("Имя:");
           var name =  ReadLine();
            WriteLine("Скидка:");
           var discount = ReadLine();
            var order = new Order()
                
        }
    }
}
