using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using QuidProGo.Models;
using QuidProGo.Models.ViewModels;
using QuidProGo.Repositories;
using System;
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

        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Consultation> consultations = _consultationRepo.GetConsultationsByClientId(ownerId);

            return View(consultations);
        }

        public ActionResult Details(int id)
        {
            Consultation consultation = _consultationRepo.GetConsultationById(id);
            consultation.Categories = _categoryRepo.GetCategByConsultId(id);
            consultation.Attorney = _userProfileRepo.GetAttorByConsultId(id);

            return View(consultation);
        }

        public ActionResult Create()
        {
            List<UserProfile> attorneys = _userProfileRepo.GetUserProfileByUserTypeId(1);
            List<Category> categories = _categoryRepo.GetAllCategorys();


            ConsultationCreateViewModel viewModel = new ConsultationCreateViewModel
            {
                AttorneyOptions = attorneys,
                CategoryOptions = categories,
                SelectedCategoryIds = new List<int>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultationCreateViewModel viewModel)
        {
            try
            {
                viewModel.Consultation.ClientUserId = GetCurrentUserId();
                viewModel.Consultation.CreateDateTime = DateAndTime.Now;
                _consultationRepo.AddConsultation(viewModel.Consultation);

                foreach (int categoryId in viewModel.SelectedCategoryIds)
                {
                    _categoryRepo.AddConsultationCatagory(viewModel.Consultation.Id, categoryId);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                List<UserProfile> attorneys = _userProfileRepo.GetUserProfileByUserTypeId(1);
                List<Category> categories = _categoryRepo.GetAllCategorys();
                viewModel.AttorneyOptions = attorneys;
                viewModel.CategoryOptions = categories;
                
                return View(viewModel);
            }
        }

        public ActionResult Edit(int id)
        {   

            ConsultationEditViewModel viewModel = new ConsultationEditViewModel
            {
                Consultation = _consultationRepo.GetConsultationById(id),
                AttorneyOptions = _userProfileRepo.GetUserProfileByUserTypeId(1),
            };

            return View(viewModel);
        }

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

        public ActionResult Delete(int id)
        {
            Consultation consultation = _consultationRepo.GetConsultationById(id);
            consultation.Attorney = _userProfileRepo.GetAttorByConsultId(id);

            return View(consultation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Consultation consultation)
        {
            try
            {
                _consultationRepo.DeleteConsultation(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(consultation);
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
