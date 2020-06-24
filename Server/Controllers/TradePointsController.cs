﻿using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TradePointsController : Controller
    {
        // GET: TradePoints
        public JsonResult Index()
        {
            return Json(SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllTradePoints()).GetResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool Insert(TradePoint point)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertTradePoint(point));
            return true;
        }

        [HttpPost]
        public bool Update(TradePoint point)
        {
            if (point.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateTradePoint(point));
            return true;
        }

        [HttpPost]
        public bool Delete(TradePoint point)
        {
            if (point.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteTradePoint(point));
            return true;
        }
    }
}