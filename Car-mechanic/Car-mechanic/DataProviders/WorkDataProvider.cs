using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Car_mechanic.Modells;
using Newtonsoft.Json;

namespace Car_mechanic.DataProviders
{
    class WorkDataProvider
    {
        private static string _URL = "http://localhost:1154/api/work";

        public static IList<Work> GetAll()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_URL).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var works = JsonConvert.DeserializeObject<List<Work>>(rawData);
                    return works;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateWork(Work work)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(work);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_URL, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
