using System;
using System.Collections.Generic;
using HerancaPolimorfismo.Entities;
using System.Globalization;

namespace HerancaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> Products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i=0; i<n; i++)
            {
                Console.WriteLine($"Product {i+1} Data: ");
                Console.Write("Common, Used or Imported? (c/u/i): ");
                char op = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (op == 'U' || op == 'u')
                {
                    Console.Write("Manufacture date: (DD/MM/YYYY): ");
                    DateTime dt = DateTime.Parse(Console.ReadLine());
                    Products.Add(new UsedProduct(name,price, dt));
                }
                else if (op == 'I' || op == 'i')
                {
                    Console.Write("Customs fee: ");
                    double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Products.Add(new ImportedProduct(name, price, fee));
                }
                else
                {
                    Products.Add(new Product(name, price));
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product p in Products)
            {
                Console.WriteLine(p.PriceTag());
            }
        }
    }
}
