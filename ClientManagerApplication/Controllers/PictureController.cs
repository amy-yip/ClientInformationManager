using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientManagerApplication.Controllers
{
    public class PictureController : Controller
    {
        Models.ClientsEntities database = new Models.ClientsEntities();

        // GET: Picture
        public ActionResult Index(int id)//Person ID
        {
            Models.Person thePerson = database.People.SingleOrDefault(p => p.person_id == id);
            return View(thePerson);
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)//Picture ID
        {
            Models.Picture thePicture = database.Pictures.SingleOrDefault(p => p.picture_id == id);
            return View(thePicture);
        }

        // GET: Picture/Create
        public ActionResult Create(int id)//Person ID
        {
            ViewBag.thePerson = database.People.SingleOrDefault(p => p.person_id == id);
            return View();
        }

        // POST: Picture/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection, HttpPostedFileBase newPicture)//Person ID
        {
            try
            {
                // TODO: Add insert logic here
                string[] types = { "image/gif", "image/jpeg", "image/png" };

                if (newPicture != null
                    && newPicture.ContentLength > 0
                    && types.Contains(newPicture.ContentType))
                {
                    Guid g = Guid.NewGuid();
                    string filename = g.ToString() + Path.GetExtension(newPicture.FileName);
                    string path = Server.MapPath("~/Images/");
                    path = Path.Combine(path, filename);
                    newPicture.SaveAs(path);

                    Models.Picture newPic = new Models.Picture()
                    {
                        caption = collection["caption"],
                        location = collection["location"],
                        time = collection["time"],
                        path = filename,
                        person_id = id
                    };

                    database.Pictures.Add(newPic);
                    database.SaveChanges();
                }

                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult MakeMyProfile(int id)
        {
            Models.Picture thePicture = database.Pictures.SingleOrDefault(p => p.picture_id == id);
            thePicture.Person.picture_id = id;
            database.SaveChanges();
            return RedirectToAction("Index", new { id = thePicture.person_id });
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)//Picture ID
        {
            Models.Picture thePicture = database.Pictures.SingleOrDefault(p => p.picture_id == id);
            return View(thePicture);
        }

        // POST: Picture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase thePicture)//Picture ID
        {
            try
            {
                // TODO: Add update logic here
                string[] types = { "image/gif", "image/jpeg", "image/png" };

                if (thePicture != null
                    && thePicture.ContentLength > 0
                    && types.Contains(thePicture.ContentType))               
                {
                    Guid g = Guid.NewGuid();
                    string filename = g.ToString() + Path.GetExtension(thePicture.FileName);
                    string path = Server.MapPath("~/Images/");
                    path = Path.Combine(path, filename);
                    thePicture.SaveAs(path);                            

                    Models.Picture aPicture = database.Pictures.SingleOrDefault(p => p.picture_id == id);

                    aPicture.caption = collection["caption"];
                    aPicture.time = collection["time"];
                    aPicture.location = collection["location"];
                    aPicture.path = filename;

                    database.SaveChanges();
                }

                return RedirectToAction("Index", new { id = id });
            }

            catch
            {
                return View();
            }
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)//Picture ID
        {
            Models.Picture thePicture = database.Pictures.SingleOrDefault(p => p.picture_id == id);
            return View(thePicture);
        }

        // POST: Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)//Picture ID
        {
            try
            {
                // TODO: Add delete logic here
                Models.Picture thePicture = database.Pictures.SingleOrDefault(p => p.picture_id == id);
                database.Pictures.Remove(thePicture);
                database.SaveChanges();

                return RedirectToAction("Index", new { id = thePicture.person_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
