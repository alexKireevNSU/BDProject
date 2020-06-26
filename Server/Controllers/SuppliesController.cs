using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class SuppliesController : Controller
    {
        [HttpPost]
        public bool Insert(Supply supply)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertSupply(supply), true);
            return true;
        }
    }
}