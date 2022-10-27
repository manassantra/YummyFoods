using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Models;

namespace YummyFood.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseMessegeBO responseModel { get ; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
            this.responseModel = new ResponseMessegeBO();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("YummyAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), 
                                          Encoding.UTF8, "application/json");
                }
                HttpResponseMessage response = null;

                switch (apiRequest.ApiType)
                {
                    case ServiceDirectory.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ServiceDirectory.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ServiceDirectory.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                response = await client.SendAsync(message);
                var apiContent = await response.Content.ReadAsStringAsync();
                var res = new ResponseMessegeBO
                {
                    Result = apiContent
                };
                var apiResponse = JsonConvert.SerializeObject(res);
                var apiRes = JsonConvert.DeserializeObject<T>(apiResponse);
                return apiRes;
            } 
            catch (Exception ex)
            {
                var response = new ResponseMessegeBO
                {
                    DisplayMessage = "Error",
                    ErrorMesseges = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false,
                };
                var res = JsonConvert.SerializeObject(response);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);

                return apiResponse;
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
