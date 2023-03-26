REST api and simple frontend. All commands are run from the root of the project.

# Requirements

- .NET 7 sdk
- Postgres database

# Setup

## Api

Add your postgres database connection string to `./Sports.Api/appsettings.json` like so:

```
{
  ...
  "ConnectionStrings": {
    "Connection": "Host=localhost;Database=db;Username=user;Password=password123"
  }
}

```

Set up the database with the sql file found here: `TaskDescription/FavouriteSportsDBScript.sql`

## Frontend

Add the url of the api to `./Sports.Frontend/appsettings.json` like so:

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

Start the api with `dotnet run --project ./Sports.Api/`.

## Frontend

Start the frontend with `dotnet run --project ./Sports.Frontend/`.

# Tests

Run the tests with `dotnet test`.
