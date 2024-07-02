using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;
using Proyecto_EMUS.Models.ViewModels;

namespace Proyecto_EMUS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public DoctorController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Doctor> doctorList = _unitOfWork.Doctor.GetAll().ToList();
            return View(doctorList);
        }

        [HttpGet]
        public IActionResult Upsert(int? Id)
        {
            DoctorVM doctorVM = new DoctorVM();

            if (Id == null || Id == 0)
            {
                doctorVM.Doctor = new Doctor();
                doctorVM.Specialties = new List<Specialty>();
                return View(doctorVM);
            }

            doctorVM.Doctor = _unitOfWork.Doctor.Get(x => x.GMCNumber == Id);

            if (doctorVM.Doctor == null)
            {
                return NotFound();
            }

            doctorVM.Specialties = (List<Specialty>)_unitOfWork.DoctorSpecialty.GetAllByDoctorGMCNumber(doctorVM.Doctor.GMCNumber);

            return View(doctorVM);
        }


        [HttpPost]
        public IActionResult Upsert(DoctorVM doctorVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file.FileName);
                    var uploads = Path.Combine(wwwRootPath, @"images\doctors");

                    if (doctorVM.Doctor.UrlImage != null)// Update
                    {
                        var oldImageUrl = Path.Combine(wwwRootPath, doctorVM.Doctor.UrlImage);

                        if (System.IO.File.Exists(oldImageUrl))
                            System.IO.File.Delete(oldImageUrl);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    doctorVM.Doctor.UrlImage = @"images\doctors\" + fileName + extension;

                }

                Doctor doctorExist = _unitOfWork.Doctor.Get(x => x.GMCNumber == doctorVM.Doctor.GMCNumber);

                if (doctorExist == null)
                {
                    _unitOfWork.Doctor.Add(doctorVM.Doctor);

                    DoctorSpecialty ds = new DoctorSpecialty();
                    ds.Doctor = doctorVM.Doctor;

                    foreach (Specialty specialty in doctorVM.Specialties)
                    {
                        ds.Specialty = specialty;
                        _unitOfWork.DoctorSpecialty.Add(ds);
                    }
                } else
                {
                    _unitOfWork.Doctor.Update(doctorVM.Doctor);
                    _unitOfWork.Save();
                    TempData["success"] = "Vehicle saved successfully";
                }
            }

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public IActionResult DeleteSpecialty(int? GMCNumber, int IdSpecialty)
        {
            DoctorSpecialty dsToDelete = _unitOfWork.DoctorSpecialty.Get(x => x.IdSpecialty == IdSpecialty && x.GMCNumber == GMCNumber);

            if (dsToDelete != null)
            {
                _unitOfWork.DoctorSpecialty.Remove(dsToDelete);
                _unitOfWork.Save();
                TempData["success"] = "Specialidad borrada";
            }

            return RedirectToAction("Upsert", new { Id = GMCNumber });
        }

        [HttpDelete]
        public IActionResult DeleteDoctor (int? GMCNumber)
        {
            Doctor doctorToDelete = _unitOfWork.Doctor.Get(x => x.GMCNumber == GMCNumber);
            if (doctorToDelete != null)
            {
                List<DoctorSpecialty> doctorSpecialties = (List<DoctorSpecialty>)_unitOfWork.DoctorSpecialty.GetAllByDoctorGMCNumber(doctorToDelete.GMCNumber);
                _unitOfWork.DoctorSpecialty.RemoveRange(doctorSpecialties);
                _unitOfWork.Doctor.Remove(doctorToDelete);
                _unitOfWork.Save();
                TempData["success"] = "Se ha eliminado el doctor"; 
            }
            return RedirectToAction("Index");
        }
    }
}
