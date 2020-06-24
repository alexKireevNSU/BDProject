using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Controllers.SQLUtils.Entities
{
    public class ObjectRelation
    {
        public int ObjRelId { set; get; } = -1;
        public int Parent { set; get; } = -1;
        public int Id { set; get; } = -1;
    }
}