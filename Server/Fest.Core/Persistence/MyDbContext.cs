
using Fest.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Fest.Core.Persistence
{
    public class MyDbContext : DbContext
    {
        public DbSet<CityInfo> CityInfos { get; set; }
    }
}