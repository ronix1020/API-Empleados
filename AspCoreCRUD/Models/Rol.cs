using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreCRUD.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Requerido")]
        [Column(TypeName ="VARCHAR(50)")]
        public string Nombre
        {
            get;
            set;
        }
    }
}
