using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data.Identity;
using System;

public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Games> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Games>().Property(z => z.Id).UseIdentityColumn();
        builder.Entity<Games>().Property(z => z.NameOfTheGame).HasMaxLength(50);
        builder.Entity<Games>().Property(z => z.Price).HasColumnType("decimal(18, 2)");
        builder.Entity<Games>().HasData(
            new Games
            {
                Id = 1,
                NameOfTheGame = "GTA VI",
                Price = 6990.90m,
            });
    }
}
