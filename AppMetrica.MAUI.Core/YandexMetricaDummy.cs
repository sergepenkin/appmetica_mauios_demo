using System;
using System.Collections;
using System.Collections.Generic;

namespace AppMetrica.MAUI.Core
{
    public class YandexMetricaDummy : BaseYandexMetrica
    {
        public override void ReportEvent(string message) { }

        public override void ReportEvent(string message, IDictionary parameters) { }

        public override void ReportError(string message, Exception exception) { }

        public override void SetLocationTracking(bool enabled) { }

        public override void SetLocation(Coordinates coordinates) { }

        public override void SendEventsBuffer() { }

        public override void SetStatisticsSending(bool enabled) { }

        public override void ReportRevenue(YandexAppMetricaRevenue revenue) { }

        public override void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action) { }

        public override void SetUserProfileID(string userProfileID) { }

        public override void ReportUserProfile(YandexMetricaUserProfile userProfile) { }

        public override string LibraryVersion { get { return default(string); } }

        public override int LibraryApiLevel { get { return default(int); } }
    }
}

