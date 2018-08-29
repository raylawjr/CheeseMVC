using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult Add(string name, string description)
        {
            bool isvalid = new bool();
            // add the new cheese to my existing cheeses
            if (name == null)
            {
                ViewBag.errormsg = "You didn't enter a cheese name!";
                return View();
            }

            foreach (char c in name)
            {
                if (Char.IsLetter(c) || Char.IsWhiteSpace(c))
                {
                    isvalid = true;
                }
                else
                {
                    isvalid = false;
                }
            }
            if (isvalid == false)
            {
                ViewBag.errormsg = "The cheese name should only include letters and spaces!";
                return View();
            }
            Cheeses.Add(name, description);

            return Redirect("/Cheese");
        }
        public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult GoneCheese(string[] cheese)
        {
            foreach (string toberemoved in cheese)
            {
                Cheeses.Remove(toberemoved);
            }
            return Redirect("/Cheese");
        }
    }
}
