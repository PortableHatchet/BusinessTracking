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

        // Initialize the supabase client
        public DatabaseService(Supabase.Client client)
        {
            _client = client;
        }
        // Gets all customers from the customer table and puts them into a list
        public async Task<List<TModel>> FetchCustomers<TModel>() where TModel : Customer, new()
        {
            var result = await _client
                .From<TModel>()
                .Get();
            return result.Models;
        }
        // Creates a new customer and inserts into the customer table in the database
        public async Task<TModel> CreateCustomer<TModel>(TModel item) where TModel : Customer, new()
        {
            try
            {
                var result = await _client
                    .From<TModel>()
                    .Insert(item);

                return result.Model;
            }
            catch
            {
                Console.WriteLine("Error creating a new customer");
            }
            return null;
        }
        // Gets all the inventory items and puts them in a list
        public async Task<List<TModel>> FetchInventory<TModel>() where TModel : InventoryItem, new()
        {
            var result = await _client
                .From<TModel>()
                .Get();
            return result.Models;
        }
        // Create an Inventory Item and insert it into the Inventory Table in the database
        public async Task<InventoryItem> CreateInventory<TModel>(TModel item) where TModel : InventoryItem, new()
        {
            try
            {
                var result = await _client
                    .From<TModel>()
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
