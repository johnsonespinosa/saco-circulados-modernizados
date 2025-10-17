# Guía de Contribución – SACO Circulados Modernizados

Gracias por tu interés en contribuir a SACO. Este documento establece las normas para colaborar de manera profesional y coherente.

---

## 🧭 Flujo de trabajo

1. **Fork y clonación**
   - Haz un fork del repositorio y clónalo localmente.

2. **Creación de rama**
   - Usa el prefijo adecuado: `feature/`, `bugfix/`, `enhancement/`, `hotfix/`
   - Ejemplo: `feature/gestion-usuarios`

3. **Commits**
   - Usa mensajes claros y semánticos.
   - Formato recomendado:

     ```
     tipo: descripción breve [Closes #ID]
     ```

     Ejemplo:

     ```
     feature: implementa CRUD de usuarios [Closes #12]
     ```

4. **Pull Request**
   - Abre el PR contra `main`.
   - Incluye descripción del cambio, checklist de revisión y vincula el issue.
   - Espera revisión antes de merge.

---

## 🧪 Estilo de código

- Sigue las convenciones de C# y Blazor.
- Usa `PascalCase` para clases y métodos públicos.
- Usa `camelCase` para variables locales y parámetros.
- Evita comentarios innecesarios; prioriza código autoexplicativo.

---

## 🧪 Pruebas

- Todo nuevo código debe incluir pruebas unitarias o de integración.
- Usa `xUnit` para pruebas.
- Ejecuta `dotnet test` antes de cada PR.

---

## 🏷️ Etiquetas en Issues

- `feature`: Nueva funcionalidad
- `bug`: Corrección de errores
- `enhancement`: Mejora de código existente
- `documentation`: Cambios en documentación
- `testing`: Pruebas unitarias o de carga

---

## 🤝 Código de conducta

Este proyecto promueve el respeto, la colaboración y la excelencia técnica. Cualquier comportamiento abusivo será reportado y bloqueado.
