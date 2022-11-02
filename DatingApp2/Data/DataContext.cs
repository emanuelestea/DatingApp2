using DatingApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp2.Data
{
    public class DataContext : DbContext
    {
        //quando la classe viene creata, il costruttore riceve delle opzioni tramite dependency injection
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
