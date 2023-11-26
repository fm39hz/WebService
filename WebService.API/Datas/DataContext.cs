using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;
using WebService.API.VirtualBase;

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
		modelBuilder.Entity<Specification>()
		.HasOne(spec => spec.ProductTarget)
		.WithOne(product => product.SpecificationInfo)
		.HasForeignKey<Specification>(spec => spec.ProductId);
		modelBuilder.Entity<Specification>().HasKey(s => s.Id);
		modelBuilder.Entity<Vga>().ToTable("Vgas");
		modelBuilder.Entity<Vga>().Property(v => v.Id).HasColumnName("Id");
		modelBuilder.Entity<Vga>().Property(v => v.Manufacturer).HasColumnName("Manufacturer");
		modelBuilder.Entity<Vga>().Property(v => v.Frequency).HasColumnName("Frequency");
		modelBuilder.Entity<Vga>().Property(v => v.Vram).HasColumnName("Vram");
		modelBuilder.Entity<Cpu>().ToTable("Cpus");
		modelBuilder.Entity<Cpu>().Property(c => c.Id).HasColumnName("Id");
		modelBuilder.Entity<Cpu>().Property(c => c.Manufacturer).HasColumnName("Manufacturer");
		modelBuilder.Entity<Cpu>().Property(c => c.Socket).HasColumnName("Socket");
		modelBuilder.Entity<Cpu>().Property(c => c.Voltage).HasColumnName("Model");
		modelBuilder.Entity<Cpu>().Property(c => c.Core).HasColumnName("Core");
		modelBuilder.Entity<Cpu>().Property(c => c.Thread).HasColumnName("Thread");
		modelBuilder.Entity<Cpu>().Property(c => c.Frequency).HasColumnName("Frequency");
	}
}