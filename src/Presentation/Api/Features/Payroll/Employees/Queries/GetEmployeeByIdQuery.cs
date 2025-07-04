// **************************************************
//namespace Api.Features.Payroll.Employees.Queries;

//public class GetEmployeeByIdQuery : object,
//	MediatR.IRequest<Domain.Features.Payroll.Employees.Employee>
//{
//	public GetEmployeeByIdQuery(System.Guid id) : base()
//	{
//		Id = id;
//	}

//	public System.Guid Id { get; init; }
//}
// **************************************************

// **************************************************
namespace Api.Features.Payroll.Employees.Queries;

public record GetEmployeeByIdQuery(System.Guid Id) : object,
	MediatR.IRequest<Domain.Features.Payroll.Employees.Employee>;
// **************************************************
