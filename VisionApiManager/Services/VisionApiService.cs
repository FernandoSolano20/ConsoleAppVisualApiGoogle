using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VisionApiManager.Models.Req.Visual;
using VisionApiManager.Models.Res.Visual;

namespace VisionApiManager.Services
{
    public class VisionApiService : IVisionApiService
    {
        private readonly string _url = "https://vision.googleapis.com/v1/images:annotate?key=";
        private readonly IApiRequest<Requests, Resps> _apiRequest;
        private readonly ILogger<VisionApiService> _log;
        private readonly IConfiguration _config;

        public VisionApiService(IApiRequest<Requests, Resps> apiRequest, ILogger<VisionApiService> log, IConfiguration config)
        {
            _apiRequest = apiRequest;
            _log = log;
            _config = config;
            _url += _config.GetValue<string>("GoogleApiKeysVisionApi");
        }

        public async Task<Resps> LoadImage(Image image)
        {
            var req = new Requests()
            {
                Request = new List<Request>
                {
                    new Request()
                    {
                        Image = image,
                        Features = new List<Feature>()
                        {
                            new Feature()
                        }
                    }
                }
            };

            try
            {
                return await _apiRequest.GetResult(_url, req);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
