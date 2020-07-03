using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Server.Controllers.SQLUtils
{
    public class DBUtils
    {
        public static OracleConnection GetDBConnection()
        {   
            
            string host = WebConfigurationManager.AppSettings.Get("host");
            int port = Int32.Parse(WebConfigurationManager.AppSettings.Get("port"));
            string sid = WebConfigurationManager.AppSettings.Get("sid");
            string user = WebConfigurationManager.AppSettings.Get("user");
            string password = WebConfigurationManager.AppSettings.Get("password");

            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }
}