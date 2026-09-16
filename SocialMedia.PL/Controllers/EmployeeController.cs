using Microsoft.AspNetCore.Mvc;
using SocialMedia.BLL.Services.Abstraction;
using SocialMedia.BLL.ModelVM.EmployeeVM;
using SocialMedia.BLL.Helper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SocialMedia.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        public IActionResult GetById(int id)
        {
            var result = service.GetById(id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        public IActionResult Create()
        {
            CreateEmployeeVM addEmp = new CreateEmployeeVM();
            return View(addEmp);
        }

        [HttpPost]
        public IActionResult SaveData(CreateEmployeeVM empVM)
        {
            if (ModelState.IsValid)
            {
                var result = service.Create(empVM);
                if (result)
                {
                    return RedirectToAction("GetAll");
                }
            }
            return View("Create", empVM);
        }

        [HttpPost]
        public IActionResult Delete(int employeeId)
        {
            service.Delete(employeeId);
            return RedirectToAction("GetAll");
        }
       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = service.GetById(id);
            if (emp == null)
            {
                return RedirectToAction("GetAll");
            }

            UpdateEmployeeVM updateEmp = new UpdateEmployeeVM
            {
                EmployeeId = emp.EmployeeId,
                Name = emp.Name,
                Age = emp.Age,
                PathImage = emp.PathImage
            };

            return View(updateEmp);
        }

        [HttpPost]
        public IActionResult SaveEdit(UpdateEmployeeVM empVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", empVM);
            }
            service.Update(empVM);
            return RedirectToAction("GetAll");
        }

    }
}
