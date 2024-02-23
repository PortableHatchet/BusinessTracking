using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BusinessTracking.Models; // Adjust the namespace accordingly
using System.Collections.Generic;

namespace BusinessTracking.Services
{
    public class SupabaseService
    {
        private readonly HttpClient _http;
        private string supabaseUrl = "https://gjqaanstallfabsprvwk.supabase.co";
        private string supabaseKey = Environment.GetEnvironmentVariable("KEY");

        public SupabaseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Customer>> FetchCustomers()
        {
            var requestUri = $"{supabaseUrl}/rest/v1/customers?select=*";
            var response = await SendGetRequest(requestUri);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<List<Customer>>() : new List<Customer>();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var requestUri = $"{supabaseUrl}/rest/v1/customers";
            var response = await SendPostRequest(requestUri, customer);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Customer>() : null;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var requestUri = $"{supabaseUrl}/rest/v1/customers?id=eq.{customer.Id}";
            var response = await SendPatchRequest(requestUri, customer);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Customer>() : null;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var requestUri = $"{supabaseUrl}/rest/v1/customers?id=eq.{customerId}";
            var response = await SendDeleteRequest(requestUri);
            return response.IsSuccessStatusCode;
        }

        private async Task<HttpResponseMessage> SendGetRequest(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            return await SendRequest(requestMessage);
        }

        private async Task<HttpResponseMessage> SendPostRequest<T>(string requestUri, T data)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = JsonContent.Create(data)
            };
            return await SendRequest(requestMessage);
        }

        private async Task<HttpResponseMessage> SendPatchRequest<T>(string requestUri, T data)
        {
            var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = JsonContent.Create(data)
            };
            return await SendRequest(requestMessage);
        }

        private async Task<HttpResponseMessage> SendDeleteRequest(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            return await SendRequest(requestMessage);
        }

        private async Task<HttpResponseMessage> SendRequest(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Add("apikey", supabaseKey);
            requestMessage.Headers.Add("Authorization", $"Bearer {supabaseKey}");

            return await _http.SendAsync(requestMessage);
        }
        public async Task<List<InventoryItem>> FetchInventoryItems()
        {
            var requestUri = $"{supabaseUrl}/rest/v1/inventory_items?select=*";
            var response = await SendGetRequest(requestUri);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<List<InventoryItem>>() : new List<InventoryItem>();
        }

        public async Task<InventoryItem> CreateInventoryItem(InventoryItem item)
        {
            var requestUri = $"{supabaseUrl}/rest/v1/inventory_items";
            var response = await SendPostRequest(requestUri, item);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<InventoryItem>() : null;
        }

        public async Task<InventoryItem> UpdateInventoryItem(InventoryItem item)
        {
            var requestUri = $"{supabaseUrl}/rest/v1/inventory_items?id=eq.{item.Id}";
            var response = await SendPatchRequest(requestUri, item);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<InventoryItem>() : null;
        }

        public async Task<bool> DeleteInventoryItem(int itemId)
        {
            var requestUri = $"{supabaseUrl}/rest/v1/inventory_items?id=eq.{itemId}";
            var response = await SendDeleteRequest(requestUri);
            return response.IsSuccessStatusCode;
        }
    }
}
