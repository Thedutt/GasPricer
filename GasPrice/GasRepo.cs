using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasPrice
{
    public class GasRepo
    {
        public void PricesForState(string state)
        {
            var client = new RestClient($"https://gas-price.p.rapidapi.com/stateUsaPrice?state={state}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "gas-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "dab253dfa7msh59216dcdf09274fp1070c0jsn6e09feff8a90");
            IRestResponse response = client.Execute(request);
        }
    }
}
