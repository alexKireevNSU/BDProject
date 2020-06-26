using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography;

namespace Server.Controllers.SQLUtils
{
    class SQLConnectionHandler
    {
        private static SQLConnectionHandler instance;
        private static object syncRoot = new Object();
        private OracleConnection connection = null;
        private DataReaderEncoder encoder;
        private string exception = "";
        private Dictionary<string, SQLResult> cachedCommands = new Dictionary<string, SQLResult>();
        private string lastCommand = String.Empty;
        

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

        public SQLConnectionHandler Execute(String command, bool dropCache = false)
        {
            lastCommand = command;
            if (dropCache)
                cachedCommands.Clear();

            SQLResult cachedResult = null;
            if (cachedCommands.ContainsKey(command))
            {
                try
                {
                    cachedResult = cachedCommands[command];
                    if (cachedResult != null)
                        encoder.SetData(cachedResult);
                    return this;
                }
                catch (Exception ex)
                {}
            }
            
            exception = "";
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
                exception = ex.DataSource;
                return this;
            }
            
            return this;
        }

        public SQLResult GetResult()
        {
            var r = encoder.GetData();
            r.Exception = exception;
            cachedCommands[lastCommand] = r;
            return r;
        }
    }
}
