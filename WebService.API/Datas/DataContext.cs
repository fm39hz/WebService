using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Users;

namespace WebService.API.Datas.Context;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<UserInstance> Users { get; init; } = null!;
	public DbSet<ProductSet> Products { get; init; } = null!;
	public DbSet<Vga> Vgas { get; init; } = null!;
	public DbSet<Cpu> Cpus { get; init; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserInstance>().HasKey(u => u.Uid);
	}
}