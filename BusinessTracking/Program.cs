using BusinessTracking.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessTracking;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Supabase;
using Supabase.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(); // Add HttpClient service


// Configure services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var url = "https://gjqaanstallfabsprvwk.supabase.co";
var key = Environment.GetEnvironmentVariable("KEY");
builder.Services.AddScoped<Supabase.Client>(
    provider => new Supabase.Client(
        url,
        key,
        new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }
    )
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
