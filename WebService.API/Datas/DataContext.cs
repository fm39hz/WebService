using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;
using WebService.API.Service;

namespace WebService.API.Datas.Context;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Vga> Vgas { get; set; } = null!;
	public DbSet<Cpu> Cpus { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>(typeBuilder =>
		{
			typeBuilder.HasKey(e => e.Id);
			typeBuilder.Property(e => e.Name);
			typeBuilder.Property(e => e.Description);
			typeBuilder.Property(e => e.BasePrice);
			typeBuilder.Property(e => e.Specifications).HasConversion<SpecificationConverter>();
		});
	}
}