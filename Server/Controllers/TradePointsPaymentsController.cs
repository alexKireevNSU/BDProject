using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TradePointsPaymentsController : Controller
    {
        // GET: TradePointsPayments
        [HttpGet]
        public JsonResult Get(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectTradePointPayments(id)).GetResult(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteTradePointPayment(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool Insert(TradePointPayment payment)
        {
            if (payment.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertTradePointPayment(payment), true);
            return true;
        }
        [HttpPost]
        public bool Update(TradePointPayment payment)
        {
            if (payment.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateTradePointPayment(payment), true);
            return true;
        }
    }
}