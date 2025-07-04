namespace Api.Features.Payroll.Employees.Commands;

public class CreateEmployeeHandler : object, MediatR.IRequestHandler
	<CreateEmployeeCommand, Dtos.Features.Payroll.Employees.CreateEmployeeResponseDto>
{
	public CreateEmployeeHandler
		(Persistence.DatabaseContext databaseContext,
		OverTimePolicies.ICalculator calculator) : base()
	{
		Calculator = calculator;
		DatabaseContext = databaseContext;
	}

	protected OverTimePolicies.ICalculator Calculator { get; init; }
	protected Persistence.DatabaseContext DatabaseContext { get; init; }

	public async System.Threading.Tasks.Task
		<Dtos.Features.Payroll.Employees.CreateEmployeeResponseDto> Handle(CreateEmployeeCommand request,
		System.Threading.CancellationToken cancellationToken = default)
	{
		var employee =
			new Domain.Features.Payroll.Employees.Employee
			(firstName: request.FirstName, lastName: request.LastName)
			{
				Date = System.DateTime.Now,
				Allowance = request.Allowance,
				BasicSalary = request.BasicSalary,
				Transportation = request.Transportation,
			};

		employee.CalculateSalary(calculator: Calculator);

		await DatabaseContext.AddAsync(entity: employee);

		await DatabaseContext
			.SaveChangesAsync();

		var response =
			new Dtos.Features.Payroll.Employees.CreateEmployeeResponseDto
			{
				Id = employee.Id,
				Salary = employee.Salary,
				Date = System.DateTime.Now,
				LastName = employee.LastName,
				FirstName = employee.FirstName,
				Allowance = employee.Allowance,
				BasicSalary = employee.BasicSalary,
				Transportation = employee.Transportation,
			};

		return response;
	}
}
