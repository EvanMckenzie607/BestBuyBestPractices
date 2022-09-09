


using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);
#region Departent Section
var departmentRepo = new DapperDepartmentRepository(conn);



var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();

}
#endregion

#region Product Section
var productRepository = new DapperProductRepository(conn);

var products = productRepository.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine($"${product.Price}");
    Console.WriteLine(product.CategoryID);
    if (product.OnSale == true)
    {
        Console.WriteLine("On Sale");
    }
    else
    {
        Console.WriteLine("Not On Sale");
    }

    Console.WriteLine($"Quantity On Hand: {product.StockLevel}");
    Console.WriteLine();
    Console.WriteLine();

}

#endregion