# SACO – Sistema Automatizado de Circulados Operativos

Plataforma institucional para la gestión integral de circulaciones, auditorías, codificadores, reportes y documentos. SACO reemplaza sistemas heredados con una solución moderna, escalable y auditable, alineada con las mejores prácticas de desarrollo de software.

---

## 🧱 Arquitectura del Proyecto

Este sistema está construido bajo el patrón **Clean Architecture**, con separación clara entre capas y responsabilidades:

- **Domain**: Entidades, interfaces y lógica de negocio pura.
- **Application**: Casos de uso, comandos, consultas y validaciones.
- **Infrastructure**: Servicios externos, implementaciones de interfaces, configuración.
- **Persistence**: Acceso a datos con Oracle usando Repository + Specification Pattern.
- **WebUI**: Interfaz de usuario con Blazor WebAssembly + MudBlazor.

---

## 🧰 Stack Tecnológico

- **Backend**: ASP.NET Core 8
- **Frontend**: Blazor WebAssembly + MudBlazor
- **Base de Datos**: Oracle
- **Arquitectura**: Clean Architecture + CQRS + MediatR + FluentValidation
- **Patrones**: Repository Pattern, Specification Pattern, IoC
- **DevOps**: CI/CD con GitHub Actions

---

## 📁 Estructura de Carpetas

saco-circulados-modernizados/
├── src/
│ ├── SACO.Domain/
│ ├── SACO.Application/
│ ├── SACO.Infrastructure/
│ ├── SACO.Persistence/
│ └── SACO.WebAPI/
│ └── SACO.WebUI/
├── tests/
│ ├── SACO.UnitTests/
│ └── SACO.IntegrationTests/
├── .github/
│ └── workflows/
│ └── ci-cd.yml
├── README.md
├── CONTRIBUTING.md
├── CHANGELOG.md

---

## 🚀 Cómo Ejecutar el Proyecto

### Requisitos

- .NET SDK 8.0
- Oracle 19c+
- Visual Studio 2022, VS Code o Rider

### Comandos básicos

Restaurar dependencias: dotnet restore

Compilar solución: dotnet build SACO.sln

Ejecutar WebUI: cd src/SACO.WebUI => dotnet run

### 🧪 Pruebas

Ejecutar pruebas unitarias: dotnet test tests/SACO.UnitTests

Ejecutar pruebas de integración: dotnet test tests/SACO.IntegrationTests

### 📌 Metodología Ágil

Este proyecto utiliza SCRUM con sprints semanales, milestones definidos y gestión de tareas mediante GitHub Project Board. Cada issue está vinculado a un sprint y etiquetado por tipo.

### 🤝 Contribuciones

Consulta el archivo CONTRIBUTING.md para conocer las normas de colaboración, estilo de código, convenciones de commits y flujo de trabajo con PRs.

### 📜 Licencia

Este proyecto está bajo licencia institucional. Uso restringido a entidades autorizadas.
