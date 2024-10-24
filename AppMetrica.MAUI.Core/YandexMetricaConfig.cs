using System;
namespace AppMetrica.MAUI.Core
{
    public sealed class YandexMetricaConfig
    {
        public string APIKey { get; private set; }
        public string AppVersion { get; set; }
        public Coordinates Location { get; set; }
        public int? SessionTimeout { get; set; }
        // appmetrica 5 0 0 migration
        //public bool? CrashReporting { get; set; }
        public bool? LocationTracking { get; set; }
        public bool? LogsEnabled { get; set; }
        public bool? DataSendingEnabled { get; set; }        
        public bool? HandleFirstActivationAsUpdate { get; set; }

        public YandexMetricaPreloadInfo PreloadInfo { get; set; }

        public YandexMetricaConfig(string apiKey)
        {
            APIKey = apiKey;
        }
    }    
}

