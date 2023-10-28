namespace WebApplication2.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

public class EmployeeController : Controller
{
    // Metoda akcji do wyświetlania formularza
    public IActionResult Create()
    {
        return View();
    }

    // Metoda akcji do odbierania formularza
    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            // Zapisz dane pracownika...
            return RedirectToAction("Index"); // Przekieruj do strony głównej po zapisaniu danych
        }

        return View(employee); // Wróć do widoku z błędami walidacji
    }
}

