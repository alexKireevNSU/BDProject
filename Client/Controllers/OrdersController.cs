using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Controllers.SQLUtils.Entities;

namespace Client.Controllers
{
    class OrdersController
    {
        private static OrdersController instance;
        private static object syncRoot = new Object();

        protected OrdersController()
        {
        }
        public static OrdersController GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OrdersController();
                }
            }
            return instance;
        }

        internal List<Order> GetOrders()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("Orders").Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<Order> result = new List<Order>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetOrderFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private Order GetOrderFromRow(List<object> list)
        {
            return new Order()
            {
                Id = (int)(long)list[0],
                Product = new SupplierProduct()
                {
                    Product = new Product()
                    {
                        Id = (int)(long)list[1],
                        Name = (string)list[2]
                    },
                    Supplier = new Supplier()
                    {
                        Id = (int)(long)list[3],
                        Name = (string)list[4]
                    },
                    Count = (int)(long)list[5]
                },
                Date = (DateTime)list[6],
                Request = new TradePointRequest()
                {
                    Id = (int)(long)list[7]
                }
            };
        }

        internal void DeleteOrder(Order order)
        {
            if (order == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("Orders/Delete/" + order.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }

        internal void AddOrder(Order order)
        {
            if (order == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Orders/Insert", order);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void EditOrder(Order order)
        {
            if (order == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Orders/Update", order);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
