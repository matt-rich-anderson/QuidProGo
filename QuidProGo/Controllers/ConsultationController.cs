using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuidProGo.Models;
using QuidProGo.Models.ViewModels;
using QuidProGo.Repositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace QuidProGo.Controllers
{

    public class ConsultationController : Controller
    {
        private readonly IConsultationRepository _consultationRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IUserProfileRepository _userProfileRepo;

        public ConsultationController(IConsultationRepository consultationRepository, ICategoryRepository categoryRepository, IUserProfileRepository userProfileRepository)
        {
            _consultationRepo = consultationRepository;
            _categoryRepo = categoryRepository;
            _userProfileRepo = userProfileRepository;
        }

        // GET: ConsultationController
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Consultation> consultations = _consultationRepo.GetConsultationsByClientId(ownerId);

            return View(consultations);
        }

        // GET: ConsultationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConsultationController/Create
        public ActionResult Create()
        {
            List<UserProfile> attorneys = _userProfileRepo.GetUserProfileByUserTypeId(1);
            List<Category> categories = _categoryRepo.GetAllCategorys();

            ConsultationCreateViewModel viewModel = new ConsultationCreateViewModel
            {
                AttorneyList = attorneys,
                CategoryList = categories
            };

            return View(viewModel);
        }

        // POST: ConsultationController/Create
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

        // GET: ConsultationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConsultationController/Edit/5
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

        // GET: ConsultationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConsultationController/Delete/5
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
