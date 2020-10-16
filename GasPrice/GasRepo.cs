using GasPrice.Models;
using GasPricer.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasPrice
{
    public class GasRepo : IGasRepo
    {
        private string key = System.IO.File.ReadAllText("key.txt");
        public State PricesForState(string stateAbrv)
        {
            var client = new RestClient($"https://gas-price.p.rapidapi.com/stateUsaPrice?state={stateAbrv}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "gas-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", key);
            IRestResponse response = client.Execute(request);

            var obj = JObject.Parse(response.Content);

            var state = new State();
            state.Name = (string) obj["result"]["state"]["name"];
            state.AvgGasoline = (double)obj["result"]["state"]["gasoline"];
            state.AvgMidGrade = (double)obj["result"]["state"]["midGrade"];
            state.AvgPremium = (double)obj["result"]["state"]["premium"];
            state.AvgDiesel = (double)obj["result"]["state"]["diesel"];

            var citiesList = new List<City>();

            foreach (var item in obj["result"]["cities"])
            {
                var city = new City();
                city.Name = (string) item["name"];
                city.Gasoline = (double)item["gasoline"];
                city.MidGrade = (double)item["midGrade"];
                city.Premium = (double)item["premium"];
                city.Diesel = (double)item["diesel"];
                citiesList.Add(city);
            }
            state.Cities = citiesList;

            return state;
        }

       public Province PricesForProvince(string prov)
        {
            var client = new RestClient($"https://gas-price.p.rapidapi.com/canada");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "gas-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", key);
            IRestResponse response = client.Execute(request);

            var obj = JObject.Parse(response.Content);

            var province = new Province();
           
            foreach(var item in obj["result"])
            {
                if(item["name"].ToString() == prov)
                {
                    province.Name = (string)item["name"];
                    province.AverageGas = (double)item["gasoline"];
                    break;
                }
                
            }
            
           
            return province;

        }


    }
}
