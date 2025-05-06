# Product Order Microservices



### Description.

This is a project consisting of two microservices:



- **Order Service** - service for placing orders.

- **Product Service** - service for managing products and their quantity in stock.



### Technologies

- **.NET 8** - core framework.

- **Entity Framework Core** - for working with database (In-Memory).

- **Serilog** - for logging.

- **Swagger** - for API documentation and testing.



### Startup



1. Version **.NET 8**.

2. Clone the repository:

    ```bash

    git clone https://github.com/nikitaslit/ProductOrderMicroservices.git

    cd ProductOrderMicroservices

    ```

3. Starting two microservices:

    ```bash

    # Start Order Service

    cd OrderService

    dotnet run



    # Start Product Service

    cd ProductService

    dotnet run

    ```



4. API access:

    - **Order Service**: [http://localhost:5020/swagger](http://localhost:5020/swagger)

    - **Product Service**: [http://localhost:5283/swagger](http://localhost:5283/swagger)



### What's not done:

- **gRPC** - not implemented, uses **HTTP REST**.

- **RabbitMQ / Kafka** - no messaging configured.

- **Docker** - containerization is not configured.

- **JWT / IdentityServer** - authentication is not configured.



---



### Logging

Logs are written using **Serilog** to console and file.



---



#### Notes:

1. **In-Memory Database** for development.

2. Easy setup, fast deployment.

3. API documented via **Swagger**.

