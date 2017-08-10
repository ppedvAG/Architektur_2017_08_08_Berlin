using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var customers = _unitOfWork.Customers.GetAll();

            return View("Index", customers);
        }
    }
}