# EjemploMvcRazor — la Vista con Razor (ASP.NET Core MVC)

La misma lista de tareas, pero ahora la **Vista está hecha con Razor**: vistas
`.cshtml` que se arman **en el servidor**. Es la forma nativa de ASP.NET Core MVC
y cierra el trío con los ejemplos en vanilla y en Vue.

Los comentarios están en minúsculas, sin tildes y sin "ñ".

## Arquitectura (MVC completo en C#)

| Parte MVC       | Archivo(s) |
|-----------------|------------|
| **Modelo**      | `Models/Tarea.cs`, `Data/RepositorioTareas.cs` |
| **ViewModel**   | `Models/TareasViewModel.cs` (la lista + el conteo de pendientes) |
| **Controlador** | `Controllers/TareasController.cs` (devuelve vistas, no json) |
| **Vista**       | `Views/Tareas/Index.cshtml` + `Views/Shared/_Layout.cshtml` |

Diferencia con los otros ejemplos: aquí **no hay API ni fetch**. El controlador
arma el ViewModel, se lo pasa a la vista Razor y el servidor devuelve el **HTML
ya listo**.

## Estructura

```
EjemploMvcRazor/
├─ Program.cs                     (configura MVC y el enrutamiento)
├─ Models/
│  ├─ Tarea.cs                    (el modelo)
│  └─ TareasViewModel.cs          (los datos para la vista)
├─ Data/
│  └─ RepositorioTareas.cs        (los datos en memoria)
├─ Controllers/
│  └─ TareasController.cs         (Index, Agregar, Alternar, Eliminar)
├─ Views/
│  ├─ _ViewImports.cshtml         (usings + tag helpers)
│  ├─ _ViewStart.cshtml           (fija el layout)
│  ├─ Shared/_Layout.cshtml       (la plantilla comun)
│  └─ Tareas/Index.cshtml         (la vista de la lista)
└─ wwwroot/
   └─ estilos.css                 (los estilos)
```

## Cómo ejecutarlo

```bash
dotnet run
```

Abre la dirección que muestra la consola (por ejemplo `http://localhost:5000`).
La ruta por defecto lleva a `Tareas/Index`. Puedes agregar, marcar y borrar
tareas: cada acción envía un formulario (POST) al controlador, que hace el cambio
y vuelve a mostrar la lista (patrón post-redirect-get).

## Qué conceptos de Razor usa

- **@model / Model** — la vista declara que recibe un `TareasViewModel` y accede
  a sus datos con `@Model`.
- **Inlines** — expresiones como `@Model.Pendientes` y `@tarea.Texto`, y control
  de flujo con `@foreach` y `@if`.
- **ViewModel** — una clase a la medida de la vista (lista + pendientes).
- **Layout** — `_Layout.cshtml` con `@RenderBody()`; `_ViewStart.cshtml` lo fija
  para todas las vistas.
- **Archivos estáticos** — el CSS en `wwwroot`, enlazado con `~/estilos.css`.
- **Tag helpers** — `asp-action` y `asp-route-id` para armar los formularios.

## El trío de la Vista (vanilla, Vue y Razor)

| Aspecto | Vanilla | Vue | Razor |
|---|---|---|---|
| Dónde se arma el HTML | navegador | navegador | **servidor** |
| Lenguaje de la vista | HTML + JS | plantilla Vue | **HTML + C#** |
| ¿Necesita API para los datos? | sí (fetch) | sí (fetch) | **no** |
| Parte de ASP.NET Core | no | no | **sí, nativa** |

## Nota

En este entorno no había `dotnet` para compilar, así que la lógica del
repositorio se verificó reproduciéndola de forma equivalente, y se revisó que
las vistas y el controlador estén bien formados. El código está escrito para
correr con `dotnet run`. La imagen `preview.png` representa el HTML que la vista
Razor genera.
