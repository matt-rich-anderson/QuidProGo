using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuidProGo.Models;
using QuidProGo.Repositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace QuidProGo.Controllers
{
    public class AttorneyController : Controller
    {
        private readonly IConsultationRepository _consultationRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IUserProfileRepository _userProfileRepo;

        public AttorneyController(IConsultationRepository consultationRepository, ICategoryRepository categoryRepository, IUserProfileRepository userProfileRepository)
        {
            _consultationRepo = consultationRepository;
            _categoryRepo = categoryRepository;
            _userProfileRepo = userProfileRepository;
        }
        // GET
        public ActionResult Index()
        {
            int attorneyId = GetCurrentUserId();
            List<Consultation> consultations = _consultationRepo.GetConsultationsByAttorneyId(attorneyId);
            return View(consultations);
        }

        // GET
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AttorneyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttorneyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttorneyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AttorneyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttorneyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttorneyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
