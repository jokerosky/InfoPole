using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.DataBase;
using Microsoft.EntityFrameworkCore;

namespace InfoPole.Data
{
    public class InfoPoleDataContext: DbContext
    {
        public DbSet<KeyItem> KeyItems { get; set; }
        public DbSet<SearchEngine> SearchEngines { get; set; }
        public DbSet<MarkupTag> MarkupTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UrlItem> UrlItems { get; set; }
        public DbSet<UrlKey> UrlKeys { get; set; }
        public DbSet<KeyTag> KeyTags { get; set; }
    }
}
