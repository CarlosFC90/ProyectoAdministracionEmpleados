using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionEmpleados.NETCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdministracionEmpleados.NETCore.Models.DAL
{
    public class DBContextPrueba : DbContext
    {
        public DBContextPrueba(DbContextOptions<DBContextPrueba> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<CargoEmpleado> CargoEmpleados { get; set; }
    }
}
