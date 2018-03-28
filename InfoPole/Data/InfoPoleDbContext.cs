using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core;
using InfoPole.Core.DataBase;
using InfoPole.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoPole.Data
{
  public class InfoPoleDbContext : DbContext
  {
    

    public DbSet<SearchKey> SearchKeys{ get; set; }
    public DbSet<SearchEngine> SearchEngines { get; set; }
    public DbSet<SearchKeyFrequency> SearchKeyFrequencies { get; set; }
    public DbSet<MarkupTag> MarkupTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<UrlItem> UrlItems { get; set; }
    public DbSet<UrlKey> UrlKeys { get; set; }
    public DbSet<KeyTag> KeyTags { get; set; }
    public DbSet<DataFile> DataFiles { get; set; }

    public InfoPoleDbContext(DbContextOptions<InfoPoleDbContext> options)
      : base(options)
    {
    }
  }
}
