using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = Microsoft.AspNetCore
	.Builder.WebApplication.CreateBuilder(args: args);

builder.Services
	.AddControllers();

builder.Services
	.AddEndpointsApiExplorer();

builder.Services
	.AddSwaggerGen();

builder.Services.AddDbContext<Persistence.DatabaseContext>
	(options => options.UseSqlServer(connectionString:
	builder.Configuration.GetConnectionString(name: nameof(Persistence.DatabaseContext))));

builder.Services.AddScoped
	<OverTimePolicies.ICalculator, OverTimePolicies.CalculatorA>();

builder.Services.AddScoped
	<Domain.Features.Payroll.Employees.IEmployeeQueryRepository,
	Persistence.Features.Payroll.Employees.EmployeeQueryRepository>();

builder.Services.AddMediatR(config =>
	config.RegisterServicesFromAssembly(assembly: typeof(Program).Assembly));

var app =
	builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
