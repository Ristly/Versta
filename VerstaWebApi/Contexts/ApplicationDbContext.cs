using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VerstaWebApi.Models;

namespace VerstaWebApi.Contexts;

public class ApplicationDbContext: DbContext
{
    public virtual DbSet<Order> Orders {get; set;}

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public void ApplyMigration()
        => Database.Migrate();
    
}
