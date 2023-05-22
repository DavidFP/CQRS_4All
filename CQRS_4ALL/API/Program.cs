using API.Data;
using API.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR 
builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (!app.Environment.IsProduction() && !app.Environment.IsStaging())
{
    await SeedOrders();
}

app.Run();



// Aux method
async Task SeedOrders()
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!context.Orders.Any())
    {
        var ordersToAdd = new List<Order>();
        var productsToAdd = new List<Product>();
        while (productsToAdd.Count < 10)
        {
            productsToAdd.Add(new Product()
            {
                Name = Faker.CompanyFaker.Name(),
                Description = Faker.TextFaker.Sentence(),
                Quantity = Faker.NumberFaker.Number(10),
                Price = Faker.NumberFaker.Number(200)
            });
        }
        while (ordersToAdd.Count < 100)
        {
            ordersToAdd.Add(new Order()
            {
                Name = Faker.NameFaker.Name(),
                Address = Faker.LocationFaker.Street(),
                Products = productsToAdd.Take(Faker.NumberFaker.Number(5)).ToList<Product>()
            });
        }
        await context.Orders.AddRangeAsync(ordersToAdd);
        await context.SaveChangesAsync();
    }
}