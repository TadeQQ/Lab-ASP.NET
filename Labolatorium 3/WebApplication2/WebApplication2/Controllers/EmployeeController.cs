namespace WebApplication2.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

public class EmployeeController : Controller
{
    public IActionResult CreateEmployee()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateEmployee(Employee employee)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        return View(employee);
    }

    public IActionResult Index()
    {
        List<Employee> employees = new List<Employee>(); // Pobierz listę pracowników
        return View(employees);
    }

}

