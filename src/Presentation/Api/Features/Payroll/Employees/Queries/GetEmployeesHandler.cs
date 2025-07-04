// **************************************************
//using Microsoft.EntityFrameworkCore;

//namespace Api.Features.Payroll.Employees.Queries;

//public class GetEmployeesHandler : object, MediatR.IRequestHandler<GetEmployeesQuery,
//	System.Collections.Generic.IEnumerable<Domain.Features.Payroll.Employees.Employee>>
//{
//	public GetEmployeesHandler
//		(Persistence.DatabaseContext databaseContext) : base()
//	{
//		DatabaseContext = databaseContext;
//	}

//	protected Persistence.DatabaseContext DatabaseContext { get; init; }

//	public async System.Threading.Tasks.Task
//		<System.Collections.Generic.IEnumerable
//		<Domain.Features.Payroll.Employees.Employee>> Handle(GetEmployeesQuery request,
//		System.Threading.CancellationToken cancellationToken = default)
//	{
//		var result =
//			await
//			DatabaseContext.Employees
//			.ToListAsync()
//			;

//		return result;
//	}
//}
// **************************************************

// **************************************************
namespace Api.Features.Payroll.Employees.Queries;

public class GetEmployeesHandler : object, MediatR.IRequestHandler<GetEmployeesQuery,
	System.Collections.Generic.IEnumerable<Domain.Features.Payroll.Employees.Employee>>
{
	public GetEmployeesHandler(Domain.Features.Payroll.Employees
		.IEmployeeQueryRepository employeeQueryRepository) : base()
	{
		EmployeeQueryRepository = employeeQueryRepository;
	}

	protected Domain.Features.Payroll.Employees.IEmployeeQueryRepository EmployeeQueryRepository { get; init; }

	public async System.Threading.Tasks.Task
		<System.Collections.Generic.IEnumerable
		<Domain.Features.Payroll.Employees.Employee>> Handle(GetEmployeesQuery request,
		System.Threading.CancellationToken cancellationToken = default)
	{
		var result =
			await
			EmployeeQueryRepository.GetAllAsync();

		return result;
	}
}
// **************************************************
