using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;
using TiendaVirtualCore.Web.ViewModels.Categoria;

namespace TiendaVirtualCore.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServiciosCategorias _servicio;
        private readonly IMapper _mapper;


        public CategoriaController(IServiciosCategorias servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var listaCategorias = _servicio.GetCategorias();
            var listaCategoriasVm = _mapper.Map<List<CategoriaListVm>>(listaCategorias);
            return View(listaCategoriasVm);
        }

        [HttpGet]
        public IActionResult Create()
        {

            CategoriaEditVm categoriaVm = new CategoriaEditVm();
            categoriaVm.RowVersion = new byte[] { };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaEditVm categoriaVm)
        {
            // Genera un valor de RowVersion vacío(byte[])
            categoriaVm.RowVersion = new byte[8]; // Ajusta el tamaño según tus necesidades

            if (!ModelState.IsValid)
            {
                return View(categoriaVm);
            }
            var categoria = _mapper.Map<Categoria>(categoriaVm);
            if (_servicio.Existe(categoria))
            {
                ModelState.AddModelError(string.Empty, "Categoría existente!!!");
                return View(categoriaVm);
            }
            try
            {
                _servicio.Guardar(categoria);
                TempData["success"] = "Registro agregado!!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View(categoriaVm);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? categoriaId)
        {
            if (categoriaId == null || categoriaId == 0)
            {
                return NotFound();
            }
            var categoria = _servicio.GetCategoriaPorId(categoriaId.Value);
            if (categoria == null)
            {
                return NotFound();
            }
            CategoriaEditVm categoriaVm = _mapper.Map<CategoriaEditVm>(categoria);
            return View(categoriaVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaEditVm categoriaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaVm);
            }
            var categoria = _mapper.Map<Categoria>(categoriaVm);
            if (_servicio.Existe(categoria))
            {
                ModelState.AddModelError(string.Empty, "Categoría existente!!!");
                return View(categoriaVm);
            }
            try
            {
                // Obtén la categoría actualizada de la base de datos
                var categoriaEnBaseDeDatos = _servicio.GetCategoriaPorId(categoriaVm.CategoriaId);

                // Verifica si las versiones coinciden
                if (categoriaEnBaseDeDatos.RowVersion.SequenceEqual(categoriaVm.RowVersion))
                {
                    // Las versiones coinciden, puedes actualizar la categoría
                    _servicio.Guardar(categoria);
                    TempData["success"] = "Registro agregado!!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Alguien más ha modificado la categoría, maneja la concurrencia aquí
                    ModelState.AddModelError(string.Empty, "La categoría ha sido modificada por otro usuario.");
                    return View(categoriaVm);
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
                return View(categoriaVm);
                ModelState.AddModelError(string.Empty, "Error de concurrencia");
                return View(categoriaVm);

                // Manejar la excepción de concurrencia aquí si es necesario
            }
            //try
            //{
            //    _servicio.Guardar(categoria);
            //    TempData["success"] = "Registro agregado!!!";
            //    return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{

            //    TempData["error"] = ex.Message;
            //    return View(categoriaVm);
            //}
        }

        [HttpGet]
        public IActionResult Delete(int? categoriaId)
        {
            if (categoriaId == null || categoriaId == 0)
            {
                return NotFound();
            }
            var categoria = _servicio.GetCategoriaPorId(categoriaId.Value);
            if (categoria == null)
            {
                return NotFound();
            }
            CategoriaEditVm categoriaVm = _mapper.Map<CategoriaEditVm>(categoria);
            return View(categoriaVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int categoriaId)
        {
            var categoria = _servicio.GetCategoriaPorId(categoriaId);
            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                _servicio.Borrar(categoria.CategoriaId);
                TempData["success"] = "Registro eliminado!!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                CategoriaEditVm categoriaVm = _mapper.Map<CategoriaEditVm>(categoria);

                TempData["error"] = ex.Message;
                return View(categoriaVm);
            }
        }

    }
}
