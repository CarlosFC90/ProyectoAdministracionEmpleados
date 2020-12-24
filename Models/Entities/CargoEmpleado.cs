using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.NETCore.Models.Entities
{
    public class CargoEmpleado
    {
        [Key]
        public int IdCargo { get; set; }

        [Column("Cargo", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Cargo { get; set; }
    }
}
