using Microsoft.EntityFrameworkCore;
using WebService.API.Models;

namespace WebService.API.DBContext;

public class ItemDbContext : DbContext
{
	public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
	{
	}

	public DbSet<Item> Items { get; set; } = null!;
}