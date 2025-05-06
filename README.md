# Product Order Microservices

### Описание
Это проект, состоящий из двух микросервисов:

- **Order Service** — сервис для оформления заказов.
- **Product Service** — сервис для управления продуктами и их количеством на складе.

### Технологии
- **.NET 8** — основной фреймворк.
- **Entity Framework Core** — для работы с базой данных (In-Memory).
- **Serilog** — для логирования.
- **Swagger** — для API документации и тестирования.

### Запуск

1. Версия **.NET 8**.
2. Клонируй репозиторий:
    ```bash
    git clone https://github.com/nikitaslit/ProductOrderMicroservices.git
    cd ProductOrderMicroservices
    ```
3. Запуск двух микросервисов:
    ```bash
    # Запуск Order Service
    cd OrderService
    dotnet run

    # Запуск Product Service
    cd ProductService
    dotnet run
    ```

4. Доступ к API:
    - **Order Service**: [http://localhost:5020/swagger](http://localhost:5020/swagger)
    - **Product Service**: [http://localhost:5283/swagger](http://localhost:5283/swagger)

### Что не сделано:
- **gRPC** — не реализовано, используется **HTTP REST**.
- **RabbitMQ / Kafka** — не настроен обмен сообщениями.
- **Docker** — контейнеризация не настроена.
- **JWT / IdentityServer** — аутентификация не настроена.

---

### Логирование
Логи записываются с помощью **Serilog** в консоль и файл.

---

### Примечания:
1. **In-Memory Database** для разработки.
2. Простая настройка, быстрое развертывание.
3. API документировано через **Swagger**.
