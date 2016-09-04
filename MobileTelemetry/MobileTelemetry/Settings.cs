using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MobileTelemetry
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string LastUpdateKey = "last_update_key";
        private static readonly string LastUpdateDefault = string.Empty;

        public static string LastUpdate
        {
            get { return AppSettings.GetValueOrDefault(LastUpdateKey, LastUpdateDefault); }
            set { AppSettings.AddOrUpdateValue(LastUpdateKey, value); }
        }


        private const string HubNameKey = "hub_name_key";
        private static readonly string HubNameDefault = string.Empty;

        public static string HubName
        {
            get { return AppSettings.GetValueOrDefault(HubNameKey, HubNameDefault); }
            set { AppSettings.AddOrUpdateValue(HubNameKey, value); }
        }

        private const string DeviceIdKey = "device_id_key";
        private static readonly string DeviceIdDefault = string.Empty;

        public static string DeviceId
        {
            get { return AppSettings.GetValueOrDefault(DeviceIdKey, DeviceIdDefault); }
            set { AppSettings.AddOrUpdateValue(DeviceIdKey, value); }
        }

        private const string SharedAccessKeyKey = "shared_access_key_key";
        private static readonly string SharedAccessKeyDefault = string.Empty;

        public static string SharedAccessKey
        {
            get { return AppSettings.GetValueOrDefault(SharedAccessKeyKey, SharedAccessKeyDefault); }
            set { AppSettings.AddOrUpdateValue(SharedAccessKeyKey, value); }
        }
    }
}