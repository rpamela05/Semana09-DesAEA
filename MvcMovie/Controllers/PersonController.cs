using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            if (Session["Person"] == null)
            {
                List<Person> person = new List<Person>();
                person.Add(new Person { ID = 1, FirstName= "Ruth", LastName="Carbajal", BirthDay=new DateTime(2002,05,03), IsTecsup=true});
                person.Add(new Person { ID = 2, FirstName = "Camila", LastName = "Sanchez", BirthDay = new DateTime(2000, 10, 27), IsTecsup = false });
                Session["Person"] = person;
            }
            return View(Session["Person"]);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var model = ((List<Person>)Session["Person"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                if (Session["Person"] == null)
                    Session["Person"] = new List<Person>();
                // TODO: Add insert logic here
                ((List<Person>)Session["Person"]).Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ((List<Person>)Session["Person"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person model)
        {
            try
            {
                if (Session["Person"] == null)
                    Session["Person"] = new List<Person>();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<Person>)Session["Person"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person model)
        {
            try
            {
                // TODO: Add delete logic here
                ((List<Person>)Session["Person"]).RemoveAll(r => r.ID == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
