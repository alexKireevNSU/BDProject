using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TradePointsSalesController : Controller
    {
        [HttpGet]
        public JsonResult Get(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectTradePointSales(id)).GetResult(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteTradePointSale(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool Insert(TradePointSale sale)
        {
            if (sale.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertTradePointSale(sale), true);
            return true;
        }
        [HttpPost]
        public bool Update(TradePointSale sale)
        {
            if (sale.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateTradePointSale(sale), true);
            return true;
        }
    }
}