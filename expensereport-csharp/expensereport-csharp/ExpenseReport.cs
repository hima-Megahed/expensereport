using System;
using System.Collections.Generic;

namespace expensereport_csharp;

public class ExpenseReport
{
    public void PrintReport(List<Expense> expenses)
    {
        int total = 0;
        int mealExpenses = 0;

        Console.WriteLine("Expenses " + DateTime.Now);

        foreach (Expense expense in expenses)
        {
            if (expense.Type == ExpenseType.Dinner || expense.Type == ExpenseType.Breakfast)
            {
                mealExpenses += expense.Amount;
            }

            String expenseName = "";
            switch (expense.Type)
            {
                case ExpenseType.Dinner:
                    expenseName = "Dinner";
                    break;
                case ExpenseType.Breakfast:
                    expenseName = "Breakfast";
                    break;
                case ExpenseType.CarRental:
                    expenseName = "Car Rental";
                    break;
            }

            String mealOverExpensesMarker =
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
}