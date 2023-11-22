using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.MapPost("/api/products", ([FromForm] Product product) =>
{
    return TypedResults.NoContent();
})
.DisableAntiforgery();

app.MapPost("/api/products-with-openapi", ([FromForm] Product product) =>
{
    return TypedResults.NoContent();
})
.DisableAntiforgery()
.WithOpenApi();

app.Run();

public record class Product(string Name, double Price);
