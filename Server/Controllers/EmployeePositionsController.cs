using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers.SQLUtils
{
    public class EmployeePositionsController : Controller
    {
        // GET: EmployeePositions
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllEmployeesPositions()).GetResult(),
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public bool Insert(EmployeePosition position)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertEmployeesPositions(position), true);
            return true;
        }

        [HttpPost]
        public bool Update(EmployeePosition position)
        {
            if (position.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateEmployeesPositions(position), true);
            return true;
        }

        [HttpPost]
        public bool Delete(EmployeePosition position)
        {
            if (position.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteEmployeesPositions(position), true);
            return true;
        }
    }
}