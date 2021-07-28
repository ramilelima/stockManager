using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockManager
{
    [System.Serializable]
    class Ebook : Product, IStock
    {
        public string author;
        private int sales;

        public Ebook(string name, double price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
        }

        public void AddInput()
        {
            Console.WriteLine("It is not possible to add stock for digital product.");
            Console.ReadLine();
        }

        public void AddOutput()
        {
            Console.WriteLine($"Add sales of Ebook.");
            Console.WriteLine($"enter the amount of sales you want to add in {name}: ");
            int input = int.Parse(Console.ReadLine());
            sales += input;
            Console.WriteLine("Registered exit!");
            Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Sales: {sales}");
            Console.WriteLine("====================");
        }
    }
}
