using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PropertyAnalyser
{
    class ZooplaHttpClient
    {
        private static HttpClient _client = new HttpClient();

        public async Task<T> GetObject<T>(string url) where T : ResponseModelBase
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else
            {
                T errorResponse = (T)Activator.CreateInstance(typeof(T));
                errorResponse.ErrorString = await responseMessage.Content.ReadAsStringAsync();
                errorResponse.ErrorCode = responseMessage.StatusCode.ToString();
                return errorResponse;
            }
        }
    }
}
