using System;
namespace AppMetrica.MAUI.Core
{
    public sealed class YandexMetricaPreloadInfo
    {
        public string TrackingId { get; private set; }
        public Dictionary<string, string> AdditionalInfo { get; private set; }

        public YandexMetricaPreloadInfo(string trackingId)
        {
            TrackingId = trackingId;
            AdditionalInfo = new Dictionary<string, string>();
        }
    }
}

