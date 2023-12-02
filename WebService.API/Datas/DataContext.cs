using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;

namespace WebService.API.Datas.Context;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<ProductSet> Stock { get; set; } = null!;
	public DbSet<Vga> Vgas { get; set; } = null!;
	public DbSet<Cpu> Cpus { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<ProductSet>().HasOne<Cpu>().WithOne()
		.HasForeignKey<ProductSet>(product => product.ProductId);
		modelBuilder.Entity<ProductSet>().HasOne<Vga>().WithOne()
		.HasForeignKey<Vga>(product => product.Id);
	}
}