using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionEmpleados.NETCore.Clases;
using AdministracionEmpleados.NETCore.Models.Abstract;
using AdministracionEmpleados.NETCore.Models.DAL;
using AdministracionEmpleados.NETCore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministracionEmpleados.NETCore.Models.Business
{
    public class EmpleadoBusiness : IEmpleadoBusiness
    {
        private readonly DBContextPrueba _context;

        public EmpleadoBusiness(DBContextPrueba context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosTodos()
        {
            await using (_context)
            {
                IEnumerable<EmpleadoDetalle> listaEmpleadosDetalle =
                    (from empleado in _context.Empleados
                     join cargo in _context.CargoEmpleados
                     on empleado.Cargo equals
                     cargo.IdCargo
                     select new EmpleadoDetalle
                     {
                         IdEmpleado = empleado.IdEmpleado,
                         Nombre = empleado.Nombre,
                         Cargo = cargo.Cargo,
                         Documento = empleado.Documento,
                         Telefono = empleado.Telefono
                     }).ToList();

                return listaEmpleadosDetalle;
            }
        }
        
        public async Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosPorNombrePorID(string busqueda)
        {
            await using (_context)
            {
                IEnumerable<EmpleadoDetalle> listaEmpleadosDetalle =
                    (from empleado in _context.Empleados
                     join cargo in _context.CargoEmpleados
                     on empleado.Cargo equals
                     cargo.IdCargo
                     where (empleado.Nombre.Contains(busqueda) || empleado.Documento.ToString().Equals(busqueda))
                     select new EmpleadoDetalle
                     {
                         IdEmpleado = empleado.IdEmpleado,
                         Nombre = empleado.Nombre,
                         Cargo = cargo.Cargo,
                         Documento = empleado.Documento,
                         Telefono = empleado.Telefono
                     }).ToList();

                return listaEmpleadosDetalle;
            }
        }

        public async Task guardarEmpleado(Empleado empleado)
        {
            if (empleado.IdEmpleado == 0)
                _context.Add(empleado);
            else
                _context.Update(empleado);

            await _context.SaveChangesAsync();
            
        }

        public async Task eliminarEmpleado(Empleado empleado)
        {
            if (empleado != null)
            {
                _context.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }

        //Devuelve un empleado
        public async Task<Empleado> obtenerEmpleadoPorID(int? id)
        {
            Empleado empleado;
            empleado = null;

            if (id == null)
            {
                return empleado;
            }
            else
            {
                empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.IdEmpleado == id);
                return empleado;
            }
                
        }

        public async Task<List<CargoEmpleado>> obtenerCargoTodos()
        {
            return await _context.CargoEmpleados.ToListAsync();
        }

        public Task CrearEditar(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public async Task<Empleado> Details(int? id)
        {
            Empleado empleado;

            //empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.IdEmpleado == id);
            empleado = await obtenerEmpleadoPorID(id);
            return empleado;
        }
    }
}
