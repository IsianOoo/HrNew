using HrNew.MVC.Contracts;
using HrNew.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrNew.MVC.Controllers
{
    public class HrTypesController : Controller
    {
        private readonly IHrTypeService _hrTypeRepository;

        public HrTypesController(IHrTypeService hrTypeRepository)
        {
            _hrTypeRepository = hrTypeRepository;
        }

        // GET: HrTypesController
        public async Task<ActionResult> Index()
        {
            var model = await _hrTypeRepository.GetHrTypes();
            return View(model);
        }

        // GET: HrTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _hrTypeRepository.GetHrTypesDetails(id);
            return View(model);
        }

        // GET: HrTypesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: HrTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHrTypeVM hrType)
        {
            try
            {
                var response = await _hrTypeRepository.CreateHrType(hrType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(hrType);
        }

        // GET: HrTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _hrTypeRepository.GetHrTypesDetails(id);
            return View(model);
        }

        // POST: HrTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HrTypeVM hrType)
        {
            try
            {
                var response = await _hrTypeRepository.UpdateHrType(id, hrType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(hrType);
        }

        // GET: HrTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _hrTypeRepository.DeleteHrType(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

    }
}
