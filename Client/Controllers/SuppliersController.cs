using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Controllers.SQLUtils.Entities;

namespace Client.Controllers
{
    class SuppliersController
    {
        private static SuppliersController instance;
        private static object syncRoot = new Object();

        protected SuppliersController()
        {
        }
        public static SuppliersController GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new SuppliersController();
                }
            }
            return instance;
        }

        internal List<Supplier> GetSuppliers()
        {
            var sqlResult = ServerHandler.GetInstance().GetRequest("Suppliers").Result;
            if (sqlResult.Exception.Length != 0)
            {
                throw new Exception(sqlResult.Exception);
            }
            List<Supplier> result = new List<Supplier>();
            for (int i = 0; i < sqlResult.Rows.Count; ++i)
            {
                result.Add(GetSupplierFromRow(sqlResult.Rows[i]));
            }
            return result;
        }

        private Supplier GetSupplierFromRow(List<object> list)
        {
            return new Supplier
            {
                Id = (int)(long)list[0],
                Name = (string)list[1]
            };
        }

        internal void DeleteSupplier(Supplier supplier)
        {
            if (supplier == null)
                return;
            try
            {
                var sqlResult = ServerHandler.GetInstance().GetRequest("Suppliers/Delete/" + supplier.Id).Result;
            }
            catch (Exception ex)
            {
                return;
            }

            return;
        }

        internal void AddSupplier(Supplier supplier)
        {
            if (supplier == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Suppliers/Insert", supplier);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        internal void EditSupplier(Supplier supplier)
        {
            if (supplier == null)
                return;
            try
            {
                bool res = ServerHandler.GetInstance().PostRequest("Suppliers/Update", supplier);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
