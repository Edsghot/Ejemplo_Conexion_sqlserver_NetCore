using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimalApi;
using minimalApi.Models;

var builder = WebApplication.CreateBuilder(args);
//aqui se hace la configuracion

//para configurar para ver la conexion en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("tareasDb"));
//para la conexion con base de datos
//para windows
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//para ubuntu 
//builder.Services.AddSqlServer<TareasContext>("Data source=localhost;Initial Catalog = Tareas;User id = sa;password = Edsghot2;TrustServerCertificate=True;");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//creamos un empoint para ver la conexion
app.MapGet("/dbConexion", ([FromServices] TareasContext dbContext) =>
{

    //Nos asegura que la base de datos esta creada y si no hay lo crea
    dbContext.Database.EnsureCreated();//devuelve un booleano

    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

//para recuperar las listas
app.MapGet("/api/tareas",async([FromServices] TareasContext dbContext)=>{
    //para mostrar todos los datos
    //return Results.Ok(dbContext.tareas);

    //para filtrar por prioridad media y las categorias mas incluida
    return Results.Ok(dbContext.tareas.Include(p => p.Categoria).Where(p=>p.PrioridadTarea == minimalApi.Models.Prioridad.Media));
});

app.MapPost("/api/tareasss",async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});
app.Run();
