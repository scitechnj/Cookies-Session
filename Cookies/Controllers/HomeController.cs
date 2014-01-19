using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies.Controllers
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class HomeController : Controller
    {
        private const string Incrementor = "Incrementor";

        public ActionResult Index()
        {
            int number;
            if (Request.Cookies[Incrementor] == null)
            {
                number = 0;
            }
            else
            {
                number = int.Parse(Request.Cookies[Incrementor].Value);

            }
            number++;

            var cookie = new HttpCookie(Incrementor, number.ToString());
            //cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);

            return View(number);
        }

        public ActionResult SessionTest()
        {
            int number;
            if (Session[Incrementor] == null)
            {
                //first time
                number = 0;
            }
            else
            {
                number = (int)Session[Incrementor];
            }
            number++;
            Session[Incrementor] = number;
            return View("Index", number);
        }

        public ActionResult Person()
        {
            string personSession = "Person";
            if (Session[personSession] == null)
            {
                Session[personSession] = new Person
                    {
                        FirstName = "Avrumi",
                        LastName = "Friedman",
                        Age = 31
                    };
            }
            var person = (Person) Session[personSession];
            person.Age++;
            return View(person);
        }

    }

}
