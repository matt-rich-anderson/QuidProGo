using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuidProGo.Models;
using QuidProGo.Repositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace QuidProGo.Controllers
{

    public class ConsultationController : Controller
    {
        private readonly IConsultationRepository _consultationRepo;

        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepo = consultationRepository;
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
            return View();
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
