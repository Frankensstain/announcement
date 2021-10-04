using Announcement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Announcement.Controllers
{
    public class HomeController : Controller
    {
        AnnouncementContext db = new AnnouncementContext();
        public ActionResult Index()
        {

            List<(int, int, double, double)> res = new List<(int, int, double, double)>();

            List<AnnouncementC> myList = db.Announcements.ToList();
            //визначення процентного значення коефіцієнта подібності (подібні слова/всі слова) для тайтла і дескрипшина для ітого та йотого запису 
            for (int i = 0; i < myList.Count; i++)
            {
                for (int j = i + 1; j < myList.Count; j++)
                {
                    res.Add(
                    (
                        i,
                        j,
                        (double)myList[i].Title.Split(' ').Intersect(myList[j].Title.Split(' ')).ToList().Count / myList[i].Title.Split(' ').Union(myList[j].Title.Split(' ')).ToList().Count,
                        (double)myList[i].Description.Split(' ').Intersect(myList[j].Description.Split(' ')).ToList().Count / myList[i].Description.Split(' ').Union(myList[j].Description.Split(' ')).ToList().Count
                    ));
                }
            }
            //відкидаємо пари, де подібність нульова
            res = res.Where(x => x.Item3 != 0 && x.Item4 != 0).ToList();
            //сортуємо по спаданню тайтл
            res = res.OrderByDescending(x => x.Item3).ToList();
            //відбираємо елементи, де подібність тайт така ж як і в першого елемента
            res = res.Where(x => x.Item3 == res[0].Item3).ToList();
            //сортуємо по спаданню дескрипшин
            res = res.OrderByDescending(x => x.Item4).ToList();
            //відпираємо 3 перших записи списку
            res = res.Take(3).ToList();

            //формуємо остаточний результат
            List<AnnouncementC> rest = new List<AnnouncementC>();
            res.ForEach(x =>
            {
                rest.Add(
                    myList[x.Item1]
                    );
                rest.Add(
                   myList[x.Item2]
                   );

            });

            ViewBag.Announcements = rest;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}