using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Server.Controllers.SQLUtils.Entities;
using System.Net.Http.Formatting;
using Server.Controllers.SQLUtils;

namespace Client.Controllers
{
    class ServerHandler
    {
        private static ServerHandler instance;
        private static object syncRoot = new Object();
        private HttpClient client;
        protected ServerHandler()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Properties.Settings.Default.BaseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static ServerHandler GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new ServerHandler();
                }
            }
            return instance;
        }
        public async Task<SQLResult> GetRequest(string request)
        {
            HttpResponseMessage responseMessage = client.GetAsync(request).Result;
            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }
            return responseMessage.Content.ReadAsAsync<SQLResult>(new[] { new JsonMediaTypeFormatter() }).Result;
        }

        public bool PostRequest(string request, object obj)
        {
            HttpResponseMessage responseMessage = client.PostAsJsonAsync(request, obj).Result;
            if(responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
