using Microsoft.EntityFrameworkCore;
using minimalApi.Models;
namespace minimalApi;

public class TareasContext: DbContext{
    public DbSet<Categoria>? Categorias {get;set;}
    public DbSet<Tarea>? tareas {get;set;}

    //contructor de la conexion 

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

    //para utilizar Fluent api y sobrescribir la configuracion del onModelCrating
    protected override void OnModelCreating(ModelBuilder modelBuilder){

        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("a42d2e46-4aab-4fe6-9c3a-44c98610648c"),Nombre = "Actividades pendientes",Peso=20});
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("a42d2e46-4aab-4fe6-9c3a-44c986106482"),Nombre = "Actividades Personales",Peso=50});
        //creamos la expresion lambda
        modelBuilder.Entity<Categoria>(categoria =>{

            //para decir que es un primary key
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            //para decirles que qeu requerido y su tamaño del atributo Nombre
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            //para especificarle acada propiedad
            categoria.Property(p=>p.Descripcion);
            categoria.Property(p=>p.Peso);
            //para poner datos iniciales
            categoria.HasData(categoriasInit);

        });

        //agregamos datos iniciales para tarea
        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("a42d2e46-4aab-4fe6-9c3a-44c986106483"),
            CategoriaId = Guid.Parse("a42d2e46-4aab-4fe6-9c3a-44c986106482"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "pago de servicios publicos",
            FechaCreacion = DateTime.Now,
            FechaConclusion = DateTime.Now});
        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("a42d2e46-4aab-4fe6-9c3a-44c986106a81"),
            CategoriaId = Guid.Parse("a42d2e46-4aab-4fe6-9c3a-44c98610648c"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "pago de leyendas",
            FechaCreacion = DateTime.Now,
            FechaConclusion = DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea =>{

            //mencionamos la tabla
            tarea.ToTable("tarea");
            //para la variable tareaID
            tarea.HasKey(p=>p.TareaId);
            //para el atributo categoriaId que es foreign key
            tarea.HasOne(p=>p.Categoria).WithMany(p =>p.Tareas).HasForeignKey(p=>p.CategoriaId);
            //para el atributo titulo
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            //para el atributo Descripcion
            tarea.Property(p=>p.Descripcion);
            //para el atributo PrioridadTarea
            tarea.Property(p=>p.PrioridadTarea);
            //para el atributo FechaCreacion
            tarea.Property(p=>p.FechaCreacion);
            tarea.Property(p=>p.FechaConclusion);

            tarea.HasData(tareasInit);
        });
    }

}