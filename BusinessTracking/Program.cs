using BusinessTracking.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessTracking;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using BusinessTracking.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(); // Add HttpClient service


// Configure services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add the SupabaseService here
builder.Services.AddScoped<SupabaseService>(); // Adjust this line if SupabaseService should be singleton or transient

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
