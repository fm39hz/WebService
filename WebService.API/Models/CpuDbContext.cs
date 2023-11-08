using Microsoft.EntityFrameworkCore;

namespace WebService.API.Models;

public class CpuDbContext : DbContext
{
	public CpuDbContext(DbContextOptions<CpuDbContext> options) : base(options)
	{
	}

	public DbSet<Cpu> Items { get; set; } = null!;
}