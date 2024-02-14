using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class SuscriptorManager
    {
        public List<Suscription> RetrieveAll()
        {
            //Deben escribir codigo para hacer un get al banco central y devolver el resultado.
            //https://sunpe-cenfobank.azurewebsites.net/api/Suscription/RetrieveAll

            var URL = "https://sunpe-cenfobank.azurewebsites.net/api/Suscription/RetrieveAll";
            var lst = new List<Suscription>();
            var ar = new APIResponse();
         
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = client.GetAsync(URL).Result;

                if (result.IsSuccessStatusCode)
                {

                    var Response = result.Content.ReadAsStringAsync().Result;

                   ar = JsonConvert.DeserializeObject<APIResponse>(Response);
                }
                else
                {
                    throw new Exception("Error the process");
                }
                var jarray = (JArray)ar.Data;

                return jarray.ToObject<List<Suscription>>();
            }
        }

     
    }
}
