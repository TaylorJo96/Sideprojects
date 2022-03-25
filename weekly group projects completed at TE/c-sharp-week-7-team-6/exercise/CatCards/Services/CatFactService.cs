using CatCards.Models;
using RestSharp;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        protected static RestClient catFact = new RestClient("https://cat-data.netlify.app/api/facts/random");

        public CatFact GetFact()
        {
            RestRequest request = new RestRequest();
            IRestResponse<CatFact> response = catFact.Get<CatFact>(request);

            if (!response.IsSuccessful)
            {
                //TODO: Write a message into a log file for future. 

                throw new HttpRequestException($"There was an error in the call to the server {response.StatusCode}");
            }
            return response.Data;



        }
    }
}
