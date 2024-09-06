using IJGZ20240906.Endpoints;
using IJGZ20240906.Models.DAL;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura y agrega un contexto de base de datos para Entity Framework Core.
builder.Services.AddDbContext<IJGZ20240906Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
);

// Agrega una instancia de la clase CustomerDAL como un servicio para la inyección de dependencias.
builder.Services.AddScoped<ProductIJGZDAL>();

var app = builder.Build();

// Agrega los puntos finales relacionados con los products a la aplicación.
app.AddCustomerEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();