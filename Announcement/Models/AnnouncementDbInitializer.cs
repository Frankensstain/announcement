using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Announcement.Models
{
    public class AnnouncementDbInitializer : DropCreateDatabaseAlways<AnnouncementContext>
    {
        protected override void Seed(AnnouncementContext db)
        {
           
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "asd", Description = "aa aa"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "weweq", Description = "aa weraa"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "qwe", Description = "aadfgdg xcvaa"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "1 2 3 ajkljkl", Description = "aadfgfd aa"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "aa bb cc", Description="111 223 3393"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "bb cc", Description="223 333"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "aa bb cc", Description="111 2263 333 gfg  hgf fgj fjyffg j"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "gg jj", Description="444"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "gg jj", Description="444"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "aa bb cc", Description="111 4223 333"});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "aa bb cc", Description="111 223 333  fjg ku6 lil we tz "});
            db.Announcements.Add(new AnnouncementC { Date_Added = DateTime.Now, Title = "aa bb cc", Description = "111 2238 333" });
            base.Seed(db);
        }
    }
}