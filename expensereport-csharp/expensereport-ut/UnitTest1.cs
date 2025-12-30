using System;
using System.IO;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddingExpenseShouldAppearInReport()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        var expenseReport = new ExpenseReport();
        expenseReport.PrintReport([
            new Expense { amount = 100, type = ExpenseType.DINNER },
            new Expense { amount = 200, type = ExpenseType.BREAKFAST },
            new Expense { amount = 300, type = ExpenseType.CAR_RENTAL }
        ]);

        // Assert
        var output = sw.ToString();
        Assert.IsTrue(output.Contains("Dinner\t100"));
        Assert.IsTrue(output.Contains("Breakfast\t200"));
        Assert.IsTrue(output.Contains("Car Rental\t300"));
    }

    [Test]
    public void DinnerExpenseMoreThan5000ShouldReturnXInReport()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        var expenseReport = new ExpenseReport();
        expenseReport.PrintReport([
            new Expense { amount = 6000, type = ExpenseType.DINNER },
            new Expense { amount = 200, type = ExpenseType.BREAKFAST },
            new Expense { amount = 300, type = ExpenseType.CAR_RENTAL }
        ]);

        // Assert
        var output = sw.ToString();
        Assert.IsTrue(output.Contains("Dinner\t6000\tX"));
        Assert.IsTrue(output.Contains("Breakfast\t200"));
        Assert.IsTrue(output.Contains("Car Rental\t300"));
    }

    [Test]
    public void BreakfastExpenseMoreThan1000ShouldReturnXInReport()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        var expenseReport = new ExpenseReport();
        expenseReport.PrintReport([
            new Expense { amount = 6000, type = ExpenseType.DINNER },
            new Expense { amount = 10000, type = ExpenseType.BREAKFAST },
            new Expense { amount = 300, type = ExpenseType.CAR_RENTAL }
        ]);

        // Assert
        var output = sw.ToString();
        Assert.IsTrue(output.Contains("Dinner\t6000\tX"));
        Assert.IsTrue(output.Contains("Breakfast\t10000\tX"));
        Assert.IsTrue(output.Contains("Car Rental\t300"));
    }
}