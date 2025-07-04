// **************************************************
//using System.Linq;
//using Microsoft.EntityFrameworkCore;

//namespace Api.Controllers.Features.Payroll.Employees;

//[Route
//	(template: "api/features/payroll/[controller]")]
//public class EmployeesController : Infrastructure.ControllerBaseWithDatabaseContext
//{
//	#region Constructor
//	public EmployeesController(Persistence.DatabaseContext
//		databaseContext) : base(databaseContext: databaseContext)
//	{
//	}
//	#endregion /Constructor

//	#region Action: GetEmployeeAsync()
//	[HttpGet]

//	[Consumes
//		(contentType: MediaTypeNames.Application.Json)]

//	[Produces
//		(contentType: MediaTypeNames.Application.Json)]

//	[ProducesResponseType
//		(type: typeof(System.Collections.Generic.IEnumerable
//		<Domain.Features.Payroll.Employees.Employee>),
//		statusCode: StatusCodes.Status200OK)]

//	[ProducesResponseType
//		(statusCode: StatusCodes.Status500InternalServerError)]

//	public async System.Threading.Tasks.Task
//		<IActionResult> GetEmployeesAsync()
//	{
//		var result =
//			await
//			DatabaseContext.Employees
//			.OrderBy(current => current.FirstName)
//			.ThenBy(current => current.LastName)
//			.ToListAsync()
//			;

//		return Ok(value: result);
//	}
//	#endregion /Action: GetEmployeeAsync()
//}
// **************************************************

// **************************************************
//namespace Api.Controllers.Features.Payroll;

//[Route
//	(template: "api/features/payroll/[controller]")]
//public class EmployeesController : Infrastructure.ControllerBase
//{
//	#region Constructor
//	public EmployeesController(MediatR.IMediator mediator) : base()
//	{
//		Mediator = mediator;
//	}
//	#endregion /Constructor

//	protected MediatR.IMediator Mediator { get; init; }

//	#region Action: GetEmployeeAsync()
//	[HttpGet]

//	[Consumes
//		(contentType: MediaTypeNames.Application.Json)]

//	[Produces
//		(contentType: MediaTypeNames.Application.Json)]

//	[ProducesResponseType
//		(type: typeof(System.Collections.Generic.IEnumerable
//		<Domain.Features.Payroll.Employees.Employee>),
//		statusCode: StatusCodes.Status200OK)]

//	[ProducesResponseType
//		(statusCode: StatusCodes.Status500InternalServerError)]

//	public async System.Threading.Tasks.Task
//		<IActionResult> GetEmployeesAsync()
//	{
//		var request = new Api.Features
//			.Payroll.Employees.Queries.GetEmployeesQuery();

//		var result =
//			await
//			Mediator.Send(request: request);

//		return Ok(value: result);
//	}
//	#endregion /Action: GetEmployeeAsync()

//	#region Action: GetEmployeeByIdAsync()
//	[HttpGet(template: "{id}")]

//	[Consumes
//		(contentType: MediaTypeNames.Application.Json)]

//	[Produces
//		(contentType: MediaTypeNames.Application.Json)]

//	[ProducesResponseType
//		(type: typeof(Domain.Features.Payroll.Employees.Employee),
//		statusCode: StatusCodes.Status200OK)]

//	[ProducesResponseType
//		(statusCode: StatusCodes.Status500InternalServerError)]

//	public async System.Threading.Tasks.Task
//		<IActionResult> GetEmployeeByIdAsync(System.Guid id)
//	{
//		var request = new Api.Features
//			.Payroll.Employees.Queries.GetEmployeeByIdQuery(Id: id);

//		var result =
//			await
//			Mediator.Send(request: request);

//		return Ok(value: result);
//	}
//	#endregion /Action: GetEmployeeByIdAsync()
//}
// **************************************************

// **************************************************

using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using Domain.Features.Payroll.Employees;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Api.Features.Payroll.Employees.Queries;
using Api.Features.Payroll.Employees.Commands;
using Dtos.Features.Payroll.Employees;

namespace Api.Controllers.Features.Payroll;

