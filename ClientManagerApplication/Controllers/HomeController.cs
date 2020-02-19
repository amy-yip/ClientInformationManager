using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientManagerApplication.Controllers
{
    public class HomeController : Controller
    {

        Models.ClientsEntities database = new Models.ClientsEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(database.People);
        }

        public ActionResult Search(string name)
        {
            IEnumerable<Models.Person> result = database.People.Where(p => (p.first_name + " " + p.last_name).Contains(name));
            return View("Index", result);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Models.Person thePerson = database.People.SingleOrDefault(c => c.person_id == id);
            return View(thePerson);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.Person newPerson = new Models.Person();

                newPerson.first_name = collection["first_name"];
                newPerson.last_name = collection["last_name"];
                newPerson.notes = collection["notes"];
                newPerson.gender = collection["gender"];

                database.People.Add(newPerson);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var thePerson = database.People.SingleOrDefault(c => c.person_id == id);
            return View(thePerson);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Person thePerson = database.People.SingleOrDefault(c => c.person_id == id);

                thePerson.first_name = collection["first_name"];
                thePerson.last_name = collection["last_name"];
                thePerson.notes = collection["notes"];
                thePerson.gender = collection["gender"];

                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Person thePerson = database.People.SingleOrDefault(c => c.person_id == id);
            return View(thePerson);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Person thePerson = database.People.SingleOrDefault(c => c.person_id == id);

                thePerson.picture_id = null;
                database.SaveChanges();

                database.Pictures.RemoveRange(thePerson.Pictures);
                database.Contacts.RemoveRange(thePerson.Contacts);
                database.Addresses.RemoveRange(thePerson.Addresses);
                database.SaveChanges();

                database.People.Remove(thePerson);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
