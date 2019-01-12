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
            // Display the main menu of the application
            menu.MainMenu();

            Vendor vendor = new Vendor();
            // Capture user's action
            string input = Console.ReadLine();
            while (input != "3")
            {
                switch (input)
                {
                    case "1": // Selling production functionality
                        vendor.DisplaySellProducts();
                        var productId = Convert.ToInt32(Console.ReadLine());
                        menu.MainMenu();
                        break;
                    case "2": // Vendor Admin Page 
                        menu.VendorAdminMenu();
                        var vendorInput = Console.ReadLine();
                        while (vendorInput != "4")
                        {
                            if (vendorInput == "1") // View all products
                            {
                                vendor.DisplayOriginalProducts();
                                vendorInput = Console.ReadLine();
                                menu.VendorAdminMenu();
                            }
                            else if (input == "2") // Add new products
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

    /// <summary>
    /// The class contain all businesses of a vendor
    /// </summary>
    class Vendor
    {
        // All products of vendor
        private List<Product> Products = null;
        public Vendor()
        {
            InitalProducts();
        }

        /// <summary>
        /// Add 2 inital products to a vendor
        /// </summary>
        private void InitalProducts()
        {
            Products = new List<Product>() {
                new Product(){
                    Id = 1,
                    Name = "T-Shirt",
                    Category = "Shirt",
                    Colors = "White, Black",
                    OriginalPrice = 6,
                    SellPrice = 12,
                    Sizes = "S, M"
                },
                new Product(){
                    Id = 2,
                    Name = "Dress Shirt",
                    Category = "Shirt",
                    Colors = "Red, Green",
                    OriginalPrice = 8,
                    SellPrice = 20,
                    Sizes = "S, M"
                },

            };
        }

        /// <summary>
        /// Display all products with all their info in Vendor Admin page
        /// </summary>
        public void DisplayOriginalProducts()
        {
            Console.WriteLine("Below are our all products in store");
            foreach (Product p in Products)
            {
                Console.WriteLine(string.Format("Product Id: {0}, Name: {1}", p.Id, p.Name));
                Console.WriteLine(string.Format("\t Original Price: ${0}", p.OriginalPrice));
                Console.WriteLine(string.Format("\t Sell Price: ${0}", p.SellPrice));
                Console.WriteLine(string.Format("\t Category: {0}", p.Category));
                Console.WriteLine(string.Format("\t Sizes: {0} ", p.Sizes));
                Console.WriteLine(string.Format("\t Colors: {0}", p.Colors));
            }
        }

        /// <summary>
        /// Add new product to sell
        /// </summary>
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

            var product = new Product() {
                Id = Products.Count + 1,
                Name = productName,
                Category = productCategory,
                Colors = productColors,
                OriginalPrice = productOriginalPrice,
                SellPrice = productSellPrice,
                Sizes = productSizes
            };

            Products.Add(product);
        }

        /// <summary>
        /// Display all products for selling with a limitted info
        /// </summary>
        public void DisplaySellProducts()
        {
            Console.WriteLine("We have all fashion of the world. Please choose the number next to product name.");
            foreach (Product p in Products)
            {
                Console.WriteLine(string.Format("{0}. {1}: ${2}",p.Id, p.Name, p.SellPrice)); 
            }
        }
    }

    /// <summary>
    /// The class is to centralize the application's menu
    /// </summary>
    class Menu
    {
        public Menu()
        {
        }

        /// <summary>
        /// The menu that user will see when firt come to the application
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("Welcome to our Fashion Store");
            Console.WriteLine("Please choose below actions: (Press the number according to each action)");
            Console.WriteLine("1. Shopping");
            Console.WriteLine("2. Seller Admin");
            Console.WriteLine("3. Quit");
        }

        /// <summary>
        /// The menu of vendor to view their all products, add more products or view orders
        /// </summary>
        public void VendorAdminMenu()
        {
            Console.WriteLine("Welcome to Vendor admin page");
            Console.WriteLine("1. View all products");
            Console.WriteLine("2. Add one more product");
            Console.WriteLine("3. View orders");
            Console.WriteLine("4. Back");
        }
    }
    
    /// <summary>
    /// The class is to contain orders
    /// </summary>
    class Order
    {
        public string BuyerName { get; set; }  // The person who buy the product
        public DateTime CreateDate { get; set; } // The date that order is created
        public int TotalAmount { get; set; } // Total amount that sum from all order items
        public List<OrderItem> OrderItems { get; set; }
    }

    /// <summary>
    /// The class store the info of product bought in an order
    /// </summary>
    class OrderItem
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public Product Product { get; set; } 
    }

    class Product
    {
        // This class is demonstrate for a real product
        public int Id { get; set; } // The unique number to identify each product 
        public string Name { get; set; } // The name of product
        public int OriginalPrice { get; set; } // The price that vendor buys from suppliers
        public int SellPrice { get; set; } // The price that vendor will sell on our application
        public string Category { get; set; } // 1. Shirt; 2. Skirt; 3. Clothes
        public string Sizes { get; set; } // A collection of product size, separated by comma
        public string Colors { get; set; } // A collection of product color, separated by comma
    }
}
