using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Server.Controllers.SQLUtils
{
    class SQLConnectionHandler
    {
        private static SQLConnectionHandler instance;
        private static object syncRoot = new Object();
        private OracleConnection connection = null;
        private DataReaderEncoder encoder;

        protected SQLConnectionHandler(){}

        public static SQLConnectionHandler GetInstance()
        {
            if (instance == null)
            {
                lock(syncRoot)
                {
                    if (instance == null)
                        instance = new SQLConnectionHandler();
                }
            }
            return instance;
        }

        public void SetConnection(OracleConnection conn)
        {
            this.connection = conn;
        }

        public SQLConnectionHandler Execute(String command)
        {
            try
            {
                if (connection != null)
                {
                    OracleCommand cmd = new OracleCommand(command, connection);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        encoder = new DataReaderEncoder(reader);
                        encoder.encode();
                    }
                }
            }
            catch(Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                Console.WriteLine(ex.DataSource);
                return this;
            }
            return this;
        }

        public SQLResult GetResult()
        {
            return encoder.GetData();
        }
    }
}
