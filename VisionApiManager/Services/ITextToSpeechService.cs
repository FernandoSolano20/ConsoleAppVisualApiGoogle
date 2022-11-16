using System.Threading.Tasks;
using VisionApiManager.Models.Res.TextToSpeech;

namespace VisionApiManager.Services
{
    public interface ITextToSpeechService
    {
        Task<ResponseTextToSpeech> GetMp3(string text);
    }
}
