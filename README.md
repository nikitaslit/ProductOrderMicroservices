Product Order Microservices
Описание:
Два микросервиса для оформления заказов и управления продуктами.

Order Service — оформление заказов.

Product Service — управление продуктами и их количеством на складе.

Запуск
Убедись, что у тебя установлен .NET 8.

Клонируй репозиторий:

bash
Копировать
Редактировать
git clone https://github.com/nikitaslit/ProductOrderMicroservices.git
cd ProductOrderMicroservices
Запусти оба микросервиса:

bash
Копировать
Редактировать
cd OrderService && dotnet run
cd ProductService && dotnet run
Ссылки:
Order Service: http://localhost:5020/swagger

Product Service: http://localhost:5283/swagger

Используемые технологии:
.NET 8

Entity Framework Core (In-Memory)

Serilog (Логирование)

Swagger (API Документация)

Что не сделано:
gRPC: Используется HTTP REST.

Kafka/RabbitMQ: Не реализован обмен сообщениями.

Docker: Контейнеризация не настроена.

JWT/IdentityServer: Аутентификация не настроена.

Структура:
nginx
Копировать
Редактировать
ProductOrderMicroservices
├── OrderService
├── ProductService
└── README.md
