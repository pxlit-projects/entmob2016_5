using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Domainclasses;

namespace TTT_UWP.Classes
{
    public class TTTDataService
    {
        private static HttpClient client = new HttpClient();

        public TTTDataService()
        {

        }

        public List<Warehouse> GetAllWarehouses()
        {
            string TTTapi = "url";
            var uri = new Uri(String.Format("{0}?format=json", TTTapi));
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var root = JsonConvert.DeserializeObject<RootObject<Warehouse>>(result);
            return root.results;
        }

    }
}
