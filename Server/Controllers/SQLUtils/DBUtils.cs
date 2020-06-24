using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Controllers.SQLUtils
{
    public class DBUtils
    {
        public static OracleConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 1521;
            string sid = "orclproj";
            string user = "c##alexkireev";
            string password = "tiger";

            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }
}