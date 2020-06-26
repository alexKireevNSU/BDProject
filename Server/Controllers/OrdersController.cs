using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllOrders()).GetResult(),
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public bool Insert(Order order)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertOrder(order), true);
            return true;
        }

        [HttpPost]
        public bool Update(Order order)
        {
            if (order.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateOrder(order), true);
            return true;
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteOrder(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }
    }
}