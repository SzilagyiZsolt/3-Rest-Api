﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Car;
//
//    var auto = Auto.FromJson(jsonString);

namespace Car
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Auto
    {
        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("SearchCriteria")]
        public object SearchCriteria { get; set; }

        [JsonProperty("Results")]
        public Result[] Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("Make_ID")]
        public long MakeId { get; set; }

        [JsonProperty("Make_Name")]
        public string MakeName { get; set; }
    }

    public partial class Auto
    {
        public static Auto FromJson(string json) => JsonConvert.DeserializeObject<Auto>(json, Car.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Auto self) => JsonConvert.SerializeObject(self, Car.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
