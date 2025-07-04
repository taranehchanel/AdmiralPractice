namespace Dtos.Features.Payroll.Employees;

public class CreateEmployeeRequestDto : object
{
	public CreateEmployeeRequestDto() : base()
	{
	}

	public string? LastName { get; set; }
	public string? FirstName { get; set; }

	public decimal Allowance { get; set; }
	public decimal BasicSalary { get; set; }
	public decimal Transportation { get; set; }

	public System.DateTime Date { get; set; }
}
