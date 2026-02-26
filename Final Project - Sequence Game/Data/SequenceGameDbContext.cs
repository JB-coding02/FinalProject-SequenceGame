using Microsoft.EntityFrameworkCore;
using Final_Project___Sequence_Game.Models;

namespace Final_Project___Sequence_Game.Data;

public class SequenceGameDbContext : DbContext
{
    public DbSet<PlayerData> PlayerData { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerData>().ToTable("PlayerData");
        modelBuilder.Entity<PlayerData>().HasKey(p => p.PlayerId);
        modelBuilder.Entity<PlayerData>().Property(p => p.Username).HasMaxLength(200);
        modelBuilder.Entity<PlayerData>().Property(p => p.PlayerEmail).HasMaxLength(200);
        modelBuilder.Entity<PlayerData>().Property(p => p.PasswordHash).HasMaxLength(500);
    }

    public static string GetConnectionString()
    {
        return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SequenceGameDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Command Timeout=30";
    }
}