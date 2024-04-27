using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
   public static class SupabaseClient
    {
        public static Supabase.Client Client { get; set; }

        static SupabaseClient()
        {
            // Аттрибуты подключения к Supabase
            const string url = "https://yfbkximvpfzrzwrwkerl.supabase.co";
            const string key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InlmYmt4aW12cGZ6cnp3cndrZXJsIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MDgyNzgyOTUsImV4cCI6MjAyMzg1NDI5NX0.mElmpvr3IM5yIFzH30HuMC4yUMUPP0ZU1oS2Fm7UUVI";


            // Настройки подключения
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            // Создаем клиента
            Client = new Supabase.Client(url, key, options);

            // Подключаемся
            Connect();
        }

        private static async void Connect()
        {
            // Ассинхронно подключаемся
            await Client.InitializeAsync();
        }
    }
}
