using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimalApi;

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
    return Results.Ok(dbContext.tareas);
});
app.Run();
