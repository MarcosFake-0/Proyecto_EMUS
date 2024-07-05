using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;
using Proyecto_EMUS.Models.ViewModels;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Proyecto_EMUS.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proyecto_EMUS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ProyectoEMUSRoles.Role_Admin)]
    public class DoctorController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public DoctorController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            List<Specialty> allSpecialties = _unitOfWork.Specialty.GetAll().ToList();
            DoctorVM doctorVM = new DoctorVM();

            //Crear doctor
            if (id == null || id <= 0)
            {
                doctorVM.Doctor = new Doctor();
                doctorVM.Specialties = allSpecialties.Select(i => new SelectListItem{
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                doctorVM.Specialty = new Specialty();
                doctorVM.DoctorSpecialties = new List<Specialty>();
                return View(doctorVM);
            }

            //editar
            doctorVM.Doctor = _unitOfWork.Doctor.Get(x => x.GMCNumber == id, includeProperties: "DoctorSpecialties.Specialty");

            if (doctorVM.Doctor == null)
                return NotFound(); 

            List<Specialty> doctorSpecialties = doctorVM.Doctor.DoctorSpecialties.Select(ds => ds.Specialty).ToList();
            List<Specialty> doctorSpecialtiesNoAssociated = allSpecialties.Except(doctorSpecialties).ToList();

            doctorVM.Specialties = doctorSpecialtiesNoAssociated.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            doctorVM.DoctorSpecialties = doctorSpecialties;
            doctorVM.Specialty = new Specialty();

            return View(doctorVM);
        }

        private string UpsertImageDoctor(IFormFile? file, string? urlImage)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                var uploads = Path.Combine(wwwRootPath, @"images\doctors");

                if (urlImage != null)
                {
                    var oldImageUrl = Path.Combine(wwwRootPath, urlImage);

                    if (System.IO.File.Exists(oldImageUrl))
                        System.IO.File.Delete(oldImageUrl);
                }

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                urlImage = fileName + extension;

            }

            return urlImage; 
        }

        [HttpPost]
        public IActionResult Upsert(DoctorVM doctorVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (doctorVM.IsCreated)
                {
                    if (_unitOfWork.Specialty.Get(x => x.Id == doctorVM.Specialty.Id) != null)
                    {
                        if (_unitOfWork.Doctor.Get(x => x.GMCNumber == doctorVM.Doctor.GMCNumber) != null)
                        {
                            TempData["error"] = "No se puedo crear el doctor porque ya se encuentra registrado el número de colegiado"; 
                        } else
                        {
                            doctorVM.Doctor.UrlImage = UpsertImageDoctor(file, doctorVM.Doctor.UrlImage);
                            _unitOfWork.Doctor.Add(doctorVM.Doctor);
                            DoctorSpecialty ds = new()
                            {
                                GMCNumber = doctorVM.Doctor.GMCNumber,
                                IdSpecialty = doctorVM.Specialty.Id
                            };
                            _unitOfWork.DoctorSpecialty.Add(ds);
                            _unitOfWork.Save();
                            TempData["success"] = "Doctor agregado con éxito";
                        }

                    } else
                    {
                        TempData["error"] = "No se pudo agregar al doctor";
                    }    
                }
                else
                {
                    doctorVM.Doctor.UrlImage = UpsertImageDoctor(file, doctorVM.Doctor.UrlImage);
                    if (doctorVM.DoctorSpecialties == null)
                    {
                        DoctorSpecialty ds = new()
                        {
                            IdSpecialty = doctorVM.Specialty.Id,
                            GMCNumber = doctorVM.Doctor.GMCNumber
                        };
                        _unitOfWork.DoctorSpecialty.Add(ds);
                    }
                    _unitOfWork.Doctor.Update(doctorVM.Doctor);
                    _unitOfWork.Save();
                    TempData["success"] = "Doctor editado con éxito";
                }
            }

            return RedirectToAction("Index");
        }

 

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var doctorList = _unitOfWork.Doctor.GetAll()
                .Select(doctor => new
                {
                    doctor.UrlImage,
                    doctor.FirstName,
                    doctor.LastName,
                    doctor.GMCNumber,
                }).ToList();

            return Json(new { data = doctorList });
        }


        [HttpDelete]
        public IActionResult DeleteDoctor(int? id)
        {
            Doctor doctorToDelete = _unitOfWork.Doctor.Get(x => x.GMCNumber == id);
            if (doctorToDelete == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Doctor.Remove(doctorToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Doctor(a) eliminado(a) con éxito" });
        }

        [HttpDelete]
        public IActionResult DeleteSpecialty(int? gmcNumber, int idSpecialty)
        {
            DoctorSpecialty dsToDelete = _unitOfWork.DoctorSpecialty.Get(x => x.IdSpecialty == idSpecialty && x.GMCNumber == gmcNumber);

            if (dsToDelete != null)
            {
                _unitOfWork.DoctorSpecialty.Remove(dsToDelete);
                _unitOfWork.Save();
                return Ok();
            }
            return Json(new { success = false, message = "Error al eliminar" });
        }

        [HttpPost]
        public IActionResult AddDoctorSpecialty(int? gmcNumber, int? idSpecialty)
        {
            if (gmcNumber == null || idSpecialty == null)
            {
                return Json(new { success = false, message = "GMC Number o Specialty Id son nulos" });
            }

            Doctor d = _unitOfWork.Doctor.Get(x => x.GMCNumber == gmcNumber);
            Specialty s = _unitOfWork.Specialty.Get(x => x.Id == idSpecialty);

            if (d == null)
            {
                return Json(new { success = false, message = "Doctor no encontrado" });
            }

            if (s == null)
            {
                return Json(new { success = false, message = "Especialidad no encontrada" });
            }

            DoctorSpecialty ds = new DoctorSpecialty()
            {
                GMCNumber = (int)gmcNumber,
                IdSpecialty = (int)idSpecialty
            };

            _unitOfWork.DoctorSpecialty.Add(ds);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Especialidad agregada exitosamente" });
        }

        #endregion
    }
}
