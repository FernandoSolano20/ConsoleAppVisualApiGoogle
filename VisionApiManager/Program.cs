using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using VisionApiManager.Models.Req.TextToSpeech;
using VisionApiManager.Models.Req.Visual;
using VisionApiManager.Models.Res.TextToSpeech;
using VisionApiManager.Models.Res.Visual;
using VisionApiManager.Services;

namespace VisionApiManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = SetUpServices();
            var baseFolderLocation = args[0];
            var fruitImageName = args[1];
            var fruitName = GetImageRecognitionText(baseFolderLocation, fruitImageName, host);
            var mp3Base64 = GetAudioBase64ByText(fruitName, host);
            ValidateResultFolder(baseFolderLocation);
            byte[] binaryData = Convert.FromBase64String(mp3Base64);
            File.WriteAllBytes($"{baseFolderLocation}\\results\\{fruitName}.mp3", binaryData);
        }

        static IHost SetUpServices()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IApiRequest<RequestTextToSpeech, ResponseTextToSpeech>, ApiRequest<RequestTextToSpeech, ResponseTextToSpeech>>();
                    services.AddTransient<IApiRequest<Requests, Resps>, ApiRequest<Requests, Resps>>();
                    services.AddTransient<IVisionApiService, VisionApiService>();
                    services.AddTransient<ITextToSpeechService, TextToSpeechService>();
                })
                .UseSerilog()
                .Build();
            return host;
        }

        static string GetImageRecognitionText(string baseFolderLocation, string fruitImageName, IHost host)
        {
            var api = ActivatorUtilities.CreateInstance<VisionApiService>(host.Services);
            var image = new Image()
            {
                Content = GetImageBase64($"{baseFolderLocation}\\{fruitImageName}")
            };
            var taskResponse = api.LoadImage(image).ConfigureAwait(false);
            var res = taskResponse.GetAwaiter().GetResult();
            var fruitName = res?.Responses.FirstOrDefault()?.LocalizedObjectAnnotations.FirstOrDefault()?.Name;
            return fruitName ?? string.Empty;
        }

        static string GetAudioBase64ByText(string text, IHost host)
        {
            var textToSpeechApi = ActivatorUtilities.CreateInstance<TextToSpeechService>(host.Services);
            var taskRespMp3 = textToSpeechApi.GetMp3(text).ConfigureAwait(false);
            var mp3Base64 = taskRespMp3.GetAwaiter().GetResult();
            return mp3Base64?.AudioContent ?? string.Empty;
        }

        static string GetImageBase64(string path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }

        static void ValidateResultFolder(string baseFolder)
        {
            var folder = $"{baseFolder}\\results";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
