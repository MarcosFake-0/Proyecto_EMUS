﻿using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;

namespace Proyecto_EMUS.Controllers
{
    public class PatientController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
