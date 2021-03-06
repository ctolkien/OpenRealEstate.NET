﻿using System.Collections.Generic;
using Newtonsoft.Json;
using OpenRealEstate.Core.Models;

namespace OpenRealEstate.Services.Json
{
    public static class JsonConvertHelpers
    {
        private static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            ContractResolver = new ListingContractResolver(),
            Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.StringEnumConverter() },
            Formatting = Formatting.Indented
        };

        public static string SerializeObject(Listing listing)
        {
            return JsonConvert.SerializeObject(listing, JsonSerializerSettings);
        }

        public static string SerializeObject(IEnumerable<Listing> listings)
        {
            return JsonConvert.SerializeObject(listings, JsonSerializerSettings);
        }
    }
}