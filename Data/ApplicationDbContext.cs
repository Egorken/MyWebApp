using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data.Identity;

public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Games>().Property(z => z.Id).UseIdentityColumn();
        builder.Entity<Games>().Property(z => z.NameOfTheGame).HasMaxLength(50);
        builder.Entity<Games>().HasData(
            new Games
            {
                Id = 1,
                NameOfTheGame = "GTA VI",
                Price = 6990.90m,
            });
    }

    public DbSet<Games> Games { get; set; }

    public DbSet<MyWebApp.Data.Identity.AspUserShow> AspUserShow { get; set; } = default!;

}