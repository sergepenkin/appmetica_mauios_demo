﻿using System;
using System.Collections;

namespace AppMetrica.MAUI.Core
{
    public struct YandexAppMetricaRevenue
    {
        public double Price { get; private set; }

        public int? Quantity { get; set; }

        public string Currency { get; private set; }

        public string ProductID { get; set; }

        public YandexAppMetricaReceipt? Receipt { get; set; }

        public IDictionary Payload { get; set; }

        public YandexAppMetricaRevenue(double price, string currency)
        {
            Price = price;
            Quantity = null;
            Currency = currency;
            ProductID = null;
            Receipt = null;
            Payload = null;
        }
    }

    public struct YandexAppMetricaReceipt
    {
        public string Data { get; set; }

        public string Signature { get; set; }

        public string TransactionID { get; set; }
    }
}

