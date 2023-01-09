using Microsoft.EntityFrameworkCore;
using minimalApi.Models;
namespace minimalApi;

public class TareasContext: DbContext{
    public DbSet<Categoria>? Categorias {get;set;}
    public DbSet<Tarea>? tareas {get;set;}

    //contructor de la conexion 

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

}