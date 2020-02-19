using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientManagerApplication.Controllers
{
    public class ContactController : Controller
    {

        Models.ClientsEntities database = new Models.ClientsEntities();

        // GET: Contact
        public ActionResult Index(int id)//Person ID
        {
            ViewBag.id = id;

            Models.Person thePerson = database.People.SingleOrDefault(c => c.person_id == id);
            return View(thePerson);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)//Contact ID
        {
            Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // GET: Contact/Create
        public ActionResult Create(int id)//Person ID
        {
            ViewBag.thePerson = database.People.SingleOrDefault(c => c.person_id == id);
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)//Person ID
        {
            try
            {
                // TODO: Add insert logic here
                Models.Contact newContact = new Models.Contact()
                {
                    person_id = id,
                    information_type = collection["information_type"],
                    information = collection["information"]
                };

                database.Contacts.Add(newContact);
                database.SaveChanges();

                return RedirectToAction("Index", new { id = newContact.person_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)//Contact ID
        {
            var theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)//Contact ID
        {
            try
            {
                // TODO: Add update logic here
                Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);

                theContact.information_type = collection["information_type"];
                theContact.information = collection["information"];

                database.SaveChanges();

                return RedirectToAction("Index", new { id = theContact.person_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)//Contact ID
        {
            Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(theContact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)//Contact ID
        {
            try
            {
                // TODO: Add delete logic here
                Models.Contact theContact = database.Contacts.SingleOrDefault(c => c.contact_id == id);
                database.Contacts.Remove(theContact);
                database.SaveChanges();

                return RedirectToAction("Index", new { id = theContact.person_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
