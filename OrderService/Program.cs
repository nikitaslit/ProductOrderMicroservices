using Microsoft.EntityFrameworkCore;
using OrderService.Context;
using OrderService.Model;
using OrderService.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Настройка Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Добавляем Serilog в DI
builder.Host.UseSerilog();

// Добавляем In-Memory базу данных для заказов
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseInMemoryDatabase("OrderDb"));

// Регистрируем HttpClient с правильным BaseAddress
builder.Services.AddHttpClient<OrderManagementService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5283/");  // Устанавливаем правильный URL для ProductService
});

// Добавляем сервисы
builder.Services.AddScoped<OrderManagementService>();

// Добавляем контроллеры
builder.Services.AddControllers();

// Добавляем Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger в разработке
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Использование Serilog для логирования
app.UseSerilogRequestLogging(); // Логирует все HTTP запросы

// Настройка маршрутов
app.MapControllers();

app.Run();