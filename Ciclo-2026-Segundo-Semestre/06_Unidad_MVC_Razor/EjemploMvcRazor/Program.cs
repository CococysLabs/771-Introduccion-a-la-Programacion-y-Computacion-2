using EjemploMvcRazor.Data;

// crea el constructor de la aplicacion web
var builder = WebApplication.CreateBuilder(args);

// registra los controladores con soporte de vistas razor
builder.Services.AddControllersWithViews();
// registra el repositorio como singleton: una sola copia de los datos
builder.Services.AddSingleton<RepositorioTareas>();

// construye la aplicacion
var app = builder.Build();

// sirve los archivos estaticos de wwwroot (css, js, imagenes)
app.UseStaticFiles();
// activa el enrutamiento
app.UseRouting();

// ruta por defecto: el controlador de tareas y la accion de inicio
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tareas}/{action=Index}/{id?}");

// arranca el servidor web
app.Run();
