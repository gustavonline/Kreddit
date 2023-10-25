using Kreddit.shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Kreddit.api.Data;

public class DataContext : DbContext
{
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    
    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();
    
}