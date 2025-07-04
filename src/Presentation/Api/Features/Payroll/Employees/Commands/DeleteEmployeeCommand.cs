namespace Api.Features.Payroll.Employees.Commands;

public record DeleteEmployeeCommand(System.Guid Id) : object, MediatR.IRequest<bool>;
