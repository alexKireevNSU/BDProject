using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TradePointsProductsController : Controller
    {
        // GET: TradePointsProducts
        [HttpGet]
        public JsonResult Get(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectTradePointProducts(id)).GetResult(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteTradePointProduct(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool Insert(TradePointProduct product)
        {
            if (product.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertTradePointProduct(product), true);
            return true;
        }
        [HttpPost]
        public bool Update(TradePointProduct product)
        {
            if (product.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateTradePointProduct(product), true);
            return true;
        }
    }
}