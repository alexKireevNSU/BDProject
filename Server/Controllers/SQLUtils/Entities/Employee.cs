using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    public class Employee
    {
        public int Id { set; get; } = -1;
        public string Name { set; get; }
        public EmployeePosition Position { set; get; }
        public TradePoint TradePoint { set; get; }
    }
}