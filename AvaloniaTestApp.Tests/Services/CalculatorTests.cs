
using Xunit;                      // this is for xUnit testing framework
using FluentAssertions;           // this is for making assertions readable
using AvaloniaTestApp.Services;   // this way we import the Calculator class



namespace AvaloniaTestApp.Tests.Services
{
    public class CalculatorTests // Testing class must ends with "Tests"
    {
        private readonly Calculator _calculator;
        
        // Constructor - runs before each test creates new Calculator
        public CalculatorTests()
        {            
            _calculator = new Calculator();
        }        

        // "[Fact]" this marks this as a test method
        // naming convesion: <method_being tested> <scenario> <expected results>
        [Fact]          
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Patern AAA: Arrange (Test Setup) -> Act (Execute) -> Assert (Verify)
            
            // Arrange - Setup test data
            int a = 5;
            int b = 3;
            
            // Act - Execute the method we're testing
            int result = _calculator.Add(a, b);
            
            // Assert - Verify the result
            result.Should().Be(8);
        }

        [Fact]
        public void Add_TwoNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = -5;
            int b = -3;
            
            // Act
            int result = _calculator.Add(a, b);
            
            // Assert
            result.Should().Be(-8);
        }
        
        [Fact]
        public void Add_PositiveNegative_ReturnsCorrectSum()
        {
            // Arrange
            int a = 10;
            int b = -3;
            
            // Act
            int result = _calculator.Add(a, b);
            
            // Assert
            result.Should().Be(7);
        }
        
        // ===== SUBTRACT TESTS =====
        
        [Fact]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            int a = 10;
            int b = 3;
            
            // Act
            int result = _calculator.Subtract(a, b);
            
            // Assert
            result.Should().Be(7);
        }
        
        [Fact]
        public void Subtract_ResultIsNegative_ReturnsNegativeNumber()
        {
            // Arrange
            int a = 3;
            int b = 10;
            
            // Act
            int result = _calculator.Subtract(a, b);
            
            // Assert
            result.Should().Be(-7);
        }
        [Fact]
        public void Subtract_ZeroNums_ReturnsZero()
        {
            // Arrange
            int a = 0;
            int b = 0;
            
            // Act
            int result = _calculator.Subtract(a, b);
            
            // Assert
            result.Should().Be(0);
        }
        
        // ===== MULTIPLY TESTS =====
        
        [Fact]
        public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            // Arrange
            int a = 5;
            int b = 4;
            
            // Act
            int result = _calculator.Multiply(a, b);
            
            // Assert
            result.Should().Be(20);
        }
        
        [Fact]
        public void Multiply_ByZero_ReturnsZero()
        {
            // Arrange
            int a = 5;
            int b = 0;
            
            // Act
            int result = _calculator.Multiply(a, b);
            
            // Assert
            result.Should().Be(0);
        }
        
        [Fact]
        public void Multiply_NegativeNumber_ReturnsNegativeProduct()
        {
            // Arrange
            int a = 5;
            int b = -3;
            
            // Act
            int result = _calculator.Multiply(a, b);
            
            // Assert
            result.Should().Be(-15);
        }

        [Fact]
        public void Multiply_TwoNegativeNumbers_ReturnsPosProduct()
        {
            // Arrange
            int a = -5;
            int b = -3;
            
            // Act
            int result = _calculator.Multiply(a, b);
            
            // Assert
            result.Should().Be(15);
        }

        // ===== DIVIDE TESTS =====
        
        [Fact]
        public void Divide_ValidNumbers_ReturnsCorrectQuotient()
        {
            // Arrange
            int a = 10;
            int b = 2;
            
            // Act
            double result = _calculator.Divide(a, b);
            
            // Assert
            result.Should().Be(5.0);
        }

         [Fact]
        public void Divide_ZeroByValidNumber_ReturnsZero()
        {
            // Arrange
            int a = 0;
            int b = 2;
            
            // Act
            double result = _calculator.Divide(a, b);
            
            // Assert
            result.Should().Be(0);
        }
        
        [Fact]
        public void Divide_WithRemainder_ReturnsDecimal()
        {
            // Arrange
            int a = 10;
            int b = 3;
            
            // Act
            double result = _calculator.Divide(a, b);
            
            // Assert
            result.Should().BeApproximately(3.333, 0.001);  // Check within 0.001
        }
        
        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            // Arrange
            int a = 10;
            int b = 0;
            
            // Act
            Action act = () => _calculator.Divide(a, b);
            
            // Assert
            act.Should().Throw<DivideByZeroException>().WithMessage("You cannot divide by zero");
        }

        [Theory]
        [InlineData(2, 3, 5)]      // 2 + 3 = 5
        [InlineData(10, 5, 15)]    // 10 + 5 = 15
        [InlineData(-5, 5, 0)]     // -5 + 5 = 0
        [InlineData(0, 0, 0)]      // 0 + 0 = 0
        [InlineData(-2, -3, -5)]   // -2 + -3 = -5
        public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Add(a, b);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}