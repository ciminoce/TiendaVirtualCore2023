using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;
using TiendaVirtualCore.Web.ViewModels.Pais;
using X.PagedList;

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

        public ActionResult Index(int? page, int? pageSize)
        {
            var lista = _servicio.GetPaises();
            var listaVm = _mapper.Map<List<PaisListVm>>(lista);

            page = (page ?? 1);
            pageSize = (pageSize ?? 10);
            return View(listaVm.ToPagedList(page.Value, pageSize.Value));
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
                _servicio.Guardar(pais);
                TempData["success"] = "Registro agregado!!!";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                TempData["error"] = "Ha ocurrido un error al guardar los cambios.";
                return View(paisVm);
            }
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
            if (_servicio.EstaRelacionado(pais))
            {
                ModelState.AddModelError(string.Empty, "País relacionado!!!");
                PaisEditVm paisVm = _mapper.Map<PaisEditVm>(pais);
                return View(paisVm);
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
