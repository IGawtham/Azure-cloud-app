using Microsoft.FeatureManagement;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductService, ProductService>();
var connectionString = "Aure-App-Connection String";
// Add services to the container.
builder.Services.AddRazorPages();
builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(option=>option.Connect(connectionString).UseFeatureFlags());
});
builder.Services.AddFeatureManagement();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
