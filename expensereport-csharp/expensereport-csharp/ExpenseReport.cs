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
            if (expense.Type is ExpenseType.Dinner or ExpenseType.Breakfast)
            {
                mealExpenses += expense.Amount;
            }

            Console.WriteLine(GetExpenseName(expense.Type) + "\t" + expense.Amount + "\t" +
                              GetMealOverExpensesMarker(expense));

            total += expense.Amount;
        }

        Console.WriteLine("Meal expenses: " + mealExpenses);
        Console.WriteLine("Total expenses: " + total);
    }

    private static string GetMealOverExpensesMarker(Expense expense)
    {
        return expense.Type == ExpenseType.Dinner && expense.Amount > 5000 ||
               expense.Type == ExpenseType.Breakfast && expense.Amount > 1000
            ? "X"
            : " ";
    }

    private static string GetExpenseName(ExpenseType expenseType)
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