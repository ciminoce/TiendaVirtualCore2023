using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;
using TiendaVirtualCore.Web.ViewModels.Pais;

namespace TiendaVirtualCore.Web.Controllers
{
    public class PaisController : Controller
    {
        private readonly IServiciosPaises _servicio;
        private readonly IMapper _mapper;


        public PaisController(IServiciosPaises servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var listaPaises = _servicio.GetPaises();
            var listaPaisesVm = _mapper.Map<List<PaisListVm>>(listaPaises);
            return View(listaPaisesVm);
        }

        [HttpGet]
        public IActionResult Create()
        {

            PaisEditVm paisVm = new PaisEditVm();
            paisVm.RowVersion = new byte[] { };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaisEditVm paisVm)
        {
            // Genera un valor de RowVersion vacío(byte[])
            paisVm.RowVersion = new byte[8]; // Ajusta el tamaño según tus necesidades

            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }
            var pais = _mapper.Map<Pais>(paisVm);
            if (_servicio.Existe(pais))
            {
                ModelState.AddModelError(string.Empty, "Categoría existente!!!");
                return View(paisVm);
            }
            try
            {
                _servicio.Guardar(pais);
                TempData["success"] = "Registro agregado!!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View(paisVm);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? paisId)
        {
            if (paisId == null || paisId == 0)
            {
                return NotFound();
            }
            var pais = _servicio.GetPaisPorId(paisId.Value);
            if (pais == null)
            {
                return NotFound();
            }
            PaisEditVm paisVm = _mapper.Map<PaisEditVm>(pais);
            return View(paisVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PaisEditVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }
            var pais = _mapper.Map<Pais>(paisVm);
            if (_servicio.Existe(pais))
            {
                ModelState.AddModelError(string.Empty, "Categoría existente!!!");
                return View(paisVm);
            }
            try
            {
                // Obtén la categoría actualizada de la base de datos
                var paisEnBaseDeDatos = _servicio.GetPaisPorId(paisVm.PaisId);

                // Verifica si las versiones coinciden
                if (paisEnBaseDeDatos.RowVersion.SequenceEqual(paisVm.RowVersion))
                {
                    // Las versiones coinciden, puedes actualizar la categoría
                    _servicio.Guardar(pais);
                    TempData["success"] = "Registro agregado!!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Alguien más ha modificado la categoría, maneja la concurrencia aquí
                    ModelState.AddModelError(string.Empty, "La categoría ha sido modificada por otro usuario.");
                    return View(paisVm);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Accede a la InnerException para obtener detalles específicos sobre el error
                var innerException = ex.InnerException;

                // Ahora puedes registrar o manejar la excepción de manera adecuada
                // Puedes usar algún método de registro como Serilog, NLog o simplemente Console.WriteLine
                Console.WriteLine($"Excepción: {ex.Message}");

                // Puedes registrar los detalles de la InnerException también
                if (innerException != null)
                {
                    Console.WriteLine($"InnerException: {innerException.Message}");
                }

                TempData["error"] = "Ha ocurrido un error al guardar los cambios.";
                return View(paisVm);
                ModelState.AddModelError(string.Empty, "Error de concurrencia");
                return View(paisVm);

                // Manejar la excepción de concurrencia aquí si es necesario
            }
            //try
            //{
            //    _servicio.Guardar(pais);
            //    TempData["success"] = "Registro agregado!!!";
            //    return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{

            //    TempData["error"] = ex.Message;
            //    return View(paisVm);
            //}
        }

        [HttpGet]
        public IActionResult Delete(int? paisId)
        {
            if (paisId == null || paisId == 0)
            {
                return NotFound();
            }
            var pais = _servicio.GetPaisPorId(paisId.Value);
            if (pais == null)
            {
                return NotFound();
            }
            PaisEditVm paisVm = _mapper.Map<PaisEditVm>(pais);
            return View(paisVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int paisId)
        {
            var pais = _servicio.GetPaisPorId(paisId);
            if (pais == null)
            {
                return NotFound();
            }

            try
            {
                _servicio.Borrar(pais.PaisId);
                TempData["success"] = "Registro eliminado!!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                PaisEditVm paisVm = _mapper.Map<PaisEditVm>(pais);

                TempData["error"] = ex.Message;
                return View(paisVm);
            }
        }

    }
}
