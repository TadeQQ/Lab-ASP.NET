using Lab_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_3.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var list = _contactService.FindAllOrganizations()
            //    .Select(e => new SelectListItem()
            //    {
            //        Text = e.Name,
            //        Value = e.Id.ToString(),

            //    }).ToList();
            //return View(new Contact() { OrganizationList = list });

            var model = new Contact();
            model.OrganizationList = _contactService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name.ToString() })
                .ToList();
            return View(model); 
        }

        //private List<SelectListItem> CreateSelectListItem();
        //{
        //    return
        //}


    [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid) 
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View(); //ponownie wyswitl form
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if(ModelState.IsValid) 
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }
    }
}
