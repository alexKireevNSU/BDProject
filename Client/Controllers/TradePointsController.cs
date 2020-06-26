using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    class TradePointsController
    {
        private static TradePointsController instance;
        private static object syncRoot = new Object();
        private List<TradePointType> tradePointTypes = new List<TradePointType>();

        protected TradePointsController()
        {
        }
        public static TradePointsController GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new TradePointsController();
                }
            }
            return instance;
        }

        public List<TradePoint> GetTradePoints()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePoints").Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePoint> result = new List<TradePoint>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradePointFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        public List<TradePointType> GetTradePointTypes()
        {
            if (tradePointTypes.Count == 0)
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsTypes").Result;
                if (sqlResult.Exception.Length != 0)
                {
                    throw new Exception(sqlResult.Exception);
                }
                for (int i = 0; i < sqlResult.Rows.Count; ++i)
                {
                    tradePointTypes.Add(GetTradePointTypeFromRow(sqlResult.Rows[i]));
                }
            }
            return tradePointTypes;
        }

        private TradePointType GetTradePointTypeFromRow(List<object> row)
        {
            return new TradePointType
            {
                Id = (int)(long)row[0],
                Name = (string)row[1],
                IsBarren = ((string)row[2]).Equals("Y")
            };
        }

        public List<TradePoint> GetParents()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePoints/GetParents").Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePoint> result = new List<TradePoint>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradePointFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        public TradePoint GetParent(TradePoint tradePoint)
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePoints/GetParent/" + tradePoint.Id.ToString()).Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePoint> result = new List<TradePoint>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradePointFromRow(sqlResult.Rows[i]));
            }
            if (result.Count == 0)
                return null;
            TradePoint res;
            try
            {
                res = result.First();
            }
            catch(Exception ex)
            {
                res = null;
            }
            return res;
        }

        private TradePoint GetTradePointFromRow(List<object> row)
        {
            int size = 0;
            int noc = 0;
            if (row[5] != null)
                size = (int)(long)row[5];
            if (row[6] != null)
                noc = (int)(long)row[6];
            return new TradePoint
            {
                Id = (int)(long)row[0],
                Name = (string)row[1],
                FullName = (string)row[2],
                Type = new TradePointType
                {
                    Id = (int)(long)row[3],
                    Name = (string)row[4],
                    IsBarren = ((string)row[7]).Equals("Y")
                },
                Size = size,
                NumberOfCounters = noc
            };

        }

        internal void AddTradePoint(TradePoint tradePoint)
        {
            if (tradePoint == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePoints/Insert", tradePoint);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void EditTradePoint(TradePoint tradePoint)
        {
            if (tradePoint == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePoints/Update", tradePoint);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void DeleteTradePoint(TradePoint tradePoint)
        {
            if (tradePoint == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePoints/Delete", tradePoint);
            }
            catch (Exception ex)
            {
                return;
            }
        }


        public List<TradePointPayment> GetTradePointPayments(TradePoint tradePoint)
        {
            if (tradePoint == null)
                return new List<TradePointPayment>();
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsPayments/Get/" + tradePoint.Id).Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePointPayment> result = new List<TradePointPayment>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradePointPaymentFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private TradePointPayment GetTradePointPaymentFromRow(List<object> row)
        {
            return new TradePointPayment
            {
                Id = (int)(long)row[0],
                TradePointId = (int)(long)row[1],
                Name = (string)row[2],
                Sum = Convert.ToDouble(row[3]),
                Date = (DateTime)row[4]
            };
        }

        public void AddTradePointPayment(TradePointPayment payment)
        {
            if (payment == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsPayments/Insert", payment);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void EditTradePointPayment(TradePointPayment payment)
        {
            if (payment == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsPayments/Update", payment);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void DeleteTradePointPayment(TradePointPayment payment)
        {
            if (payment == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsPayments/Delete/" + payment.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }

        //----------------TODO

        internal void AddTradePointSale(TradePointSale tradePointSale)
        {
            if (tradePointSale == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsSales/Insert", tradePointSale);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void EditTradePointSale(TradePointSale tradePointSale)
        {
            if (tradePointSale == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsSales/Update", tradePointSale);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void AddTradePointRequest(TradePointRequest tradePointRequest)
        {
            if (tradePointRequest == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsRequests/Insert", tradePointRequest);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void EditTradePointRequest(TradePointRequest tradePointRequest)
        {
            if (tradePointRequest == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsRequests/Update", tradePointRequest);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void AddTradePointProduct(TradePointProduct tradePointProduct)
        {
            if (tradePointProduct == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsProducts/Insert", tradePointProduct);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void EditTradePointProduct(TradePointProduct tradePointProduct)
        {
            if (tradePointProduct == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("TradePointsProducts/Update", tradePointProduct);
            }
            catch (Exception ex)
            {
                return;
            }
        }


        internal List<TradePointSale> GetTradePointSales(TradePoint tradePoint)
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsSales/Get/" + tradePoint.Id).Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePointSale> result = new List<TradePointSale>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradePointSaleFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private TradePointSale GetTradePointSaleFromRow(List<object> list)
        {
            return new TradePointSale
            {
                Id = (int)(long)list[0],
                TradePointProduct = new TradePointProduct() { Id = (int)(long)list[3], TradePoint = new TradePoint() { Id = (int)(long)list[1], Name = (string)list[2] } },
                Count = (int)(long)list[6],
                Date = (DateTime)list[7]
            };
        }

        internal List<TradePointRequest> GetTradePointRequests(TradePoint tradePoint)
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsRequests/Get/" + tradePoint.Id).Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePointRequest> result = new List<TradePointRequest>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradePointRequestFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private TradePointRequest GetTradePointRequestFromRow(List<object> list)
        {
            return new TradePointRequest
            {
                Id = (int)(long)list[0],
                TradePoint = new TradePoint() { Id = (int)(long)list[1], FullName = (string)list[2] },
                Product = new SupplierProduct()
                {
                    Product = new Product()
                    {
                        Id = (int)(long)list[3],
                        Name = (string)list[4]
                    },
                    Supplier = new Supplier()
                    {
                        Id = (int)(long)list[5],
                        Name = (string)list[6]
                    },
                    Count = (int)(long)list[7]
                }
            };
        }

        internal List<TradePointProduct> GetTradePointProducts(TradePoint tradePoint)
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsProducts/Get/" + tradePoint.Id).Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<TradePointProduct> result = new List<TradePointProduct>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetTradePointProductFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private TradePointProduct GetTradePointProductFromRow(List<object> list)
        {
            return new TradePointProduct
            {
                Id = (int)(long)list[0],
                TradePoint = new TradePoint() { Id = (int)(long)list[1], FullName = (string)list[2] },
                Product = new Product()
                {
                    Id = (int)(long)list[3],
                    Name = (string)list[4]
                },
                Supplier = new Supplier()
                {
                    Id = (int)(long)list[5],
                    Name = (string)list[6]
                },
                Count = (int)(long)list[7],
                Price = (int)(long)list[8]
            };
        }

        internal void DeleteTradePointSale(TradePointSale tradePointSale)
        {
            if (tradePointSale == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsSales/Delete/" + tradePointSale.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }

        internal void DeleteTradePointProduct(TradePointProduct tradePointProduct)
        {
            if (tradePointProduct == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsProducts/Delete/" + tradePointProduct.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }

        internal void DeleteTradePointRequest(TradePointRequest tradePointRequest)
        {
            if (tradePointRequest == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("TradePointsRequests/Delete/" + tradePointRequest.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }
    }
}
