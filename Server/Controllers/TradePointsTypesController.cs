using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TradePointsTypesController : Controller
    {
        // GET: TradePointsTypes
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllTradePointsTypes()).GetResult(),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool Insert(TradePointType type)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertTradePointType(type), true);
            return true;
        }

        [HttpPost]
        public bool Update(TradePointType type)
        {
            if (type.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateTradePointType(type), true);
            return true;
        }

        [HttpPost]
        public bool Delete(TradePointType type)
        {
            if (type.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteTradePointType(type), true);
            return true;
        }

    }
}