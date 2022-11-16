using System.Threading.Tasks;

namespace VisionApiManager.Services
{
    public interface IApiRequest<TRequest, TResponse>
    {
        Task<TResponse> GetResult(string url, TRequest data);
    }
}
