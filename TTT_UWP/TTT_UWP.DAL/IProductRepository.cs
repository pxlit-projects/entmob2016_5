using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Model;

namespace TTT.DAL
{
    public interface IProductRepository
    {
        void DeleteProduct(Product product);
        Product GetProduct();
        Product GetProductById(int id);
        List<Product> GetProducts();
        List<Product> GetProductsByWarehouse(Warehouse warehouse);
        void UpdateProduct(Product product);
    }
}
