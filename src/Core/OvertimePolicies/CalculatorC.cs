namespace OverTimePolicies;

public class CalculatorC : ICalculator
{
	public CalculatorC() : base()
	{
	}

	public decimal Calculate
		(decimal basicSalary, decimal allowance)
	{
		var result =
			basicSalary * allowance * (decimal)0.3;

		return result;
	}
}
