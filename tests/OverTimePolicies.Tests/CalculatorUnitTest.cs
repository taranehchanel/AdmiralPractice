namespace OverTimePolicies.Tests;

public class CalculatorUnitTest
{
	[Fact]
	public void Test1()
	{
		// Arrange
		var calculator =
			new OverTimePolicies.CalculatorA();

		// Act
		var result =
			calculator.Calculate
			(basicSalary: 10, allowance: 20);

		// Assert
		Assert.Equal(expected: 20, actual: result);
	}

	[Fact]
	public void Test2()
	{
		// Arrange
		var calculator =
			new OverTimePolicies.CalculatorB();

		// Act
		var result =
			calculator.Calculate
			(basicSalary: 10, allowance: 20);

		// Assert
		Assert.Equal(expected: 40, actual: result);
	}

	[Fact]
	public void Test3()
	{
		// Arrange
		var calculator =
			new OverTimePolicies.CalculatorC();

		// Act
		var result =
			calculator.Calculate
			(basicSalary: 10, allowance: 20);

		// Assert
		Assert.Equal(expected: 60, actual: result);
	}
}
