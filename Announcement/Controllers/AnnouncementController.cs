using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Announcement.Models;

namespace Announcement.Controllers
{
    public class AnnouncementController : Controller
    {
        AnnouncementContext db = new AnnouncementContext();
       
        // GET: Announcement
        public ActionResult Index()
        {
            IEnumerable<AnnouncementC> announcements = db.Announcements;
            ViewBag.Announcements = announcements;
            return View();
        }

        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create
        [HttpPost]
        public ActionResult Create(AnnouncementC EditedAnnouncement)
        {
            try
            {
                EditedAnnouncement.Date_Added = DateTime.Now;
                db.Announcements.Add(EditedAnnouncement);
                db.SaveChanges();

                IEnumerable<AnnouncementC> announcements = db.Announcements;
                ViewBag.Announcements = announcements;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(int id)
        {
            AnnouncementC announcement = db.Announcements.Find(id);

            return View(announcement);
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        public ActionResult Edit(AnnouncementC EditedAnnouncement)
        {
            try
            {
                AnnouncementC temp = db.Announcements.FirstOrDefault(x => x.Id == EditedAnnouncement.Id);
                temp.Title = EditedAnnouncement.Title;
                temp.Description = EditedAnnouncement.Description;
                db.SaveChanges();

                IEnumerable<AnnouncementC> announcements = db.Announcements;
                ViewBag.Announcements = announcements;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(int id)
        {
            AnnouncementC temp = new AnnouncementC();
            temp = db.Announcements.Find(id);
            db.Announcements.Remove(temp);
            db.SaveChanges();

            IEnumerable<AnnouncementC> announcements = db.Announcements;
            ViewBag.Announcements = announcements;

            return View("Index");
        }
    }
}
