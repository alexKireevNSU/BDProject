using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Controllers.SQLUtils
{
    public class SQLResult
    {
        public SQLResult(List<string> colsNames, List<List<object>> rows)
        {
            this.ColsNames = colsNames;
            this.Rows = rows;
        }
        public SQLResult()
        {
        }
        [JsonProperty("ColsNames")]
        public List<string> ColsNames { get; set; } = new List<string>();
        [JsonProperty("Rows")]
        public List<List<object>> Rows { get; set; } = new List<List<object>>();
        [JsonProperty("Exception")]
        public string Exception { get; set; } = "";
    }
}