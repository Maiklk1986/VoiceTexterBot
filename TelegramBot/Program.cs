using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Configuration;
using TelegramBot.Controllers;
using TelegramBot.Servises;

namespace TelegramBot
{ 
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("7672213792:AAELeHufOuwca7JdZAE70j5oxAY9cM5j8Lc"));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>(); 

            //Инициализация конфигурации
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(appSettings);

            //
            services.TryAddSingleton<IStorage, MemoryStorage>();

            // Подключаем контроллеры сообщений и кнопок
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InLineKeyboardController>();

            
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            services.AddHostedService<Bot>();

            // ..
            services.AddSingleton<IFileHandler, AudioFileHandler>();
            // ..
        }


        //Метод Инициализация конфигурации
        //static AppSettings BuildAppSettings()
        //{
        //    return new AppSettings()
        //    {
        //        BotToken = "7672213792:AAELeHufOuwca7JdZAE70j5oxAY9cM5j8Lc"
        //    };
        //}

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = "D:\\VisualStudio\\TelgramBotVoiceTXT", //  D:\\VisualStudio\\TelgramBotVoiceTXT
                BotToken = "7672213792:AAELeHufOuwca7JdZAE70j5oxAY9cM5j8Lc",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
                OutputAudioFormat = "wav", // Новое поле
                InputAudioBitrate = 4000,
            };
        }
    }
    
}