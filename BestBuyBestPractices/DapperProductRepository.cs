using Dapper;
using System.Data;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }




        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM Products;");
        }

        void IProductRepository.CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name," +
                                                "Price," +
                                                "CateagoryID)" +
                                                "VALUES" +
                                                "(@name," +
                                                "@price," +
                                                "@categoryID);",
                                                new { name, price, categoryID });


        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products" +
                                              "WHERE ProductID = @id;",
                                               new { id });
        }
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products" +
                          "SET Name = @name," +
                          "Price = @price," +
                          "CateagoryID = @catID," +
                          "OnSale = @onSale," +
                          "StockLevel = @stock" +
                          "WHERE ProductID = @id;",
                      new
                      {
                          name = product.Name,
                          price = product.Price,
                          catID = product.CategoryID,
                          onSale = product.OnSale,
                          stock = product.StockLevel
                      });
        }
        public void DeleteProduct(int id)
        {

        }
    }

}


