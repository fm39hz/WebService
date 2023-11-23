using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;
using WebService.API.VirtualBase;

namespace WebService.API.Datas.Context;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<Specifications> Specifications { get; set; } = null!;
	public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Vga> Vgas { get; set; } = null!;
	public DbSet<Cpu> Cpus { get; set; } = null!;
}