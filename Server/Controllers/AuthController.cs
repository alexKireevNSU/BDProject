using Server.Controllers.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public JsonResult Index()
        {
            var result = SQLConnectionHandler.GetInstance().Execute(SQLCommand.SelectTest()).GetResult();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}