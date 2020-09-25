using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OdeToFood.Domain.Models;
using OdeToFood.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OdeToFood.Service.Service
{
    public class MealService : IMealService
    {

        public async Task<Meal> GetMeal()
        {
            var strInfo = new Meal();
            string Baseurl = "https://api.edamam.com/api/food-database/v2/parser?session=42&ingr=meal&app_id=bed7de23&app_key=723503d473f80798e6f2bae12c12c4be";

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient  
                HttpResponseMessage responseMessage = await client.GetAsync(Baseurl);

                //Checking the response is successful or not which is sent using HttpClient  
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var strResponse = await responseMessage.Content.ReadAsStringAsync();

                    var jsonSerializerSettings = new JsonSerializerSettings();
                    jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

                    //Deserializing the response recieved from web api and store in list
                    strInfo = JsonConvert.DeserializeObject<Meal>(strResponse, jsonSerializerSettings);
                    return strInfo;
                }
            }
            return strInfo;
        }




    } 

    }

