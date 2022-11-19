using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoExercise
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@prodName, @prodPrice, @catID);",
                new {prodName = name,
                     prodPrice = price,
                     catID = categoryID});

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProductId(int productid)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE productid = @id;", 
                new {id = productid });
        }

        public void UpdateProduct(Product product)
        {

            _conn.Execute("UPDATE products" +
                          "SET Name  = @name," +
                          "Price = @price, " +
                          "CategoryID = @catID, " +
                          "OnSale = @onSale, " +
                          "StockLevel = @stock" +
                          "WHERE ProductID = @id",
                new
                {
                    id = product.ProductID,
                    name = product.Name,
                    price = product.Price,
                    categoryID = product.CategoryID,
                    onSale = product.OnSale,
                    stock = product.StockLevel
                });
        }
    }
}
