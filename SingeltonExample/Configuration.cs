using System;

namespace SingeltonExample
{
    // Die Singelton Klasse
    internal class Configuration : IDisposable
    {
        private static Configuration _instance;
        public static Configuration Instance => _instance ?? (_instance = new Configuration());

        public static Configuration Instance2 { get; } = new Configuration();

        private Configuration()
        { }

        public void LoadConfig()
        {
            // Todo: load Config...
        }

        public void Dispose()
        {
            // Todo
        }
    }
}
