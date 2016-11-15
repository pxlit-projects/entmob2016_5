using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public interface IProductDataService
    {
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        void AddProduct(Product product);
        int GetMaxProductId();
    }
}
