
````
# Domain-Driven-Design-DDD

A **DDD + CQRS** project layout with `Domain`, `Application`, `Infrastructure`, and `API` layers.  
It uses **EF Core (SQL Server)**, **MediatR**, and **FluentValidation**.

---

## Project References

To wire up the projects correctly, add the following references:

```bash
dotnet add DddSample.Application reference DddSample.Domain
dotnet add DddSample.Infrastructure reference DddSample.Application
dotnet add DddSample.Infrastructure reference DddSample.Domain
dotnet add DddSample.API reference DddSample.Application
dotnet add DddSample.API reference DddSample.Infrastructure
````

---

## Required NuGet Packages

### Domain Layer (`DddSample.Domain`)

No external packages are required — keep this layer pure C# (Entities, Value Objects, Aggregates, Interfaces).

---

### Application Layer (`DddSample.Application`)

For **CQRS / Mediator pattern**:

```bash
dotnet add DddSample.Application package MediatR
dotnet add DddSample.Application package MediatR.Extensions.Microsoft.DependencyInjection
```

---

### Infrastructure Layer (`DddSample.Infrastructure`)

For **EF Core + SQL Server**:

```bash
dotnet add DddSample.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add DddSample.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add DddSample.Infrastructure package Microsoft.EntityFrameworkCore.Design
```

For **repository pattern helpers / logging**:

```bash
dotnet add DddSample.Infrastructure package Microsoft.Extensions.Logging
```

---

### API Layer (`DddSample.API`)

For **Web API + Swagger / OpenAPI**:

```bash
dotnet add DddSample.API package Swashbuckle.AspNetCore
dotnet add DddSample.API package Microsoft.AspNetCore.OpenApi
```

---

## Setup & Running

1. Ensure your database connection string is configured in `appsettings.json`.
2. Build the solution:

```bash
dotnet build
```

3. Run the API:

```bash
dotnet run --project DddSample.API
```

4. Open Swagger UI to test endpoints (usually at `https://localhost:<port>/swagger`).

---

## Notes

* **Domain Layer** should remain isolated from external dependencies.
* **Application Layer** handles commands, queries, and business rules.
* **Infrastructure Layer** deals with persistence, logging, and third-party integrations.
* **API Layer** exposes endpoints to clients (Web, Mobile, etc.).

```

---

