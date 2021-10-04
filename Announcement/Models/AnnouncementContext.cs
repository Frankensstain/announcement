using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Announcement.Models
{
    public class AnnouncementContext: DbContext
    {
        public DbSet<AnnouncementC> Announcements { get; set; }
    }
}