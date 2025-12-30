using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp;

public class ExpenseReport
{
    public static void PrintReport(List<Expense> expenses)
    {
        Console.WriteLine("Expenses " + DateTime.Now);

        foreach (var expense in expenses)
        {
            Console.WriteLine(GetExpenseName(expense.Type) + "\t" + expense.Amount + "\t" +
                              GetMealOverExpensesMarker(expense));
        }

        Console.WriteLine("Meal expenses: " + GetMealsExpenses(expenses));
        Console.WriteLine("Total expenses: " + GetTotalExpenses(expenses));
    }

    private static int GetTotalExpenses(List<Expense> expenses) =>
        expenses.Sum(expense => expense.Amount);

    private static int GetMealsExpenses(List<Expense> expenses) =>
        expenses
            .Where(expense => expense.Type is ExpenseType.Dinner or ExpenseType.Breakfast)
            .Sum(expense => expense.Amount);

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