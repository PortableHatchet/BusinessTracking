using BusinessTracking.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessTracking;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Supabase;
using Supabase.Interfaces;
using BusinessTracking.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(); // Add HttpClient service


// Configure services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<DatabaseService>();
var url = "https://gjqaanstallfabsprvwk.supabase.co";
var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImdqcWFhbnN0YWxsZmFic3BydndrIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MDg2NjQ0MTMsImV4cCI6MjAyNDI0MDQxM30.4w0DfsF4Z18v0aBFCxwvq-Im8zzm7bmwJIKWIQyGaiw";
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
