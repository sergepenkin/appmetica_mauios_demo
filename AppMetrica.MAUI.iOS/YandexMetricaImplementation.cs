using System;
using System.Collections;
using AppMetrica.MAUI.Core;
using AppMetrica.MAUI.Core.Utils;
using CoreLocation;

namespace AppMetrica.MAUI.iOS
{
    public class YandexMetricaImplementation : BaseYandexMetrica
    {
        public static void Activate(YandexMetricaConfig config)
        {
            YandexMetrica_581.ActivateWithConfiguration(config.ToIOSAppMetricaConfig());

            YandexMetrica.RegisterImplementation(new YandexMetricaImplementation());
            YandexMetricaAttributeImplementation.Init();
            UpdateConfiguration(config);
        }

        public override void ReportEvent(string message)
        {
            YandexMetrica_581.ReportEvent(message, null);
        }

        public override void ReportEvent(string message, IDictionary parameters)
        {
            YandexMetrica_581.ReportEvent(message, parameters.ToIOSDictionary(), null);
        }

        public override void ReportError(string message, Exception exception)
        {
            var nsException = new NSException(exception.Source, exception.Message, null);
            YandexMetrica_581.ReportError(message, nsException, null);
        }

        public override void SetLocationTracking(bool enabled)
        {
            YandexMetrica_581.SetLocationTracking(enabled);
        }

        public override void SetLocation(Coordinates coordinates)
        {
            YandexMetrica_581.SetLocation(coordinates.ToCLLocation());
        }

        public override void SendEventsBuffer()
        {
            YandexMetrica_581.SendEventsBuffer();
        }

        public override void SetStatisticsSending(bool enabled)
        {
            YandexMetrica_581.SetStatisticsSending(enabled);
        }

        public override void ReportRevenue(YandexAppMetricaRevenue revenue)
        {
            YandexMetrica_581.ReportRevenue(revenue.ToIOSAppMetricaRevenue(), null);
        }

        public override void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action)
        {
            YandexMetrica_581.RequestAppMetricaDeviceIDWithCompletionQueue(null, (deviceID, error) =>
            {
                action.Invoke(deviceID, RequestDeviceIDErrorFromNSError(error));
            });
        }

        public override void SetUserProfileID(string userProfileID)
        {
            YandexMetrica_581.SetUserProfileID(userProfileID);
        }

        public override void ReportUserProfile(YandexMetricaUserProfile userProfile)
        {
            YandexMetrica_581.ReportUserProfile(userProfile.ToIOSUserProfile(), null);
        }

        public override string LibraryVersion { get { return YandexMetrica_581.LibraryVersion; } }

        public override int LibraryApiLevel { get { return default(int); } }

        private YandexAppMetricaRequestDeviceIDError? RequestDeviceIDErrorFromNSError(NSError error)
        {
            if (error == null)
            {
                return null;
            }
            if (error.Domain.Equals(NSError.NSUrlErrorDomain))
            {
                return YandexAppMetricaRequestDeviceIDError.NETWORK;
            }
            return YandexAppMetricaRequestDeviceIDError.UNKNOWN;
        }
    }

    public static class YandexAppMetricaExtensionsIOS
    {
        public static AppMetricaConfiguration ToIOSAppMetricaConfig(this YandexMetricaConfig self)
        {
            /*
            StackTrace  "   at AppMetrica.MAUI.iOS.AMAAppMetricaConfiguration..ctor(String apiKey) in
    / Users / mac / Desktop / PROJ2 / AppMetrica.MAUI.iOS / obj / Debug / net8.0 - ios / iOS / AppMetrica.MAUI.iOS / AMAAppMetricaConfiguration.g.cs:line 707\n
    at AppMetrica.MAUI.iOS.YandexMetricaImplementatio…"	string
            */

            var nativeConfig = new AppMetricaConfiguration(self.APIKey);

            if (self.Location != null)
            {
                nativeConfig.Location = self.Location.ToCLLocation();
            }
            if (self.AppVersion != null)
            {
                nativeConfig.AppVersion = self.AppVersion;
            }
            if (self.LocationTracking.HasValue)
            {
                nativeConfig.LocationTracking = self.LocationTracking.Value;
            }
            if (self.SessionTimeout.HasValue)
            {
                nativeConfig.SessionTimeout = (nuint)self.SessionTimeout.Value;
            }
            /*
            if (self.CrashReporting.HasValue)
            {
                nativeConfig.CrashReporting = self.CrashReporting.Value;
            }
            */
            if (self.LogsEnabled.HasValue)
            {
                nativeConfig.logsEnabled = self.LogsEnabled.Value;
            }
            if (self.DataSendingEnabled.HasValue)
            {
                nativeConfig.DataSendingEnabled = self.DataSendingEnabled.Value;
            }
            if (self.HandleFirstActivationAsUpdate.HasValue)
            {
                nativeConfig.HandleFirstActivationAsUpdate = self.HandleFirstActivationAsUpdate.Value;
            }
            if (self.PreloadInfo != null)
            {
                var preloadInfo = new AMAAppMetricaPreloadInfo(self.PreloadInfo.TrackingId);
                foreach (var kvp in self.PreloadInfo.AdditionalInfo)
                {
                    preloadInfo.SetAdditionalInfo(kvp.Value, kvp.Key);
                }
                nativeConfig.PreloadInfo = preloadInfo;
            }

            return nativeConfig;
        }

        public static CLLocation ToCLLocation(this Coordinates self)
        {
            return self == null ? null : new CLLocation(self.Latitude, self.Longitude);
        }

        public static RevenueInfo ToIOSAppMetricaRevenue(this YandexAppMetricaRevenue self)
        {
            var price = self.Price;
            var currency = self.Currency;
            var quantity = (nuint)(self.Quantity ?? 1);
            var productID = self.ProductID;
            var trasactionID = self.Receipt.HasValue ? self.Receipt.Value.TransactionID : null;
            var data = self.Receipt.HasValue ? new NSData(self.Receipt.Value.Data, 0) : null;
            var payload = self.Payload.ToIOSDictionary();

            return new RevenueInfo(price, currency, quantity, productID, trasactionID, data, payload);
        }

        public static NSDictionary ToIOSDictionary(this IDictionary self)
        {
            if (self == null)
            {
                return null;
            }
            var jsonString = new NSString(SimpleJson.SerializeObject(self));
            var jsonData = jsonString.Encode(NSStringEncoding.UTF8);
            NSError error;
            return (NSDictionary)NSJsonSerialization.Deserialize(jsonData, 0, out error);
        }

        public static UserProfile ToIOSUserProfile(this YandexMetricaUserProfile self)
        {
            var nativeUserProfileUpdates = new List<UserProfileUpdate>();
            self.UserProfileUpdates.ForEach(userProfileUpdate =>
            {
                if (userProfileUpdate != null && userProfileUpdate.Native != null)
                {
                    nativeUserProfileUpdates.Add(userProfileUpdate.Native as UserProfileUpdate);
                }
            });
            return new UserProfile(nativeUserProfileUpdates.ToArray());
        }
    }
}

