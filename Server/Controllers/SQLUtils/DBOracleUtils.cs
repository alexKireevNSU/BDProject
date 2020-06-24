using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers.SQLUtils
{
    class DBOracleUtils
    {
        public static OracleConnection
                       GetDBConnection(string host, int port, String sid, String user, String password)
        {

            Console.WriteLine("Getting Connection ...");

            // 'Connection String' подключается напрямую к Oracle.
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;


            OracleConnection conn = new OracleConnection(connString);

            //conn.ConnectionString = connString;

            return conn;
        }
    }
}