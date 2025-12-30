using System;
using System.Collections.Generic;
using System.IO;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingExpenseDinnerShouldReturnDinnerExpense()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                // Act
                var expenseReport = new ExpenseReport();
                expenseReport.PrintReport(new List<Expense>
                {
                    new Expense {amount = 100, type = ExpenseType.DINNER},
                    // new Expense {amount = 200, type = ExpenseType.BREAKFAST},
                    // new Expense {amount = 300, type = ExpenseType.CAR_RENTAL}
                });
                
                // Assert
                var output = sw.ToString();
                Assert.Equals("",  output);
            };
        }
    }
}