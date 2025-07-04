namespace Api.Features.Payroll.Employees.Queries;

public class GetEmployeeByIdHandler : object,
	MediatR.IRequestHandler<GetEmployeeByIdQuery, Domain.Features.Payroll.Employees.Employee>
{
	public GetEmployeeByIdHandler(Domain.Features.Payroll.Employees
		.IEmployeeQueryRepository employeeQueryRepository) : base()
	{
		EmployeeQueryRepository = employeeQueryRepository;
	}

	protected Domain.Features.Payroll.Employees.IEmployeeQueryRepository EmployeeQueryRepository { get; init; }

	public async System.Threading.Tasks.Task
		<Domain.Features.Payroll.Employees.Employee> Handle(GetEmployeeByIdQuery request,
		System.Threading.CancellationToken cancellationToken = default)
	{
		var result =
			await
			EmployeeQueryRepository.GetByIdAsync(id: request.Id);

		return result;
	}
}
