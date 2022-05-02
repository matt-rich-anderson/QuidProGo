using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuidProGo.Repositories;

namespace QuidProGo.Controllers
{

    public class ConsultationController : Controller
    {
        private readonly IConsultationRepository _walkerRepo;

        public ConsultationController(IConsultationRepository walkerRepository)
        {
            _walkerRepo = walkerRepository;
        }



        // GET: ConsultationController
        public ActionResult Index()
        {
            return View();
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
    }
}
