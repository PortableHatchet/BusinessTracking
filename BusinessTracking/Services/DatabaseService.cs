using System.Net;
using BusinessTracking.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Supabase.Functions;


namespace BusinessTracking.Services
{
    public class DatabaseService
    {
        private readonly Supabase.Client _client;

        public DatabaseService(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<List<Customer>> FetchCustomers<TModel>() where TModel : Customer, new()
        {
            var result = await _client
                .From<Customer>()
                .Get();
            return result.Models;
        }

        public async Task<Customer> CreateCustomer<TModel>(Customer item) where TModel : Customer, new()
        {
            try
            {
                var result = await _client
                    .From<Customer>()
                    .Insert(item);

                return result.Model;
            }
            catch
            {
                Console.WriteLine("Error creating a new customer");
            }
            return null;
        }
    }
}
