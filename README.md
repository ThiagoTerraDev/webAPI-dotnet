# Employee Management Web API

A RESTful Web API built with ASP.NET Core 9.0 for managing employee data. This application provides endpoints for CRUD operations on employee records with support for different departments and work shifts.

## 🚀 Technology Stack

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core 9.0** - Object-Relational Mapping (ORM)
- **SQL Server** - Database (running via Docker)
- **Swagger/OpenAPI** - API documentation and testing
- **Docker** - Containerized SQL Server database

## 📋 Features

- Employee CRUD operations (Create, Read, Update, Delete)
- Department-based employee categorization
- Work shift management (Morning, Afternoon, Night)
- Entity Framework Core with SQL Server
- Swagger/OpenAPI documentation
- Development environment configuration

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK
- Docker (for SQL Server)
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/ThiagoTerraDev/webAPI-dotnet.git
   cd webAPI-dotnet
   ```

2. **Start SQL Server with Docker**
   ```bash
   docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrongPassword123!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
   ```
   > **Note**: Replace `YourStrongPassword123!` with a strong password of your choice.

3. **Create development configuration**
   
   Create a file named `appsettings.Development.json` in the project root with your database configuration:
   
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=localhost,1433;Initial Catalog=EmployeesWebAPI;User Id=sa;Password=YourStrongPassword123!;Encrypt=false;TrustServerCertificate=true"
     }
   }
   ```
   > **Important**: Use the same password you set in step 2.

4. **Restore dependencies**
   ```bash
   cd webAPI-dotnet
   dotnet restore
   ```

5. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

6. **Start the application**
   ```bash
   dotnet run
   ```

7. **Access the API**
   - API: `https://localhost:7183` or `http://localhost:5126`
   - Swagger UI: `https://localhost:7183/swagger` or `http://localhost:5126/swagger`

## 🔧 Configuration

### Database Connection

The application uses SQL Server with the following default configuration for development:

- **Server**: localhost,1433
- **Database**: EmployeesWebAPI
- **Authentication**: SQL Server Authentication
- **User**: sa
- **Password**: Set by you during Docker setup

### Environment Configuration

- **Production**: Uses `appsettings.json` (placeholder connection string for security)
- **Development**: Uses `appsettings.Development.json` (includes real connection string)

### Trust Development Certificate (Optional)

If you see SSL certificate warnings, you can trust the development certificate:

```bash
dotnet dev-certs https --trust
```

## 📚 API Documentation

Once the application is running, you can access the interactive API documentation through Swagger UI at:
- `https://localhost:7183/swagger` (HTTPS)
- `http://localhost:5126/swagger` (HTTP)

## 🛠️ Development

### Adding New Migrations

```bash
dotnet ef migrations add MigrationName
```

### Updating Database

```bash
dotnet ef database update
```

### Building the Application

```bash
dotnet build
```

### Running Tests

```bash
dotnet test
```

## 👨‍💻 Author

**Thiago Terra**
- LinkedIn: [Thiago Terra](https://www.linkedin.com/in/thiago-terra-158a71266/)
- GitHub: [@ThiagoTerraDev](https://github.com/ThiagoTerraDev)