using System.Data;
using MyProject;


namespace MyApp.Tests;

[TestClass]
public class UnitTest1
{
    //ちゃんとしたメアドの場合、Trueを返すか検証するテスト
    [TestMethod]
    public void TestValidEmail()
    {
        // Arrange
        string email = "example@example.com";

        // Act
        bool result = Program.IsEmailValid(email);

        // Assert
        Assert.IsTrue(result);
    }

    // 不適切なメアドの場合、Falseを返すか検証するテスト
    [TestMethod]
    public void TestInvalidEmail()
    {
        // Arrange
        string email = "example@example";

        // Act
        bool result = Program.IsEmailValid(email);

        // Assert
        Assert.IsFalse(result);
    }

    // メールアドレスの先頭の文字が全角文字の場合、Falseを返すか検証するテスト
    [TestMethod]
    public void TestInvalidEmailWithJapaneseInFirstCharatcter()
    {
        // Arrange
        string email = "あdgfdsg@example.com";

        // Act
        bool result = Program.IsEmailValid(email);

        // Assert
        Assert.IsFalse(result);
    }

    // メールアドレスに全角文字が含まれている場合、Falseを返すか検証するテスト
    [TestMethod]
    public void TestInvalidEmailWithJapanese()
    {
        // Arrange
        string email = "example@あdgfdsg.com";

        // Act
        bool result = Program.IsEmailValid(email);

        // Assert
        Assert.IsFalse(result);
    }
}

[TestClass]
public class EmployeeTest
{
    [TestMethod]
    public void TestToDataTableWithLessThan10Rows()
    {
        // Arrange
        List<string[]> data = new List<string[]>
        {
            new string[] { "1", "John", "Doe" },
            new string[] { "2", "Jane", "Doe" },
            new string[] { "3", "Bob", "Smith" }
        };

        // Act
        System.Data.DataTable dataTable = Employee.ToDataTable(data);

        // Assert
        Assert.AreEqual(dataTable.Rows.Count, 3);
    }

    [TestMethod]
    public void TestToDataTableWith10Rows()
    {
        // Arrange
        List<string[]> data = new List<string[]>
        {
            new string[] { "1", "John", "Doe" },
            new string[] { "2", "Jane", "Doe" },
            new string[] { "3", "Bob", "Smith" },
            new string[] { "4", "Alice", "Johnson" },
            new string[] { "5", "Tom", "Brown" },
            new string[] { "6", "Sara", "Lee" },
            new string[] { "7", "David", "Taylor" },
            new string[] { "8", "Emily", "Davis" },
            new string[] { "9", "Michael", "Wilson" },
            new string[] { "10", "Jessica", "Clark" }
        };

        // Act
        DataTable dataTable = Employee.ToDataTable(data);

        // Assert
        Assert.AreEqual(dataTable.Rows.Count, 10);
    }

    [TestMethod]
    public void TestToDataTableWithMoreThan10Rows()
    {
        // Arrange
        List<string[]> data = new List<string[]>
        {
            new string[] { "1", "John", "Doe" },
            new string[] { "2", "Jane", "Doe" },
            new string[] { "3", "Bob", "Smith" },
            new string[] { "4", "Alice", "Johnson" },
            new string[] { "5", "Tom", "Brown" },
            new string[] { "6", "Sara", "Lee" },
            new string[] { "7", "David", "Taylor" },
            new string[] { "8", "Emily", "Davis" },
            new string[] { "9", "Michael", "Wilson" },
            new string[] { "10", "Jessica", "Clark" },
            new string[] { "11", "Mark", "Johnson" }
        };

        // Act and Assert
        Assert.ThrowsException<Exception>(() => Employee.ToDataTable(data));
    }
}