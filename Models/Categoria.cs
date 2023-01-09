
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace minimalApi.Models{

    public class Categoria{
        //agregandpo notaciones

       // [Key]
        public Guid? CategoriaId {get;set;}
        //[Required]
       // [MaxLength(150)]
        public string? Nombre {get;set;}
        
        public string? Descripcion {get;set;}
        public int? Peso{get;set;}

        //foreign keyEFGDX 
        [JsonIgnore]
        public virtual ICollection<Tarea>? Tareas {get;set;}
    }
}