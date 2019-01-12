using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FashionStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.MainMenu();

            Vendor vendor = new Vendor();
            string input = Console.ReadLine();
            while (input != "3")
            {
                switch (input)
                {
                    case "1":
                        vendor.DisplaySellProducts();
                        Console.Read();
                        menu.MainMenu();
                        break;
                    case "2":
                        menu.VendorAdminMenu();
                        var vendorInput = Console.ReadLine();
                        while (vendorInput != "4")
                        {
                            if (vendorInput == "1")
                            {
                                vendor.DisplayOriginalProducts();
                                vendorInput = Console.ReadLine();
                                menu.VendorAdminMenu();
                            }
                            else if (input == "2")
                            {
                                vendor.AddNewProduct();
                                menu.VendorAdminMenu();
                            }
                            vendorInput = Console.ReadLine();
                        }
                        menu.MainMenu();
                        break;
                    case "3": break;
                    default: break;
                }

                input = Console.ReadLine();
            }
        }
    }

    class Vendor
    {
        private List<Product> Products = null;
        public Vendor()
        {
            InitalProducts();
        }
        private void InitalProducts()
        {
            Products = new List<Product>() {
                new Product(){
                    Name = "a. T-Shirt",
                    Category = "Shirt",
                    Colors = "White, Black",
                    OriginalPrice = 6,
                    SellPrice = 12,
                    Sizes = "S, M"
                },
                new Product(){
                    Name = "b. Dress Shirt",
                    Category = "Shirt",
                    Colors = "Red, Green",
                    OriginalPrice = 8,
                    SellPrice = 20,
                    Sizes = "S, M"
                },

            };
        }
        public void DisplayOriginalProducts()
        {
            Console.WriteLine("Below are our all products in store");
            foreach (Product p in Products)
            {
                Console.WriteLine(string.Format("{0}", p.Name));
                Console.WriteLine(string.Format("\t Original Price: ${0}", p.OriginalPrice));
                Console.WriteLine(string.Format("\t Sell Price: ${0}", p.SellPrice));
                Console.WriteLine(string.Format("\t Category: {0}", p.Category));
                Console.WriteLine(string.Format("\t Sizes: {0} ", p.Sizes));
                Console.WriteLine(string.Format("\t Colors: {0}", p.Colors));
            }
        }
        public void AddNewProduct()
        {
            Console.WriteLine("Please complete below information to import more product to the application");
            Console.WriteLine("Name: ");
            var productName = Console.ReadLine();
            Console.WriteLine("Category: ");
            var productCategory = Console.ReadLine();
            Console.WriteLine("Original Price: ");
            var productOriginalPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sell Price: ");
            var productSellPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sizes (separated by comma): ");
            var productSizes = Console.ReadLine();
            Console.WriteLine("Colors (separated by comma): ");
            var productColors = Console.ReadLine();

            Products.Add(new Product() {
                Name = productName,
                Category = productCategory,
                Colors = productColors,
                OriginalPrice = productOriginalPrice,
                SellPrice = productSellPrice,
                Sizes = productSizes
            });
        }
        public void DisplaySellProducts()
        {
            Console.WriteLine("We have all fashion of the world. Please choose:");
            foreach (Product p in Products)
            {
                Console.WriteLine(string.Format("{0}: ${1}", p.Name, p.SellPrice)); 
            }
        }
    }

    class Menu
    {
        public Menu()
        {
        }

        public void MainMenu()
        {
            Console.WriteLine("Welcome to our Fashion Store");
            Console.WriteLine("Please choose below actions: (Press the number according to each action)");
            Console.WriteLine("1. Shopping");
            Console.WriteLine("2. Seller Admin");
            Console.WriteLine("3. Quit");
        }

        public void VendorAdminMenu()
        {
            Console.WriteLine("Welcome to Vendor admin page");
            Console.WriteLine("1. View all products");
            Console.WriteLine("2. Add one more product");
            Console.WriteLine("3. View orders");
            Console.WriteLine("4. Back");
        }
    }
    class Product
    {
        public string Name { get; set; }
        public int OriginalPrice { get; set; } // The price that vendor buys from suppliers
        public int SellPrice { get; set; } // The price that vendor will sell on the application
        public string Category { get; set; } // 1. Shirt; 2. Skirt; 3. Clothes
        public string Sizes { get; set; } // A collection of product size
        public string Colors { get; set; } // A collection of product color 
    }
}
