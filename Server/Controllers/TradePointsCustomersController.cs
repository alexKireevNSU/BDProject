using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TradePointsCustomersController : Controller
    {
        // GET: TradePointsCustomers
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllTradePointsCustomers()).GetResult(),
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public bool Insert(TradePointCustomer customer)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertTradePointsCustomer(customer), true);
            return true;
        }

        [HttpPost]
        public bool Update(TradePointCustomer customer)
        {
            if (customer.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateTradePointsCustomer(customer), true);
            return true;
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteTradePointsCustomer(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }
    }
}