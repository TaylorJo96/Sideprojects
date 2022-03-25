using CatCards.Models;
using RestSharp;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatPicService : ICatPicService
    {
        protected static RestClient catPic = new RestClient("https://cat-data.netlify.app/api/pictures/random");

        public CatPic GetPic()
        {
            RestRequest request = new RestRequest();
            IRestResponse<CatPic> response = catPic.Get<CatPic>(request);

            if (!response.IsSuccessful)
            {
                //TODO: Write a message into a log file for future. 

                throw new HttpRequestException($"There was an error in the call to the server {response.StatusCode}");
            }
            return response.Data;


        }
    }
}
