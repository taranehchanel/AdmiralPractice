namespace Persistence.Features.Payroll.Employees.Configurations;

internal sealed class EmployeeConfiguration : object, Microsoft
	.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Features.Payroll.Employees.Employee>
{
	public EmployeeConfiguration() : base()
	{
	}

	public void Configure(Microsoft.EntityFrameworkCore.Metadata
		.Builders.EntityTypeBuilder<Domain.Features.Payroll.Employees.Employee> builder)
	{
		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasIndex(current => new { current.FirstName })
			.IsUnique(unique: false)
			;
		// **************************************************

		// **************************************************
		builder
			.HasIndex(current => new { current.LastName })
			.IsUnique(unique: false)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
