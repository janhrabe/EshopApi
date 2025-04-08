# Introduction 
**EshopApi** is a simple e-commerce REST API built with **ASP.NET Core** and following the principles of **Clean Architecture**. It allows basic management of products, including creating, updating, deleting, and viewing products. The project also incorporates unit tests with **xUnit** and **Moq** to ensure functionality. This API aims to serve as a foundation for building more complex e-commerce applications with a focus on separation of concerns, testability, and maintainability.

- Post/Put/Get operations on the `Product` entity  
- Pagination support for product listing  
- Input data validation  
- Architecture based on the separation of concerns principle (**Clean Architecture**)  
- Unit tests for all key endpoints  
- Ready fo MSSQL localdb
- Tested on PostgreSQL in Docker

# Getting Started
Before running the project, make sure you have the following installed:  
- **.NET 8 SDK**: [Download here](https://dotnet.microsoft.com/en-us/download)  
- An IDE such as **[JetBrains Rider](https://www.jetbrains.com/rider/)** or **[Visual Studio Code](https://code.visualstudio.com/)**  
- **SQL Server LocalDB** (pre-installed on Windows or can be used in Docker on Mac)
- **Docker**: [Download here](https://www.docker.com/) (for PostgreSQL)  

# Prerequisities 
- Run Migrations and Update Database
- For PostgreSQL in Docker, build the image with "docker-compose.yaml" file attached, use connection string "Host=localhost;Port=5432;Database=EshopDb;Username=postgres;Password=root;
" and run Migrations and Update Database

# Build and Test
- 
- To Build the roject run "dotnet build" command
- Start application run "dotnet run --project EshopApi.Api" 
- Run the UnitTests

# API references
The API documentation is available via Swagger UI at the following URL once the application is running: https://localhost:7005/swagger. (Use yout localhost port instead)
Refer to the Swagger UI for detailed information about the available endpoints and their request/response models.

### Available Endpoints

- **POST `/products/create`**  
  Creates a new product with the provided name, description, price, quantity, and image URL.

- **PUT `/products/update/{productId}`**  
  Updates the `QuantityInStock` of an existing product identified by `productId`.

- **GET `/products/detail/{productId}`**  
  Retrieves detailed information about a specific product by its `productId`.

- **GET `/products/list`**  
  Returns a list of all products. Supports optional pagination parameters like `pageNumber`.
