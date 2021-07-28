using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace stockManager
{
    class Program
    {
        static List<IStock> products = new List<IStock>();
        enum Menu { ToList = 1, ToAdd, ToRemove, Input, Output, Exit }


        static void Main(string[] args)
        {
            Load();
            bool choseToLeave = false;
            while (choseToLeave == false)
            {
                Console.WriteLine("******* Stock Manager *******");
                Console.WriteLine("1-To List\n2-To Add\n3-To Remove\n4-Input\n5-Output\n6-Exit");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu choise = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {
                    switch (choise)
                    {
                        case Menu.ToList:
                            ProductList();
                            break;
                        case Menu.ToAdd:
                            Register();
                            break;
                        case Menu.ToRemove:
                            Remove();
                            break;
                        case Menu.Input:
                            Input();
                            break;
                        case Menu.Output:
                            Output();
                            break;
                        case Menu.Exit:
                            choseToLeave = true;
                            break;
                    }
                }
                else
                {
                    choseToLeave = true;
                }
            }
            Console.Clear();
        }

        static void ProductList()
        {
            Console.WriteLine("*** Product List ***");
            int i = 0;
            foreach (IStock product in products)
            {
                Console.WriteLine("ID: " + i);
                product.Show();
                i++;
            }
            Console.ReadLine();
        }

        static void Remove()
        {
            ProductList();
            Console.WriteLine("Enter the id of the element you want to remove: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products.RemoveAt(id);
                Save();
            }
        }

        static void Input()
        {
            ProductList();
            Console.WriteLine("Enter the id of the element you want to input: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].AddInput();
                Save();
            }
        }

        static void Output()
        {
            ProductList();
            Console.WriteLine("Enter the id of the element you want to output: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].AddOutput();
                Save();
            }
        }

        static void Register()
        {
            Console.WriteLine("Product Register");
            Console.WriteLine("1-Gift\n2-Ebook\n3-Bootcamp");
            string opStr = Console.ReadLine();
            int choiseInt = int.Parse(opStr);
            switch (choiseInt)
            {
                case 1:
                    GiftRegister();
                    break;
                case 2:
                    EbookRegister();
                    break;
                case 3:
                    BootcampRegister();
                    break;
            }
        }

        static void GiftRegister()
        {
            Console.WriteLine("Registering Gift: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Shipping: ");
            double shipping = double.Parse(Console.ReadLine());

            Gift obj = new Gift(name, price, shipping);
            products.Add(obj);
            Save();
        }

        static void EbookRegister()
        {
            Console.WriteLine("Registering Ebook: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Author: ");
            string author = Console.ReadLine();

            Ebook eb = new Ebook(name, price, author);
            products.Add(eb);
            Save();
        }

        static void BootcampRegister()
        {
            Console.WriteLine("Registering bootcamp: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Technology: ");
            string tech = Console.ReadLine();

            Bootcamp bc = new Bootcamp(name, price, tech);
            products.Add(bc);
            Save();

        }

        static void Save()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, products);

            stream.Close();
        }

        static void Load()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                products = (List<IStock>)encoder.Deserialize(stream);

                if (products == null)
                {
                    products = new List<IStock>();
                }
            }
            catch (Exception e)
            {
                products = new List<IStock>();
            }

            stream.Close();
        }
    }
}
