using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc;
using Lab3___zadanieContextConnection.Entities;
using System.Linq;
using Lab3___zadanieContextConnection;
using Microsoft.AspNetCore.Authorization;

namespace Lab3zadanie.Controllers
{
    [Authorize]
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly AppDbContext _context;

        public EmployeeController(IEmployeeService employeeService, AppDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }

        public IActionResult Index()
        {
            var employee = _employeeService.FindAll().Select(EmployeeMapper.FromEntity).ToList();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var employeeEntity = EmployeeMapper.ToEntity(model);
                _employeeService.Add(employeeEntity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var employee = _employeeService.FindById(id);
            if (employee == null)
            {
                return NotFound();
            }

            var model = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PESEL = employee.PESEL,
                Position = employee.Position,
                Department = employee.Department,
                EmploymentDate = employee.EmploymentDate,
                TerminationDate = employee.TerminationDate
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Update(Employee model)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _employeeService.FindById(model.Id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                existingEmployee.FirstName = model.FirstName;
                existingEmployee.LastName = model.LastName;
                existingEmployee.PESEL = model.PESEL;
                existingEmployee.Position = model.Position;
                existingEmployee.Department = model.Department;
                existingEmployee.EmploymentDate = model.EmploymentDate;
                existingEmployee.TerminationDate = model.TerminationDate;

                _employeeService.Update(existingEmployee);

                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.FindById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(EmployeeMapper.FromEntity(employee));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var existingEmployee = _employeeService.FindById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            _employeeService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var employeeEntity = _employeeService.FindById(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            var model = EmployeeMapper.FromEntity(employeeEntity);
            return View(model);
        }

    }
}
