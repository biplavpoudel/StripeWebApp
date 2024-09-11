namespace StripeWebApp.Data;
using StripeWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class MvcContext: DbContext
{
    public MvcContext(DbContextOptions<MvcContext> options) : base(options){}
    public DbSet<Item> Items { get; set; }
}
