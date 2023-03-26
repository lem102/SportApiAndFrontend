REST api and simple frontend. All commands are run from the root of the project.

# Requirements

- .NET 7 sdk
- Postgres database

# Setup

## Api

Add your postgres database connection string to `./SportsApi/appsettings.json` like so:

```
{
  ...
  "ConnectionStrings": {
    "Connection": "Host=localhost;Database=db;Username=user;Password=password123"
  }
}

```

## Frontend

Add the url of the api to `./SportsFrontend/appsettings.json` like so:

```
{
  ...
  "ConnectionStrings": {
    "Api": "http://localhost:5254/"
  }
}

```

# Running

## Api

Start the api with `dotnet run --project ./SportsApi/`.

## Frontend

Start the frontend with `dotnet run --project ./SportsFrontend/`.

# Tests

Run the tests with `dotnet test`.
