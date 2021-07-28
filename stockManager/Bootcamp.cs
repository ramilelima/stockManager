using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockManager
{
    [System.Serializable]
    class Bootcamp : Product, IStock
    {
        public string technology;
        private int vacancies;

        public Bootcamp(string name, double price, string technology)
        {
            this.name = name;
            this.price = price;
            this.technology = technology;
        }

        public void AddInput()
        {
            Console.WriteLine($"Add vacancies in Bootcamp: {name}");
            Console.WriteLine("Enter the amount of vacancies you want to add: ");
            int input = int.Parse(Console.ReadLine());
            vacancies += input;
            Console.WriteLine("Registered entry!");
            Console.ReadLine();
        }

        public void AddOutput()
        {
            Console.WriteLine($"Consume places in the bootcamp.");
            Console.WriteLine($"Enter the quantity of {name} you wish to consume from stock: ");
            int output = int.Parse(Console.ReadLine());
            vacancies -= output;
            Console.WriteLine("Registered exit!");
            Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Technology: {technology}");
            Console.WriteLine($"Available vacancies: {vacancies}");
            Console.WriteLine("====================");
        }
    }
}
