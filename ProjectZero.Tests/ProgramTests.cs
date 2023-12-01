using NSubstitute;
using NUnit.Framework;
using ProjectZero;

namespace ProjectZeroTests;

[TestFixture]
public class ProgramTests
{
    [Test]
    public void ParseCommandLineArguments_ShouldSetOptionsCorrectly()
    {
        // Arrange
        var args = new[] { "-v", "-w", "John" };
        var expectedOptions = new Options { Verbose = true, Who = "John" };

        // Act
        var result = Program.ParseCommandLineArguments(args);
        
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(expectedOptions.Verbose, Is.EqualTo(result.Verbose));
            Assert.That(expectedOptions.Who, Is.EqualTo(result.Who));
        });
    }

    [Test]
    public void Main_ShouldPrintGreeting()
    {
        // Arrange
        var args = new[] { "-v", "-w", "John" };
        var greetingService = Substitute.For<GreetingService>();
        
        // Act
        Program.Main(args);
        
        // Assert
        Assert.That(greetingService.GenerateGreeting(true, "John"), Is.EqualTo("Hello John!"));
    }
    
    [Test]
    public void Main_ShouldBrieflyPrintGreeting()
    {
        // Arrange
        var args = new[] { "-w", "John" };
        var greetingService = Substitute.For<GreetingService>();
        
        // Act
        Program.Main(args);
        
        // Assert
        Assert.That(greetingService.GenerateGreeting(false, "John"), Is.EqualTo("Hi John."));
    }
}