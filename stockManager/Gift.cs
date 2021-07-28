using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockManager
{
    [System.Serializable]
    class Gift : Product, IStock
    {
        public double shipping;
        private int stock;

        public Gift(string name, double price, double shipping)
        {
            this.name = name;
            this.price = price;
            this.shipping = shipping;
        }

        public void AddInput()
        {
            Console.WriteLine($"Add entry to {name} product stock: ");
            Console.WriteLine("Enter the amount you want to add: ");
            int input = int.Parse(Console.ReadLine());
            stock += input;
            Console.WriteLine("Registered entry!");
            Console.ReadLine();
        }

        public void AddOutput()
        {
            Console.WriteLine($"Add exit to {name} product stock. ");
            Console.WriteLine($"Enter the quantity of {name} you wish to withdraw from stock: ");
            int output = int.Parse(Console.ReadLine());
            stock -= output;
            Console.WriteLine("Registered exit!");
            Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Shipping: {shipping}");
            Console.WriteLine($"Stock: {stock}");
            Console.WriteLine("====================");
        }
    }
}
