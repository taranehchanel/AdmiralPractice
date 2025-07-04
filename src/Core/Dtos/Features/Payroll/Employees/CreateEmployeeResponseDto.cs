namespace Dtos.Features.Payroll.Employees;

public class CreateEmployeeResponseDto : object
{
	public CreateEmployeeResponseDto() : base()
	{
	}

	public System.Guid Id { get; set; }

	public string? LastName { get; set; }
	public string? FirstName { get; set; }

	public decimal Salary { get; set; }
	public decimal Allowance { get; set; }
	public decimal BasicSalary { get; set; }
	public decimal Transportation { get; set; }

	public System.DateTime Date { get; set; }
}
