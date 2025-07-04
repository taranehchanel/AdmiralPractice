namespace Api.Features.Payroll.Employees.Commands;

public record UpdateEmployeeCommand(
	System.Guid Id,
	string LastName,
	string FirstName,
	decimal Allowance,
	decimal BasicSalary,
	decimal Transportation,
	System.DateTime Date
	) : object,
	MediatR.IRequest<Dtos.Features.Payroll.Employees.UpdateEmployeeResponseDto>;
