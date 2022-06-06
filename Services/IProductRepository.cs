using System.Collections.Generic;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    public interface IProductRepository
    {
        List<Product> Products { get; set; }
        List<Product> ReadAll();

        Product GetProduct(int? id);

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int? id);

    }
}
