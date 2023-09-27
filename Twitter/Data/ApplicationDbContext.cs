using Microsoft.EntityFrameworkCore;
using Twitter.Models;

namespace Twitter.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}