using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TradePointsRequestsController : Controller
    {
        [HttpGet]
        public JsonResult Get(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectTradePointRequests(id)).GetResult(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteTradePointRequest(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool Insert(TradePointRequest request)
        {
            if (request.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertTradePointRequest(request), true);
            return true;
        }
        [HttpPost]
        public bool Update(TradePointRequest request)
        {
            if (request.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateTradePointRequest(request), true);
            return true;
        }
    }
}