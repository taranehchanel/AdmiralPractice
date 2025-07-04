namespace OverTimePolicies;

public class CalculatorA : ICalculator
{
	public CalculatorA() : base()
	{
	}

	public decimal Calculate
		(decimal basicSalary, decimal allowance)
	{
		var result =
			basicSalary * allowance * (decimal)0.1;

		return result;
	}
}
