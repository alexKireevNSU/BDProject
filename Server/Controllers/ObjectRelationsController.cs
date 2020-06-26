using Server.Controllers.SQLUtils;
using Server.Controllers.SQLUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class ObjectRelationsController : Controller
    {
        // GET: ObjectRelations
        public JsonResult Index()
        {
            return Json(
                SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.SelectAllObjectsRelations()).GetResult(),
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public bool Insert(ObjectRelation relation)
        {
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.InsertObjectsRelations(relation), true);
            return true;
        }

        [HttpPost]
        public bool Update(ObjectRelation relation)
        {
            if (relation.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.UpdateObjectsRelations(relation), true);
            return true;
        }

        [HttpPost]
        public bool Delete(ObjectRelation relation)
        {
            if (relation.Id < 0)
                return false;
            SQLConnectionHandler.GetInstance()
                    .Execute(SQLCommand.DeleteObjectsRelations(relation), true);
            return true;
        }
    }
}