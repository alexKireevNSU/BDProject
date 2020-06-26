using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Controllers.SQLUtils.Entities;

namespace Client.Controllers
{
    class SuppliesController
    {
        private static SuppliesController instance;
        private static object syncRoot = new Object();

        protected SuppliesController()
        {
        }
        public static SuppliesController GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new SuppliesController();
                }
            }
            return instance;
        }

        internal void DeleteSupply(Supply supply)
        {
            // empty ...
        }

        internal void AddSupply(Supply supply)
        {
            if (supply == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Supplies/Insert", supply);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal List<Supply> GetSupplies(TradePoint tradePoint)
        {
            return new List<Supply>();
        }
    }
}
