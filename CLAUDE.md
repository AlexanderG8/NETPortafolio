# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Run the application
dotnet run

# Build only
dotnet build

# Run with specific profile
dotnet run --launch-profile https
```

The app runs on `http://localhost:5263` (HTTP) or `https://localhost:7199` (HTTPS).

## Architecture

ASP.NET Core MVC portfolio website targeting .NET 10. Uses minimal hosting model (top-level statements in `Program.cs`, no `Startup.cs`).

**Request flow:** Routes → `HomeController` → `IRepositoryProyectos` → Razor Views

### Key patterns

- **Repository pattern:** `IRepositoryProyectos` / `RepositoryProyectos` in `Services/`. Currently returns hardcoded in-memory data (no database).
- **Dependency injection:** Services registered as `Transient` in `Program.cs`.
- **ViewModels:** `HomeIndexViewModel` passes data to the home page; `ContactViewModel` handles the contact form.
- **Partial views:** The `Index` page is composed of partials (`_Presentacion`, `_Habilidades`, `_SeccionProyectos`) located in `Views/Home/`.

### Routes

| Action | URL | Notes |
|--------|-----|-------|
| `Index` | `/` | Home, shows 3 featured projects |
| `Proyectos` | `/Home/Proyectos` | Full projects list |
| `Contacto` | `/Home/Contacto` | Contact form (GET + POST) |
| `Gracias` | `/Home/Gracias` | Post-contact redirect target |

### Frontend

Bootstrap 5 (bundled in `wwwroot/lib/`) + Bootstrap Icons from CDN. Custom styles in `wwwroot/css/custom.css`. Project images in `wwwroot/img/`.
