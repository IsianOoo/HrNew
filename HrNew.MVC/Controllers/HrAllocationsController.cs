using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HrNew.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HrAllocationsController : Controller
    {
        private readonly IHrAllocationService _deliveryAllocationRepository;

        public HrAllocationsController(IHrAllocationService deliveryAllocationRepository)
        {
            _deliveryAllocationRepository = deliveryAllocationRepository;
        }

        // GET: HrAllocationsController
        public async Task<ActionResult> Index()
        {
            var model = await _deliveryAllocationRepository.GetHrAllocations();
            return View(model);
        }

        // GET: HrAllocationsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _deliveryAllocationRepository.GetHrAllocationDetails(id);
            return View(model);
        }

        // GET: HrAllocationsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: HrAllocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHrAllocationVM deliveryAllocation)
        {
            try
            {
                var response = await _deliveryAllocationRepository.CreateHrAllocation(deliveryAllocation);
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
            return View(deliveryAllocation);
        }

        // GET: HrAllocationsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _deliveryAllocationRepository.GetHrAllocationDetails(id);
            return View(model);
        }

        // POST: HrAllocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HrAllocationVM deliveryAllocation)
        {
            try
            {
                var response = await _deliveryAllocationRepository.UpdateHrAllocation(id, deliveryAllocation);
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
            return View(deliveryAllocation);
        }

        // POST: HrAllocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _deliveryAllocationRepository.DeleteHrAllocation(id);
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
