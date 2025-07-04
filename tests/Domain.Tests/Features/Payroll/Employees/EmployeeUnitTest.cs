namespace Domain.Tests.Features.Payroll.Employees;

public class EmployeeUnitTest : object
{
	[Fact]
	public void Test1()
	{
		// Arrange
		var employee =
			new Domain.Features.Payroll.Employees
			.Employee(firstName: "Taraneh", lastName: "Nesari")
			{
				Allowance = 10,
				BasicSalary = 20,
				Transportation = 30,
				Date = System.DateTime.Now,
			};

		var calculator =
			new OverTimePolicies.CalculatorA();

		// Act
		employee.CalculateSalary(calculator: calculator);

		// Assert
		Assert.Equal(expected: (decimal)79.9, actual: employee.Salary);
	}

	[Fact]
	public void Test2()
	{
		// Arrange
		var employee =
			new Domain.Features.Payroll.Employees
			.Employee(firstName: "Taraneh", lastName: "Nesari")
			{
				Allowance = 10,
				BasicSalary = 20,
				Transportation = 30,
				Date = System.DateTime.Now,
			};

		var calculator =
			new OverTimePolicies.CalculatorB();

		// Act
		employee.CalculateSalary(calculator: calculator);

		// Assert
		Assert.Equal(expected: (decimal)79.9, actual: employee.Salary);
	}

	[Fact]
	public void Test3()
	{
		// Arrange
		var employee =
			new Domain.Features.Payroll.Employees
			.Employee(firstName: "Taraneh", lastName: "Nesari")
			{
				Allowance = 10,
				BasicSalary = 20,
				Transportation = 30,
				Date = System.DateTime.Now,
			};

		var calculator =
			new OverTimePolicies.CalculatorC();

		// Act
		employee.CalculateSalary(calculator: calculator);

		// Assert
		Assert.Equal(expected: (decimal)79.9, actual: employee.Salary);
	}
}
