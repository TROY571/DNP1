﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment2Client.Data
{
    public class CloudAdultService : IAdultService {

        private string uri = "https://localhost:5003";
        
        private readonly HttpClient client;

        public CloudAdultService() {
        
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultsAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri+"/adults");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddAdultAsync(Adult adult) {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/adults", content);
        }

        public async Task RemoveAdultAsync(int adultId) {
            await client.DeleteAsync($"{uri}/adults/{adultId}");
        }

        public async Task UpdateAsync(Adult adult) {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/adults/{adult.Id}", content);
        }
    }
}