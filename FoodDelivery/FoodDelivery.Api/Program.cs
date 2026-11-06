using FoodDelivery.Application.Contracts.Customers;
using FoodDelivery.Api.ErrorHandling;
using FoodDelivery.Application.Contracts.Categories;
using FoodDelivery.Application.Contracts.Common;
using FoodDelivery.Application.Services;
using FoodDelivery.Domain.Data;
using FoodDelivery.Domain.Repositories;
using FoodDelivery.Infrastructure.InMemory.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

builder.Services.AddSingleton<FoodDeliveryData>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<
    ICrudService<CategoryDto, CategoryRequest>,
    CategoryService>();

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<
    ICrudService<CustomerDto, CustomerRequest>,
    CustomerService>();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("API службы доставки еды");
    });
}

app.MapControllers();

app.Run();

