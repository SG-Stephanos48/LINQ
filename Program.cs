using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1(); 
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5(); 
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();  
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();  
            //Exercise21();  //
            //Exercise22();
            //Exercise23();
            //Exercise24();  
            //Exercise25();  
            //Exercise26();
            //Exercise27();  
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1() //Good
        {
            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var outofstock = from p in products
                             where p.UnitsInStock == 0
                             select p;

            PrintProductInformation(outofstock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2() //Good
        {
            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var instock3 = from p in products
                           where p.UnitsInStock > 0 && p.UnitPrice > 3
                           select p;

            PrintProductInformation(instock3);

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3() //Good
        {
            List<Customer> customers = new List<Customer>(DataLoader.LoadCustomers());

            var customerwa = from c in customers
                             where c.Region == "WA"
                             select c;

            PrintCustomerInformation(customerwa);

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var queryProducts = from p in products
                             select new 
                             {
                                 p.ProductName
                             };

            string line = "{0,-5} ";
            Console.WriteLine(line, "Product Name" );
            Console.WriteLine("==============================================================================");

            foreach (var product in queryProducts)
            {
                Console.WriteLine(line, product.ProductName );
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var queryProducts = from p in products
                      select new
                      {
                          p.ProductID,
                          p.ProductName,
                          p.Category,
                          UnitPrice = p.UnitPrice * (decimal)1.25,  //Try M
                          p.UnitsInStock
                      };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in queryProducts)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var queryProducts = from p in products
                      select new
                      {
                          p.ProductName,
                          p.Category
                      };

            string line = "{0,-5} {1,-35} "; 
            Console.WriteLine(line, "Product Name", "Category" );
            Console.WriteLine("==============================================================================");

            foreach (var product in queryProducts)
            {
                Console.WriteLine(line, product.ProductName.ToUpper(), product.Category.ToUpper() );
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var queryProducts = from p in products
                      select new
                      {
                          p.ProductID,
                          p.ProductName,
                          p.Category,
                          p.UnitPrice,  
                          p.UnitsInStock,
                          ReOrder = p.UnitsInStock < 3  //Do not totally understand, but need to come back to
                      };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "ProductName", "Category", "Price", "InStock", "ReOrder");
            Console.WriteLine("==============================================================================");

            foreach (var product in queryProducts)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());
            
            var queryProducts = (from p in products
                                select new
                                {
                                    p.ProductID,
                                    p.ProductName,
                                    p.Category,
                                    p.UnitPrice,
                                    p.UnitsInStock,
                                    StockValue = p.UnitPrice * p.UnitsInStock
                                }).ToList();

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "ProductName", "Category", "Price", "Stock", "StockValue" );
            Console.WriteLine("==============================================================================");

            foreach (var product in queryProducts)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock,  product.StockValue); 
            }

        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()  //Good
        {

            List<int> numbers = new List<int>(DataLoader.NumbersA);

            IEnumerable<int> onlyEvens = numbers.Where(n => n % 2 == 0);

            string line = "{0,-5}";
            Console.WriteLine(line, "Number");
            Console.WriteLine("==============================================================================");

            foreach (var number in onlyEvens)
            {
                Console.WriteLine(line, number.ToString());
            }

        }

        /// <summary>
        /// Print only customers that have an order whose total is less than $500
        /// </summary>
        static void Exercise10() //Good
        {

            List<Customer> customers = new List<Customer>(DataLoader.LoadCustomers());

            var customer500 = customers.Where(c => c.Orders.Any(o => o.Total < 500)).ToList();
            PrintCustomerInformation(customer500);  

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()  //Good
        {

            List<int> numbers = new List<int>(DataLoader.NumbersC);

            IEnumerable<int> onlyOdds = numbers.Where(n => n % 2 == 1).Take(3);

            string line = "{0,-5}";
            Console.WriteLine(line, "Number");
            Console.WriteLine("==============================================================================");

            foreach (var number in onlyOdds)
            {
                Console.WriteLine(line, number.ToString());
            }

        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()  //Good
        {

            List<int> numbers = new List<int>(DataLoader.NumbersB);

            var notfirst3 = numbers.Skip(3);
            
            string line = "{0,-5}";
            Console.WriteLine(line, "Number");
            Console.WriteLine("==============================================================================");

            foreach (var number in notfirst3)
            {
                Console.WriteLine(line, number.ToString());
            }

        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()  //Good
        {

            List<Customer> customers = new List<Customer>(DataLoader.LoadCustomers());

            var customerwa = customers.Where(c => c.Region == "WA");
            foreach (var customer in customerwa)
            {
                Console.WriteLine(customer.CompanyName);
                var orders = customer.Orders.OrderByDescending(o => o.OrderDate).Take(1);
                Console.WriteLine("\tOrders");
                foreach (var order in orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()  //Good
        {

            List<int> numbers = new List<int>(DataLoader.NumbersC);

            var notfirst3 = numbers.TakeWhile(o => o < 6);

            string line = "{0,-5}";
            Console.WriteLine(line, "Number");
            Console.WriteLine("==============================================================================");

            foreach (var number in notfirst3)
            {
                Console.WriteLine(line, number.ToString());
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()  //Good
        {

            List<int> numbers = new List<int>(DataLoader.NumbersC);

            var allafter3 = numbers.SkipWhile(o => o % 3 != 0).Skip(1);
            
            string line = "{0,-5}";
            Console.WriteLine(line, "Number");
            Console.WriteLine("==============================================================================");

            foreach (var number in allafter3)
            {
                Console.WriteLine(line, number.ToString());
            }

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var alpha = from p in products
                             orderby p.ProductName ascending
                             select p;

            PrintProductInformation(alpha);

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var alpha = from p in products
                        orderby p.UnitsInStock descending
                        select p;

            PrintProductInformation(alpha);

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var alpha = from p in products
                        orderby p.Category, p.UnitPrice descending
                        select p;

            PrintProductInformation(alpha);

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()  //Good
        {

            List<int> numbers = new List<int>(DataLoader.NumbersB);

            numbers.Reverse();

            string line = "{0,-5}";
            Console.WriteLine(line, "Number");
            Console.WriteLine("==============================================================================");

            foreach (var number in numbers)
            {
                Console.WriteLine(line, number);
            }

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()  //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var alpha = from p in products
                        group p by p.Category into g
                        select g;

            foreach (var c in alpha)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(c.Key);
                Console.WriteLine();
                Console.WriteLine("\tProducts");
                foreach (var product in c)
                {
                    Console.WriteLine("\t{0} ", product.ProductName);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }

        }
        
        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()  //Good
        {

            List<Customer> customers = new List<Customer>(DataLoader.LoadCustomers());

            var alpha = customers.OrderBy(c=>c.CompanyName).Select(c => c.Orders.OrderBy(o => o.OrderDate.Year).ThenBy(o => o.OrderDate.Month));

            foreach (var c in alpha)
            {
                Console.WriteLine(c);
                Console.WriteLine("\tOrders");
                foreach (var order in c)
                {
                    Console.WriteLine("\t{0} {1} {2,10:c}", order.OrderDate.Year, order.OrderDate.Month, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }

        }
        
        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var unique = (from p in products
                          select p.Category)
                          .Distinct();

            string line = "{0,-5}";
            Console.WriteLine(line, "Category");
            Console.WriteLine("==============================================================================");

            foreach (var product in unique)
            {
                Console.WriteLine(line, product);
            }

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            bool ProductExists = products.Any(p => p.ProductID == 789);

            Console.WriteLine(ProductExists);

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            //find products with zero on hand
            //then print category of those products

            var cat1 = from p in products
                       where p.UnitsInStock == 0
                       group p by p.Category into g
                       select g;

            foreach (var c in cat1)
            {
                Console.WriteLine(c.Key);
            }

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25() //Error
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            //find products with zero on hand
            //then print category of those products

            //var killme = products.OrderBy(s => s.UnitsInStock).SkipWhile(o => o.UnitsInStock == 0).Select(c=>c.Category).Distinct();

            //var bluntforcetrauma = (from p in products
            //           where p.UnitsInStock > 0
            //           group p by p.Category into g
            //           select new { g.Key}).Aggregate(func: (Count, items) => items);

            //var categories = products.Where(s => s.UnitsInStock == 0).GroupBy(o => o.Category);

            //var clean = ctb.RemoveAll(i => !categories.Select(y=>y.Key).Contains(i.Key));

            //var clean1 = ctb.Intersect(categories);

            //var cat2 = products.Where(n => n.UnitsInStock > 0).GroupBy(u => u.Category).Select(c=>c.Key);

            var catWithProductsOutofStock = from p in products
                       where p.UnitsInStock == 0
                       group p by p.Category into g
                       select g.Key;

            var allCategories = from p in products
                                group p by p.Category into g
                                select g.Key;

            var allCatWithNoProductsOutofStock = allCategories.Except(catWithProductsOutofStock);


            foreach (var c in allCatWithNoProductsOutofStock)
            {
                Console.WriteLine(c);
                //Console.WriteLine(c.ProductName);
                //Console.WriteLine(c.UnitsInStock);
            }
            //Any(x => x.UnitsInStock != 0)
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26() //Good
        {

            List<int> numbers = new List<int>(DataLoader.NumbersA);

            var count = numbers.Count(n => n % 2 != 0);

            Console.WriteLine(count);

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27() //Good
        {

            List<Customer> customers = new List<Customer>(DataLoader.LoadCustomers());

            var unique = customers
                .GroupBy(cp => cp.CustomerID)
                .Select(p => new
                {
                    CustomerId = p.Key,
                    OrderCount = p.SelectMany(c => c.Orders).Count()
                });

            Console.WriteLine("==============================================================================");
            foreach (var c in unique)
            {
                
                Console.WriteLine(c.CustomerId);
                Console.WriteLine(c.OrderCount);

            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var unique = products
                .GroupBy(cp => cp.Category)
                .Select(p => new
                {
                    Category = p.Key,
                    ProductCount = p.Select(c => c.ProductID).Distinct().Count()
                });

            Console.WriteLine("==============================================================================");

            foreach (var c in unique)
            {
                
                Console.WriteLine(c.Category);
                Console.WriteLine(c.ProductCount);

            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()  //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var unique = products
                .GroupBy(cp => cp.Category)
                .Select(p => new
                {
                    Category = p.Key,
                    CategoryUnits = p.Sum(c => c.UnitsInStock)
                });

            Console.WriteLine("==============================================================================");
            foreach (var c in unique)
            {
                
                Console.WriteLine(c.Category);
                Console.WriteLine(c.CategoryUnits);

            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var unique = products
                .GroupBy(cp => cp.Category)
                .Select(p => new
                {
                    Category = p.Key,
                    LowestPrice = p.Min(c => c.UnitPrice)
                });

            Console.WriteLine("==============================================================================");
            foreach (var c in unique)
            {
                
                Console.WriteLine(c.Category);
                Console.WriteLine(c.LowestPrice);

            }

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31() //Good
        {

            List<Product> products = new List<Product>(DataLoader.LoadProducts());

            var unique = products
                .GroupBy(cp => cp.Category)
                .Select(p => new
                {
                    Category = p.Key,
                    AvgPrice = p.Average(c => c.UnitPrice)
                }).OrderByDescending(z=>z.AvgPrice).Take(3);

            Console.WriteLine("==============================================================================");
            foreach (var c in unique)
            {
                
                Console.WriteLine(c.Category);
                Console.WriteLine(c.AvgPrice);

            }

        }
    }
}
