namespace Persistence.Extensions;

using Domain.Features.Payroll.Employees;
using Microsoft.EntityFrameworkCore;

internal static class ModelBuilderExtensions
{
    #region Static Constructor

    static ModelBuilderExtensions()
    {
    }

    #endregion /Static Constructor

    #region Methods

    #region Seed()

    public static void Seed(this ModelBuilder modelBuilder)
    {
        // **************************************************
        // *** Employees ************************************
        // **************************************************

        for (int index = 1; index <= 9; index++)
        {
            var lastName = $"Last Name {index}";
            var firstName = $"First Name {index}";

            var employees =
                new
                    Employee(firstName: firstName, lastName: lastName)
                    {
                        Allowance = index * 3,
                        BasicSalary = index * 10,
                        Transportation = index * 2,
                        Date = System.DateTime.Now,
                    };

            modelBuilder.Entity<Employee>().HasData(data: employees);
        }
        // **************************************************
        // *** /Employees ***********************************
        // **************************************************
    }

    #endregion /Seed()

    #endregion /Methods
}