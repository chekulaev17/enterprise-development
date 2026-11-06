using FoodDelivery.Api.ErrorHandling;
using FoodDelivery.Application.Contracts.Categories;
using FoodDelivery.Application.Contracts.Common;
using FoodDelivery.Application.Services;
using FoodDelivery.Domain.Data;
using FoodDelivery.Domain.Repositories;
using FoodDelivery.Infrastructure.InMemory.Repositories;

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

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
