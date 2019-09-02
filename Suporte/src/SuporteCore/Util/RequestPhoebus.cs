using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace SuporteCore.Util
{
    public class RequestPhoebus
    {
        public static T Get<T>(string url) where T : new()
        {
            var resultado = "";
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", Constante.Token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    resultado = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (System.Exception)
            { }
            return JsonConvert.DeserializeObject<T>(resultado);
        }
    }
}

