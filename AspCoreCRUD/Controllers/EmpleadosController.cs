using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspCoreCRUD.Data;
using AspCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspCoreCRUD.Controllers
{
    /// <summary>
    /// Servicio para guardar, editar, borrar o eliminar los registros
    /// de los empleados
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        /// <summary>
        /// Creacion de la instancia de la conexion hacia la base de datos
        /// </summary>
        private readonly ApplicationDBContext _db;

        /// <summary>
        /// Creacion de la instancia de la conexion hacia la base de datos
        /// </summary>
        /// <param name="db">Base de datos</param>
        public EmpleadosController(ApplicationDBContext db)
        {
            _db = db;
        }

        //Methods
        /// <summary>
        /// Obtiene todos los empleados registrados
        /// </summary>
        /// <returns>Todas las categorias</returns>
        [HttpGet]
        public IActionResult GetEmpleados()
        {
            return Ok(_db.Empleados.ToList());
        }

        /// <summary>
        /// Registra un empleado a la base de datos SQLServer
        /// </summary>
        /// <param name="obEmpleados">Datos a enviar dentro del cuerpo del POST</param>
        /// <returns>Todas las categorias</returns>
        [HttpPost]
        public async Task<IActionResult> AgregarEmpleado([FromBody] Empleados obEmpleados)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Ha ocurrido un error mientras se creaba el empleado");
            }
            _db.Empleados.Add(obEmpleados);
            await _db.SaveChangesAsync();

            return new JsonResult("Empleado creado correctamente!");
        }

        /// <summary>
        /// Edita un empleado que esta dentro de la base de datos
        /// </summary>
        /// <param name="id">Id del empleado</param>
        /// <param name="obEmpleados">Datos a actualizar dentro del cuerpo del PUT</param>
        /// <returns>Todas las categorias</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEmpleado([FromRoute] int id, [FromBody] Empleados obEmpleados)
        {
            if (obEmpleados == null || id != obEmpleados.id)
            {
                return new JsonResult("El empleado no ha sido encontrado");
            }
            else
            {
                _db.Empleados.Update(obEmpleados);
                await _db.SaveChangesAsync();
                return new JsonResult("El empleado se ha actualizado exitosamente");
            }
        }

        /// <summary>
        /// Borra un empleado que esta dentro de la base de datos
        /// </summary>
        /// <param name="id">Id del empleado</param>
        /// <returns>Todas las categorias</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEmpleado([FromRoute] int id)
        {
            var encuentraEmpleado = await _db.Empleados.FindAsync(id);
            if (encuentraEmpleado == null)
            {
                return NotFound();
            }
            else
            {
                _db.Empleados.Remove(encuentraEmpleado);
                await _db.SaveChangesAsync();
                return new JsonResult("El empleado ha sido eliminado correctamente");
            }
        }
    }
}
