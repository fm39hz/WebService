using Microsoft.EntityFrameworkCore;

namespace WebService.API.Models;

public class ItemDbContext : DbContext
{
	public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
	{
	}

	public DbSet<Cpu> Cpus { get; set; } = null!;
	public DbSet<Vga> Vgas { get; set; } = null!;
	public DbSet<Item> AllItem { get; set; } = null!;
}