namespace Domain.Features.Payroll.Employees;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

public interface IEmployeeQueryRepository
{
    //Employee GetById(System.Guid id);
    //System.Collections.Generic.IEnumerable<Employee> GetAll();

    Task<Employee> GetByIdAsync(System.Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
}