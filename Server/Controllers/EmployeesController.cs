using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllEmployees()).GetResult(), 
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public bool Insert(Employee employee)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertEmployee(employee));
            return true;
        }

        [HttpPost]
        public bool Update(Employee employee)
        {
            if (employee.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateEmployee(employee));
            return true;
        }

        [HttpPost]
        public bool Delete(Employee employee)
        {
            if (employee.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteEmployee(employee));
            return true;
        }
    }
}