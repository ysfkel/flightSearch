using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application1.Models
{

    public class LUISClient
    {
        public static async Task<FlightLUIS> ParseInput(string input)
        {
            string strRet = string.Empty;
            string strEscape = Uri.EscapeDataString(input);

            using (var client = new HttpClient())
            {
                 string uri = "https://api.projectoxford.ai/luis/v1/application?id=9a965be9-3315-418f-a9f2-7a035dab5150&subscription-key=beb9cf1fb1d848a99601ffdcca669e39&q=" + strEscape;
                HttpResponseMessage msg = await client.GetAsync(uri);
                if(msg.IsSuccessStatusCode)
                {
                    var jsonResponse = await msg.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<FlightLUIS>(jsonResponse);
                    return data;
                }
            }
            return null;
        }
    }
    public class FlightLUIS
    {
        public string query { get; set; }
        public Intent[] intents { get; set; }
        public Entity[] entities { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }
    }

}
