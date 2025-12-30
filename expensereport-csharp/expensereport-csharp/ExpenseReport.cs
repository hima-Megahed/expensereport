using System;
using System.Collections.Generic;

namespace expensereport_csharp;

public class ExpenseReport
{
    public void PrintReport(List<Expense> expenses)
    {
        var total = 0;
        var mealExpenses = 0;

        Console.WriteLine("Expenses " + DateTime.Now);

        foreach (var expense in expenses)
        {
            if (expense.Type == ExpenseType.Dinner || expense.Type == ExpenseType.Breakfast)
            {
                mealExpenses += expense.Amount;
            }

            var expenseName = GetExpenseName(expense.Type);

            var mealOverExpensesMarker =
                expense.Type == ExpenseType.Dinner && expense.Amount > 5000 ||
                expense.Type == ExpenseType.Breakfast && expense.Amount > 1000
                    ? "X"
                    : " ";

            Console.WriteLine(expenseName + "\t" + expense.Amount + "\t" + mealOverExpensesMarker);

            total += expense.Amount;
        }

        Console.WriteLine("Meal expenses: " + mealExpenses);
        Console.WriteLine("Total expenses: " + total);
    }

    private string GetExpenseName(ExpenseType expenseType)
    {
        return expenseType switch
        {
            ExpenseType.Dinner => "Dinner",
            ExpenseType.Breakfast => "Breakfast",
            ExpenseType.CarRental => "Car Rental",
            _ => throw new ArgumentOutOfRangeException(nameof(expenseType), expenseType, null)
        };
    }
}