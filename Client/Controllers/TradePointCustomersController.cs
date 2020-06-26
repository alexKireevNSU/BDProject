using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Controllers.SQLUtils.Entities;

namespace Client.Controllers
{
    class TradePointCustomersController
    {
        private static TradePointCustomersController instance;
        private static object syncRoot = new Object();

        protected TradePointCustomersController()
        {
        }
        public static TradePointCustomersController GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new TradePointCustomersController();
                }
            }
            return instance;
        }

        internal List<TradePointCustomer> GetTradesPointCustomers()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsCustomers").Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePointCustomer> result = new List<TradePointCustomer>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradesPointCustomerFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private TradePointCustomer GetTradesPointCustomerFromRow(List<object> list)
        {
            return new TradePointCustomer
            {
                Id = (int)(long)list[0],
                Name = (string)list[1],
                Description = (string)list[2]
            };
        }

        internal void DeleteTradePointCustomer(TradePointCustomer tradePointCustomer)
        {
            if (tradePointCustomer == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsCustomers/Delete/" + tradePointCustomer.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }

        internal void AddTradePointCustomer(TradePointCustomer tradePointCustomer)
        {
            if (tradePointCustomer == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsCustomers/Insert", tradePointCustomer);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void EditTradePointCustomer(TradePointCustomer tradePointCustomer)
        {
            if (tradePointCustomer == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsCustomers/Update", tradePointCustomer);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
