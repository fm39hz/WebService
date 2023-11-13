using Microsoft.EntityFrameworkCore;
using WebService.API.Datas.Models;

namespace WebService.API.Datas.DBContext;

public class CpuDbContext : DbContext
{
	public CpuDbContext(DbContextOptions<CpuDbContext> options) : base(options)
	{
	}

	public DbSet<Cpu> Cpus { get; set; } = null!;
}