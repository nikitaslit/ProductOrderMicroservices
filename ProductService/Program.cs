using Microsoft.EntityFrameworkCore;
using ProductService.Context;
using ProductService.Model;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Настройка Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/productservice_log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Добавляем Serilog в DI
builder.Host.UseSerilog();

// Добавляем в контейнер зависимостей EF Core с InMemory
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb"));

// Добавляем сервисы
builder.Services.AddScoped<ProductService.ProductManagementService.ProductManagementService>();

// Добавляем контроллеры для API
builder.Services.AddControllers();

// Добавляем Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем использование Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Это включает генерацию Swagger
    app.UseSwaggerUI();  // Это добавляет UI для просмотра документации
}

// Включаем логирование запросов с помощью Serilog
app.UseSerilogRequestLogging();  // Это логирует все HTTP запросы

// Настройка маршрутов
app.MapControllers();

// Запуск приложения
app.Run();