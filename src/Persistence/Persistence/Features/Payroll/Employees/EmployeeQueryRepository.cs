using Dapper;
using Microsoft.Extensions.Configuration;
using Domain.Features.Payroll.Employees;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Persistence.Features.Payroll.Employees;

public class EmployeeQueryRepository : object, IEmployeeQueryRepository

{
    public EmployeeQueryRepository(IConfiguration configuration) : base()

    {
        // using Microsoft.Extensions.Configuration;
        ConnectionString =
            configuration.GetConnectionString(name: "DatabaseContext");
    }

    protected string? ConnectionString { get; init; }

    public async Task<IEnumerable<Employee>> GetAllAsync
        (CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(value: ConnectionString))
        {
            throw new System.ArgumentNullException
                (paramName: nameof(ConnectionString));
        }

        using var connection = new Microsoft.Data.SqlClient
            .SqlConnection(connectionString: ConnectionString);

        var query =
            "SELECT * FROM Employees";

        // using Dapper;
        var result =
                await
                    connection.QueryAsync<Employee>(sql: query)
            ;

        return result;
    }

    public async Task<Employee>
        GetByIdAsync(System.Guid id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(value: ConnectionString))
        {
            throw new System.ArgumentNullException
                (paramName: nameof(ConnectionString));
        }

        using var connection = new Microsoft.Data.SqlClient
            .SqlConnection(connectionString: ConnectionString);

        var query =
            "SELECT * FROM Employees WHERE Id = @Id";

        //var parameters =
        //	new { Id = id };

        var parameters = new { id };

        // using Dapper;
        var result =
            await
                connection.QueryFirstOrDefaultAsync<Employee>
                    (sql: query, param: parameters);

        return result;
    }
}