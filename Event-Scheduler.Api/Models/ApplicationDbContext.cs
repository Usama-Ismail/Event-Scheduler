using Microsoft.EntityFrameworkCore;

namespace Event_Scheduler.Api.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }

    }
}
