using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tp3dotnet.Models;

namespace tp3dotnet.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/{id:int}")]

        public ActionResult Index(int id)
        {
            var personal_Info = new Personal_info();
            var model = personal_Info.GetPerson(id);
            return View(model);
        }


        public ActionResult all()
        {
            var model = new Personal_info();
            return View(model);
        }


        [HttpGet]
        public IActionResult Search()
        {
            ViewBag.notFound = false;
            return View();
        }

        [HttpPost]
        public ActionResult Search(String first_name,String country)
        { 
            var personal_info = new Personal_info();
            foreach (var person in personal_info.GetAllPerson())
            {
                if (person.country == country && person.first_name == first_name)
                {
                    Redirect("Person/"+person.id.ToString());
                }
            }
            ViewBag.notFound = true;
            return View();

        }
    }
}
