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
            new Expense { Amount = 100, Type = ExpenseType.Dinner },
            new Expense { Amount = 200, Type = ExpenseType.Breakfast },
            new Expense { Amount = 300, Type = ExpenseType.CarRental }
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
            new Expense { Amount = 6000, Type = ExpenseType.Dinner },
            new Expense { Amount = 200, Type = ExpenseType.Breakfast },
            new Expense { Amount = 300, Type = ExpenseType.CarRental }
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
            new Expense { Amount = 6000, Type = ExpenseType.Dinner },
            new Expense { Amount = 10000, Type = ExpenseType.Breakfast },
            new Expense { Amount = 300, Type = ExpenseType.CarRental }
        ]);

        // Assert
        var output = sw.ToString();
        Assert.IsTrue(output.Contains("Dinner\t6000\tX"));
        Assert.IsTrue(output.Contains("Breakfast\t10000\tX"));
        Assert.IsTrue(output.Contains("Car Rental\t300"));
    }
}