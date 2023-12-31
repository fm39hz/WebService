using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models.Products;
using WebService.API.Datas.Models.Shopping;
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
	public DbSet<ShoppingCart> ShoppingCarts { get; init; } = null!;
	public DbSet<Order> Orders { get; init; } = null!;
	public DbSet<Invoice> Invoices { get; init; } = null!;
	public DbSet<ShippingInformation> ShippingInformations { get; init; } = null!;
	public DbSet<ShoppingItem> ShoppingItems { get; init; } = null!;
	public DbSet<Vga> Vgas { get; init; } = null!;
	public DbSet<Cpu> Cpus { get; init; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserInstance>(entity =>
		{
			entity.HasKey(u => u.Uid);
			entity.HasMany(u => u.ShippingInfomations)
			.WithOne().HasForeignKey(i => i.UserUId);
			entity.HasMany(u => u.Invoices)
			.WithOne()
			.HasForeignKey(i => i.UserUid);
		});
		modelBuilder.Entity<Invoice>(entity =>
		{
			entity.HasKey(i => i.Id);
			entity.HasOne<Order>()
			.WithOne(o => o.Invoice)
			.HasForeignKey<Invoice>(i => i.OrderId);
		});
		modelBuilder.Entity<Order>(entity =>
		{
			entity.HasOne(o => o.User)
			.WithOne()
			.HasForeignKey<Order>(o => o.UserUid);
			entity.HasOne(o => o.ShippingTarget)
			.WithOne()
			.HasForeignKey<Order>(o => o.ShippingId);
		});
		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasOne<Cpu>()
			.WithOne(c => c.Product)
			.HasForeignKey<Product>(p => p.SpecificationId);
			entity.HasOne<Vga>()
			.WithOne(v => v.Product)
			.HasForeignKey<Product>(p => p.SpecificationId);
		});
		modelBuilder.Entity<ShoppingCart>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.HasOne<UserInstance>()
			.WithOne(u => u.Cart)
			.HasForeignKey<ShoppingCart>(c => c.UserUid);
			entity.HasMany(e => e.ShoppingItems)
			.WithOne()
			.HasForeignKey(e => e.CartId);
		});
		modelBuilder.Entity<ShoppingItem>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.HasOne(e => e.Target)
			.WithOne()
			.HasForeignKey<ShoppingItem>(i => i.ProductId);
			entity.HasOne<ShoppingCart>()
			.WithMany(c => c.ShoppingItems)
			.HasForeignKey(i => i.CartId);
			entity.HasOne<Order>()
			.WithMany(o => o.Items)
			.HasForeignKey(i => i.OrderId);
		});
		base.OnModelCreating(modelBuilder);
	}
}