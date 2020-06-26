using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Server.Controllers.SQLUtils
{
    class DataReaderEncoder
    {
        public DataReaderEncoder(OracleDataReader reader)
        {
            this.reader = reader;
        }

        public DataReaderEncoder encode()
        {
            var hasRows = reader.HasRows;
            result = new SQLResult();
            if (!hasRows)
                return this;
            bool isFirst = true;
            while(reader.Read())
            {
                result.Rows.Add(new List<object>());
                for(int i = 0; i < reader.FieldCount; ++i)
                {
                    if(isFirst)
                        result.ColsNames.Add(reader.GetName(i));
                    result.Rows[result.Rows.Count - 1].Add(reader[i]);
                }
                isFirst = false;
            }
            return this;
        }

        public SQLResult GetData()
        {
            return result;
        }

        public void SetData(SQLResult data)
        {
            result = data;
        }

        private OracleDataReader reader;
        private SQLResult result;
    }
}
