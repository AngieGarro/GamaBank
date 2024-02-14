using Newtonsoft.Json;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppCore_Logic
{
    public class SUNPEManager
    {
        public void SuscribeFintech()
        {
            //Me conecto al banco central de cenfotec y registro esta fintech
            //Request http post al banco central y enviar el suscriptor

            var suscriptor = new Suscription()
            {
                BaseURL = "https://agarrom-gmbank.azurewebsites.net",
                Code = "1020",
                Description = "The bank of GaMa Cash",
                Name = "GaMa bank",
                Owner = "Angie Paola Garro Martinez"
            };

            var URL = "https://sunpe-cenfobank.azurewebsites.net/api/Suscription/Subscribe";
            var client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string jsonObject = JsonConvert.SerializeObject(suscriptor);

            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var result = client.PostAsync(URL, content).Result;

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Error when process request");
            }

        }
       
    }
 
}
