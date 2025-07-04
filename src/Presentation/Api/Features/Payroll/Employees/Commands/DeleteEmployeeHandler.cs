using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Payroll.Employees.Commands;

public class DeleteEmployeeHandler : object,
	MediatR.IRequestHandler<DeleteEmployeeCommand, bool>
{
	public DeleteEmployeeHandler
		(Persistence.DatabaseContext databaseContext) : base()
	{
		DatabaseContext = databaseContext;
	}

	protected Persistence.DatabaseContext DatabaseContext { get; init; }

	public async System.Threading.Tasks.Task
		<bool> Handle(DeleteEmployeeCommand request,
		System.Threading.CancellationToken cancellationToken = default)
	{
		var foundedEmployee =
			await
			DatabaseContext.Employees
			.Where(current => current.Id == request.Id)
			.FirstOrDefaultAsync();

		if (foundedEmployee is null)
		{
			return false;
		}

		DatabaseContext.Remove(entity: foundedEmployee);

		await DatabaseContext.SaveChangesAsync();

		return true;
	}
}
