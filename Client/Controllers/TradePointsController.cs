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
            return result.First();
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

    }
}
