namespace HTSM_api.Models;
using Microsoft.EntityFrameworkCore;

public class ProjectEnvironmentContext : DbContext
{
    public ProjectEnvironmentContext(DbContextOptions<ProjectEnvironmentContext> options)
        : base(options)
    {
    }

    public DbSet<ProjectEnvironmentTask> ProjectEnvironmentTasks { get; set; } = null!;
}