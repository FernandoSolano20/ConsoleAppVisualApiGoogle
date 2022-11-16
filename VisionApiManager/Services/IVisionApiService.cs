using System.Threading.Tasks;
using VisionApiManager.Models.Req.Visual;
using VisionApiManager.Models.Res.Visual;

namespace VisionApiManager.Services
{
    public interface IVisionApiService
    {
        Task<Resps> LoadImage(Image image);
    }
}
