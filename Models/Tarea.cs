
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minimalApi.Models;

    public class Tarea
    {
       // [Key]
        public Guid? TareaId {get;set;}
       // [ForeignKey("CategoriaId")]
        public Guid? CategoriaId {get;set;}
      //  [Required]
       // [MaxLength(200)]
        public string? Titulo{get;set;}
        public string? Descripcion {get;set;}
        public Prioridad? PrioridadTarea {get;set;}
        public DateTime? FechaCreacion{get;set;}
        public DateTime? FechaConclusion {get;set;}
        
        //conexion para el foreign key
        public virtual Categoria? Categoria{get;set;}

        //como no queremos que se cree en nuestra base de datos se usa
       // [NotMapped]
        public string? Resumen{get;set;} //Aqui solo agregamos con los campos de titulo,Descripcion

    }

public enum Prioridad{
    Baja,
    Media,
    Alta
}