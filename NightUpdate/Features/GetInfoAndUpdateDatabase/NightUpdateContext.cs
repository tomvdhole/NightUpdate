using Microsoft.EntityFrameworkCore;

namespace NightUpdate.Features.GetInfoAndUpdateDatabase;
public class NightUpdateContext : DbContext
{
    public DbSet<Test> Tests { get; set; }

    public NightUpdateContext(DbContextOptions options)
        : base(options) { }

}