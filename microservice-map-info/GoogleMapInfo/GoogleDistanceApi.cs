﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
 
namespace GoogleMapInfo
{
    public class GoogleDistanceApi
    {
        private readonly IConfiguration _configuration;

        public GoogleDistanceApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GoogleDistanceData> GetMapDistance(string originCity, string destinationCity)
        {
            var apiKey = _configuration["googleDistanceApi:apiKey"];
            var googleDistanceApiUrl = _configuration["googleDistanceApi:apiUrl"];
            googleDistanceApiUrl += $"units=imperial&origins={originCity}&destinations={destinationCity}&key={apiKey}";

            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(googleDistanceApiUrl));
            
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            await using var data = await response.Content.ReadAsStreamAsync();
            var distanceInfo = await JsonSerializer.DeserializeAsync<GoogleDistanceData>(data);

            return distanceInfo;

        }

    }
}
