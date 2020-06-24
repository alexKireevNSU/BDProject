using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    public class TradePoint
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; }
        public TradePointType Type { get; set; }
    }
}