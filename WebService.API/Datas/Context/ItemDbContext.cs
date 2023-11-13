using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models;

namespace WebService.API.Datas.DBContext;

public class ItemDbContext : DbContext
{
	public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
	{
	}

	public DbSet<Item> Items { get; set; } = null!;
}