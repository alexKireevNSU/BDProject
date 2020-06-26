using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Controllers.SQLUtils.Entities;

namespace Client.Controllers
{
    class ProductsController
    {
        private static ProductsController instance;
        private static object syncRoot = new Object();

        protected ProductsController()
        {
        }
        public static ProductsController GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new ProductsController();
                }
            }
            return instance;
        }

        internal List<Product> GetProducts()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("Products").Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<Product> result = new List<Product>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetProductFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private Product GetProductFromRow(List<object> list)
        {
            return new Product
            {
                Id = (int)(long)list[0],
                Name = (string)list[1]
            };
        }

        internal void DeleteProduct(Product product)
        {
            if (product == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("Products/Delete/" + product.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }

        internal void AddProduct(Product product)
        {
            if (product == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Products/Insert", product);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void EditProduct(Product product)
        {
            if (product == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Products/Update", product);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
