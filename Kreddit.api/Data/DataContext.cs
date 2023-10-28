using Kreddit.shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreddit.api.Data;

public class DataContext : DbContext
{
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    
    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany() // Assuming one user can have many posts
            .HasForeignKey(p => p.UserId);
    }
    
}