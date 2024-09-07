using IJGZ20240906.AppWebBlazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Registra CustomerService como un servicio Singleton (una instancia única para toda la aplicación)
builder.Services.AddSingleton<ProductIJGZService>();

// Configura y agrega un cliente HTTP con nombre "CRMAPI"
builder.Services.AddHttpClient("IJGZAPI", c =>
{ 
    c.BaseAddress = new Uri(builder.Configuration["UrlsAPI:IJGZ"]);
   
});

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