[Route(template: "api/features/payroll/[controller]")]
public class EmployeesController :
    Infrastructure.ControllerBaseWithDatabaseContext
{
    #region Constructor

    public EmployeesController
    (Persistence.DatabaseContext databaseContext, MediatR.IMediator mediator,
        OverTimePolicies.ICalculator calculator) : base(databaseContext: databaseContext)
    {
        Mediator = mediator;
        Calculator = calculator;
    }

    #endregion /Constructor

    #region Properties

    protected MediatR.IMediator Mediator { get; init; }
    protected OverTimePolicies.ICalculator Calculator { get; init; }

    #endregion /Properties

    #region Action: GetEmployeeAsync()

    [HttpGet]
    [Consumes(contentType: MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(IEnumerable<Employee>), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetEmployeesAsync()
    {
        var request = new
            GetEmployeesQuery();
        var result =
            await
                Mediator.Send(request: request);
        return Ok(value: result);
    }

    #endregion /Action: GetEmployeeAsync()

    #region Action: GetEmployeeByIdAsync()

    [HttpGet(template: "{id}")]
    [Consumes(contentType: MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(Employee), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetEmployeeByIdAsync(System.Guid id)
    {
        var request = new
            GetEmployeeByIdQuery(Id: id);
        var result =
            await
                Mediator.Send(request: request);

        return Ok(value: result);
    }

    #endregion /Action: GetEmployeeByIdAsync()

    #region Action: CreateEmployeeAsync()

    [HttpPost]
    [Consumes(contentType: MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(type: typeof(Employee), statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(statusCode: StatusCodes.Status415UnsupportedMediaType)]

    //public async System.Threading.Tasks.Task
    //	<IActionResult>
    //	CreateEmployeesAsync(Dtos.Features.Payroll.Employees.CreateDto employeeDto)
    //{
    //	var employee =
    //		new Domain.Features.Payroll.Employees.Employee
    //		(firstName: employeeDto.FirstName, lastName: employeeDto.LastName)
    //		{
    //			Date = System.DateTime.Now,
    //			Allowance = employeeDto.Allowance,
    //			BasicSalary = employeeDto.BasicSalary,
    //			Transportation = employeeDto.Transportation,
    //		};

    //	employee.CalculateSalary(calculator: Calculator);

    //	await DatabaseContext.AddAsync(entity: employee);

    //	await DatabaseContext
    //		.SaveChangesAsync();

    //	return CreatedAtAction
    //		(actionName: "GetEmployeeById",
    //		routeValues: new { id = employee.Id }, value: employee);
    //}

    // Create with CQRS!
    public async Task<IActionResult> CreateEmployeesAsync
        (CreateEmployeeRequestDto dto)
    {
        var request = new CreateEmployeeCommand
        (LastName: dto.LastName, FirstName: dto.FirstName,
            Allowance: dto.Allowance, BasicSalary: dto.BasicSalary,
            Transportation: dto.Transportation, Date: dto.Date);

        var result =
            await
                Mediator.Send(request: request);

        return CreatedAtAction
        (actionName: "GetEmployeeById",
            routeValues: new { id = result.Id }, value: result);
    }

    #endregion /Action: CreateEmployeeAsync()

    #region Action: UpdateEmployeesAsync()

    [HttpPut(template: "{id}")]
    [Consumes(contentType: MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType(statusCode: StatusCodes.Status405MethodNotAllowed)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(statusCode: StatusCodes.Status415UnsupportedMediaType)]

    // Update without CQRS!
    public async Task
        <IActionResult> UpdateEmployeesAsync
        (System.Guid id, UpdateDto employeeDto)
    {
        var foundedEmployee =
            await
                DatabaseContext.Employees
                    .Where(current => current.Id == id)
                    .FirstOrDefaultAsync();

        if (foundedEmployee == null)
        {
            return NotFound();
        }

        foundedEmployee.Date = System.DateTime.Now;

        foundedEmployee.LastName = employeeDto.LastName;
        foundedEmployee.FirstName = employeeDto.FirstName;
        foundedEmployee.Allowance = employeeDto.Allowance;
        foundedEmployee.BasicSalary = employeeDto.BasicSalary;
        foundedEmployee.Transportation = employeeDto.Transportation;

        foundedEmployee.CalculateSalary(calculator: Calculator);

        await DatabaseContext
            .SaveChangesAsync();

        return NoContent();
    }

    //----------------------------------------------------------------------
    // Update with CQRS!
    public async Task
        <IActionResult> UpdateEmployeesAsync
        (UpdateEmployeeRequestDto dto)
    {
        var request = new
            UpdateEmployeeCommand
            (Id: dto.Id,
                LastName: dto.LastName, FirstName: dto.FirstName,
                Allowance: dto.Allowance, BasicSalary: dto.BasicSalary,
                Transportation: dto.Transportation, Date: dto.Date);

        var result =
            await
                Mediator.Send(request: request);

        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion /Action: CreateEmployeeAsync()

    #region Action: DeleteEmployeesAsync

    [HttpDelete(template: "{id}")]
    [Consumes
        (contentType: MediaTypeNames.Application.Json)]
    [Produces
        (contentType: MediaTypeNames.Application.Json)]
    [ProducesResponseType
        (statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType
        (statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType
        (statusCode: StatusCodes.Status400BadRequest)]
    [ProducesResponseType
        (statusCode: StatusCodes.Status405MethodNotAllowed)]
    [ProducesResponseType
        (statusCode: StatusCodes.Status500InternalServerError)]

    //public async System.Threading.Tasks.Task
    //	<IActionResult> DeleteEmployeesAsync(System.Guid id)
    //{
    //	var foundedEmployees =
    //		await
    //		DatabaseContext.Employees
    //		.Where(current => current.Id == id)
    //		.FirstOrDefaultAsync();

    //	if (foundedEmployees == null)
    //	{
    //		return NotFound();
    //	}

    //	DatabaseContext.Remove(entity: foundedEmployees);

    //	await DatabaseContext
    //		.SaveChangesAsync();

    //	return NoContent();
    //}

    // Delete with CQRS!
    public async Task
        <IActionResult> DeleteEmployeesAsync(System.Guid id)
    {
        var request = new DeleteEmployeeCommand(Id: id);

        var result =
            await
                Mediator.Send(request: request);

        if (result == false)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion /Action: DeleteCustomerAsync
}
// **************************************************