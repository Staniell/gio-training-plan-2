# CourseHub

ASP.NET Core 10 Web API for a small course catalog with enrollments. PostgreSQL through EF Core. This repo is your Training Plan 2 workspace.

## Requirements

- .NET SDK 10 (see `global.json`)
- Docker (PostgreSQL 17 and Redis 7 run in containers)

## Run

```bash
docker compose up -d postgres
dotnet build
dotnet test
dotnet run --project src/CourseHub.Api
```

The API listens on `http://localhost:5090`. On first start it creates the database and seeds 200 courses. Sample calls are in `requests.http`; endpoints are in `docs/api.md`; enrollment rules are in `docs/enrollment-rules.md`.

Redis is in `docker-compose.yml` for later work: `docker compose up -d redis`.

To reset the data: `docker compose down -v`, then start again.

## Layout

| Path | Contents |
|---|---|
| `src/CourseHub.Api` | Controllers, startup |
| `src/CourseHub.Core` | Domain, `CourseHubDbContext`, seed data, enrollment policy |
| `tests/CourseHub.Core.Tests` | xUnit tests |
| `.github/workflows/ci.yml` | Build and test on every PR and on `main` |
