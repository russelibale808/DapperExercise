using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DapperDemoExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            //var repo = new DapperDepartmentRepository(conn);

            //var depts = repo.GetAllDepartments();

            //foreach (var dept in depts)
            //{
            //    Console.WriteLine(dept.Name);
            //}

            //Console.WriteLine();
            //Console.WriteLine("Enter a new department name");

            //var newDept = Console.ReadLine();

            //repo.InsertDepartment(newDept);

            //Console.WriteLine();

            //foreach (var dept in depts)
            //{
            //    Console.WriteLine(depts);

            //}

            var productRepository = new DapperProductRepository(conn);
            var products = productRepository.GetAllProducts();

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductID);
            //    Console.WriteLine(product.Name);
            //    Console.WriteLine(product.Price);
            //    Console.WriteLine(product.CategoryID);
            //    Console.WriteLine(product.OnSale);
            //    Console.WriteLine(product.StockLevel);

            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            foreach(var prod in products)
            {
                Console.WriteLine(prod.CategoryID);
                Console.WriteLine(prod.Name);
                Console.WriteLine(prod.Price);
                Console.WriteLine();
            }

            Console.WriteLine("Enter new product name");
            var prodName = Console.ReadLine();

            Console.WriteLine("Enter new product's price");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Category ID");
            var catID = int.Parse(Console.ReadLine());

            productRepository.CreateProduct(prodName, prodPrice, catID);

            products = productRepository.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine(prod.CategoryID);
                Console.WriteLine(prod.Name);
                Console.WriteLine(prod.Price);
                Console.WriteLine();
            }

        }
    }
}