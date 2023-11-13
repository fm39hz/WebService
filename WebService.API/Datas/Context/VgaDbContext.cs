using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models;

namespace WebService.API.Datas.DBContext;

public class VgaDbContext : DbContext
{
	public VgaDbContext(DbContextOptions<VgaDbContext> options) : base(options)
	{
	}

	public DbSet<Vga> Vgas { get; set; } = null!;
}