using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Users;
using WebService.API.Virtual.Abstract;

namespace WebService.API.Datas.Context;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<UserInstance> Users { get; init; } = null!;
	public DbSet<Product> Products { get; init; } = null!;
	public DbSet<Vga> Vgas { get; init; } = null!;
	public DbSet<Cpu> Cpus { get; init; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserInstance>().HasKey(u => u.Uid);
		modelBuilder.Entity<Product>()
		.HasOne(p => p.Cpu)
		.WithOne(c => c.Product)
		.HasForeignKey<Product>(p => p.ConcreateId);

		modelBuilder.Entity<Product>()
		.HasOne(p => p.Vga)
		.WithOne(v => v.Product)
		.HasForeignKey<Product>(p => p.ConcreateId);

		base.OnModelCreating(modelBuilder);
	}
}