using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdministracionEmpleados.NETCore.Models.DAL;
using AdministracionEmpleados.NETCore.Models.Entities;
using AdministracionEmpleados.NETCore.Clases;
using AdministracionEmpleados.NETCore.Models.Abstract;

namespace AdministracionEmpleados.NETCore.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoBusiness _context;

        public EmpleadoController(IEmpleadoBusiness context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index(string busqueda)
        {
            if (!string.IsNullOrEmpty(busqueda))
                return View(await _context.obtenerEmpleadosPorNombrePorID(busqueda));
            else
                return View(await _context.obtenerEmpleadosTodos());
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<CargoEmpleado> cargoEmpleados = new List<CargoEmpleado>();
            cargoEmpleados = await _context.obtenerCargoTodos();

            ViewBag.Cargo = cargoEmpleados;

            return View(await _context.obtenerEmpleadoPorID(id));
        }

        // GET: Empleado/Create
        public async Task<IActionResult> CrearEditar(int id = 0)
        {
            List<CargoEmpleado> cargoEmpleados = new List<CargoEmpleado>();
            cargoEmpleados = await _context.obtenerCargoTodos();

            ViewBag.Cargo = cargoEmpleados;

            if (id == 0)
            {
                return View(new Empleado());
            }
            else
                return View(await _context.obtenerEmpleadoPorID(id));
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("IdEmpleado,Nombre,Documento,Cargo,Telefono")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                await _context.guardarEmpleado(empleado);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Empleado/Edit/5
        /*public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Nombre,Documento,Cargo,Telefono")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }*/

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await _context.eliminarEmpleado(await _context.obtenerEmpleadoPorID(id));

            return RedirectToAction(nameof(Index));
        }

        // POST: Empleado/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        //private bool EmpleadoExists(int id)
        //{
        //    return _context.Empleados.Any(e => e.IdEmpleado == id);
        //}
    }
}
