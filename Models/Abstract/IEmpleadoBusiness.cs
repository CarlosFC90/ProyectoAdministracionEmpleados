using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionEmpleados.NETCore.Clases;
using AdministracionEmpleados.NETCore.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionEmpleados.NETCore.Models.Abstract
{
    public interface IEmpleadoBusiness
    {
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosTodos();
        Task guardarEmpleado(Empleado empleado);
        Task eliminarEmpleado(Empleado empleado);
        Task<Empleado> obtenerEmpleadoPorID(int? id);
        Task<List<CargoEmpleado>> obtenerCargoTodos();
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosPorNombrePorID(string busqueda);
        Task<Empleado> Details(int? id);
    }
}
