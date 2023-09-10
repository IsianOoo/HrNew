using Microsoft.AspNetCore.Mvc;

namespace HrNew.MVC.Controllers
{
    public class HrRequestsController : Controller
    {
        private readonly IHrRequestService _hrRequestRepository;

        public HrRequestsController(IHrRequestService hrRequestRepository)
        {
            _hrRequestRepository = hrRequestRepository;
        }

        // GET: HrRequestsController
        public async Task<ActionResult> Index()
        {
            var model = await _hrRequestRepository.GetHrRequests();
            return View(model);
        }

        // GET: HrRequestsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _hrRequestRepository.GetHrRequestsDetails(id);
            return View(model);
        }

        // GET: HrRequestsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: HrRequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHrRequestVM hrRequest)
        {
            try
            {
                var response = await _hrRequestRepository.CreateHrRequest(hrRequest);
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
            return View(hrRequest);
        }

        // GET: HrRequestsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _hrRequestRepository.GetHrRequestsDetails(id);
            return View(model);
        }

        // POST: HrRequestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HrRequestVM hrRequest)
        {
            try
            {
                var response = await _hrRequestRepository.UpdateHrRequest(id, hrRequest);
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
            return View(hrRequest);
        }

        // GET: HrRequestsController/Delete/5
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var model = await _hrRequestRepository.DeleteHrRequest(id);
        //    return View();
        //}

        // POST: HrRequestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _hrRequestRepository.DeleteHrRequest(id);
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
