using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Payroll.Employees.Commands;

public class UpdateEmployeeHandler : object, MediatR.IRequestHandler
	<UpdateEmployeeCommand, Dtos.Features.Payroll.Employees.UpdateEmployeeResponseDto?>
{
	public UpdateEmployeeHandler
		(Persistence.DatabaseContext databaseContext,
		OverTimePolicies.ICalculator calculator) : base()
	{
		Calculator = calculator;
		DatabaseContext = databaseContext;
	}

	protected OverTimePolicies.ICalculator Calculator { get; init; }
	protected Persistence.DatabaseContext DatabaseContext { get; init; }

	public async System.Threading.Tasks.Task
		<Dtos.Features.Payroll.Employees.UpdateEmployeeResponseDto?> Handle
		(UpdateEmployeeCommand request, System.Threading.CancellationToken cancellationToken = default)
	{
		var foundedEmployee =
			await
			DatabaseContext.Employees
			.Where(current => current.Id == request.Id)
			.FirstOrDefaultAsync();

		if (foundedEmployee is null)
		{
			return null;
		}

		foundedEmployee.Date = System.DateTime.Now;

		foundedEmployee.LastName = request.LastName;
		foundedEmployee.FirstName = request.FirstName;
		foundedEmployee.Allowance = request.Allowance;
		foundedEmployee.BasicSalary = request.BasicSalary;
		foundedEmployee.Transportation = request.Transportation;

		foundedEmployee.CalculateSalary(calculator: Calculator);

		await DatabaseContext.SaveChangesAsync();

		var response =
			new Dtos.Features.Payroll.Employees.UpdateEmployeeResponseDto
			{
				Id = foundedEmployee.Id,

				Salary = foundedEmployee.Salary,
				Date = foundedEmployee.Date,
				LastName = foundedEmployee.LastName,
				FirstName = foundedEmployee.FirstName,
				Allowance = foundedEmployee.Allowance,
				BasicSalary = foundedEmployee.BasicSalary,
				Transportation = foundedEmployee.Transportation,
			};

		return response;
	}
}
