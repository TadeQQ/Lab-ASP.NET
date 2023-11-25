namespace WebApplication2.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

public class EmployeeController : Controller
{
    private readonly IEmployeesService _employeeService;

    public EmployeeController(IEmployeesService contactService)
    {
        _employeeService = contactService;
    }

    public IActionResult Index()
    {
        return View(_employeeService.FindAll());
    }

    [HttpGet]
    public IActionResult CreateEmployee()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateEmployee(Employee model)
    {
        if (ModelState.IsValid)
        {
            _employeeService.Add(model);
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var employee = _employeeService.FindById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(Employee model)
    {
        if (ModelState.IsValid)
        {
            _employeeService.Update(model);
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var employee = _employeeService.FindById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        _employeeService.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var employee = _employeeService.FindById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }


}

