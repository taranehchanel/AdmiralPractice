using Domain.Features.Payroll.Employees;
using Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class DatabaseContext : DbContext

{
    #region Constructor

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options: options)
    {
        Database.EnsureCreated();
    }

    #endregion /Constructor

    #region Properties

    #region Payroll Feature

    public DbSet<Employee> Employees { get; set; }

    #endregion /Payroll Feature

    #endregion /Properties

    #region Methods

    #region OnModelCreating()

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(DatabaseContext).Assembly);

        modelBuilder.Seed();
    }

    #endregion /OnModelCreating()

    #endregion /Methods
}