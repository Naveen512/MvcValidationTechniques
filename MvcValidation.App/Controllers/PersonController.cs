using Microsoft.AspNetCore.Mvc;
using MvcValidation.App.Models;

namespace MvcValidation.App.Controllers
{
    [Route("person")]
    public class PersonController : Controller
    {
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create-post")]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            return Content("Success");
        }

        [HttpGet]
        [Route("test-page")]
        public IActionResult TestPage()
        {
            return View("Test");
        }

        [HttpGet]
        [Route("get-dynamic-form")]
        public IActionResult DynamicForm()
        {
            return PartialView("DynamicPartilForm");
        }
    }
}