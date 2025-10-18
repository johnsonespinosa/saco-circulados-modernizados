# Historial de Cambios – SACO Circulados Modernizados

Este archivo documenta los cambios realizados en cada versión del sistema.

---

## [1.1.0] – 2025-10-17

### ✨ Añadido

- Persistencia real con EF Core y Ardalis.Specification
- Repositorios genéricos (`IGenericRepository`, `IReadOnlyRepository`)
- Specifications para unicidad, búsqueda, ordenamiento y paginación
- Validadores con FluentValidation para comandos y consultas
- Seguridad con `IPasswordHasher` y JWT
- Interfaz de gestión de usuarios con búsqueda, paginación y edición dinámica (`MudTable`, `UserForm`)
- CQRS completo con separación de lectura/escritura
- Auditoría con `AuditableInterceptor` y trazabilidad por usuario y fecha
- Eliminación lógica de usuarios con estado `Inactivo`

### 🛠️ Cambios

- Refactor de handlers para usar persistencia real
- Eliminación de datos simulados en la UI
- Preparación para desacoplar la UI de la lógica de acceso a datos
- Configuración avanzada de EF Core con convención de nombres y restricciones
- Interceptor para soft delete y auditoría centralizada

### 🐛 Correcciones

- Validación de usuario duplicado
- Manejo de errores en formularios de usuario
- Corrección de firma en `LoadServerData` para `MudTable`

---

## [1.0.0] – 2025-10-16

### ✨ Añadido

- Estructura base con Clean Architecture
- Configuración de proyectos: Domain, Application, Infrastructure, Persistence, WebAPI, WebUI
- CI/CD básico con GitHub Actions
- Documentación inicial (`README.md`, `CONTRIBUTING.md`, `CHANGELOG.md`)

### 🛠️ Cambios

- Referencias entre proyectos
- Preparación para integración de MediatR y FluentValidation

### 🐛 Correcciones

- N/A
