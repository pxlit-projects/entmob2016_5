﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.DAL
{
    public interface IProductRepository
    {
        void DeleteProduct(Product product);
        Product GetProduct();
        Product GetProductById(int id);
        List<Product> GetProducts();
        List<Product> GetProductsByWarehouse(Warehouse warehouse);
        void UpdateProduct(Product product);
        void AddProduct(Product product);
    }
}
