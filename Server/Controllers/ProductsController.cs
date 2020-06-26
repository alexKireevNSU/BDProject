using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllProducts()).GetResult(),
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public bool Insert(Product product)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertProduct(product), true);
            return true;
        }

        [HttpPost]
        public bool Update(Product product)
        {
            if (product.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateProduct(product), true);
            return true;
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteProduct(id), true).GetResult(), JsonRequestBehavior.AllowGet);
        }
    }
}