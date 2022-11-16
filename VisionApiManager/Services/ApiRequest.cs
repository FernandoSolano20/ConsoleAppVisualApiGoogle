using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VisionApiManager.Services
{
    public class ApiRequest<TRequest, TResponse> : IApiRequest<TRequest, TResponse>
    {
        public async Task<TResponse> GetResult(string url, TRequest data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    string jsonString = JsonSerializer.Serialize(data);
                    var resp = await client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
                    var stringResponse = await resp.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<TResponse>(stringResponse);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
