using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllSuppliers()).GetResult(),
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public bool Insert(Supplier supplier)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertSupplier(supplier), true);
            return true;
        }

        [HttpPost]
        public bool Update(Supplier supplier)
        {
            if (supplier.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateSupplier(supplier), true);
            return true;
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteSupplier(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }
    }
}