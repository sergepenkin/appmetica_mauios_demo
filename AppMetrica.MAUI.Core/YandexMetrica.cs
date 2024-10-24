using System;
namespace AppMetrica.MAUI.Core
{
    public static class YandexMetrica
    {
        private static IYandexMetrica _implementation = null;
        private static bool _activated = false;

        /// <summary>
        /// Gets an AppMetrica implementation.
        /// </summary>
        /// <value>The implementation.</value>
        public static IYandexMetrica Implementation
        {
            get
            {
                return _implementation ?? (_implementation = new YandexMetricaDummy());
            }
        }

        public static void RegisterImplementation(IYandexMetrica metricaImplementation)
        {
            if (metricaImplementation != null)
            {
                _implementation = metricaImplementation;
                _activated = true;
            }
        }

        public static bool IsActivated
        {
            get
            {
                return _activated;
            }
        }
    }
}