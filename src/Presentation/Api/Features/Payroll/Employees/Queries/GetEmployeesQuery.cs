namespace Api.Features.Payroll.Employees.Queries;

public record GetEmployeesQuery() : object, MediatR.IRequest
	<System.Collections.Generic.IEnumerable<Domain.Features.Payroll.Employees.Employee>>;
