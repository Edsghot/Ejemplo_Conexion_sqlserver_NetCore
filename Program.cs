using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimalApi;

var builder = WebApplication.CreateBuilder(args);
//aqui se hace la configuracion

//para configurar para ver la conexion en memoria

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("tareasDb"));
//para la conexion con base de datos
builder.Services.AddSqlServer<TareasContext>("Data source=DESKTOP-0MM2HVP;Initial Catalog = TareasDb;Trusted_Connection =True;TrustServerCertificate=True;");


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//creamos un empoint para ver la conexion
app.MapGet("/dbConexion",async ([FromServices] TareasContext dbContext) => {

    //Nos asegura que la base de datos esta creada y si no hay lo crea
    dbContext.Database.EnsureCreated();//devuelve un booleano

    return Results.Ok("Base de datos en memoria: "+dbContext.Database.IsInMemory());
});

app.Run();
