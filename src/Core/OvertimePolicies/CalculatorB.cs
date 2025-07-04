namespace OverTimePolicies;

public class CalculatorB : ICalculator
{
	public CalculatorB() : base()
	{
	}

	public decimal Calculate
		(decimal basicSalary, decimal allowance)
	{
		var result =
			basicSalary * allowance * (decimal)0.2;

		return result;
	}
}
