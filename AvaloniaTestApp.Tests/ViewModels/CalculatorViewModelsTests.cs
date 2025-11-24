

using Xunit;
using FluentAssertions;
using AvaloniaTestApp.ViewModels;


// ----------------------------------------------------------------------------------------------
//these are Integration tests as they check the integration between View Model and the Calculator
// ----------------------------------------------------------------------------------------------

namespace AvaloniaTestApp.Tests.ViewModels
{
    public class CalculatorViewModelTests
    {
        // ===== TESTS for "Addition" method
        // Here we call methods as if these methods were called upon click on UI elements =====
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformAddition_TwoPositiveNumbers_UpdatesResultProperty()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "10",
                SecondNumberText = "5"
            };
            
            // Act
            viewModel.PerformAddition();
            
            // Assert
            // here we ask to GET value of the property Result, ErrorMessage
            viewModel.Result.Should().Be("15");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformAddition_NegativeNumbers_UpdatesResultProperty()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "-10",
                SecondNumberText = "-5"
            };
            
            // Act
            viewModel.PerformAddition();
            
            // Assert
            viewModel.Result.Should().Be("-15");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        [Theory]
        [Trait("Category", "Integration")]
        [InlineData("5", "3", "8")]
        [InlineData("100", "50", "150")]
        [InlineData("-5", "10", "5")]
        [InlineData("0", "0", "0")]
        public void PerformAddition_VariousInputs_ProducesCorrectResults(
            string first, string second, string expectedResult)
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = first,
                SecondNumberText = second
            };
            
            // Act
            viewModel.PerformAddition();
            
            // Assert
            viewModel.Result.Should().Be(expectedResult);
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        // // ===== TESTS for "Substruction" method
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformSubtraction_TwoNumbers_UpdatesResultProperty()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "20",
                SecondNumberText = "8"
            };
            
            // Act
            viewModel.PerformSubtraction();
            
            // Assert
            viewModel.Result.Should().Be("12");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformSubtraction_ResultIsNegative_ShowsNegativeResult()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "5",
                SecondNumberText = "15"
            };
            
            // Act
            viewModel.PerformSubtraction();
            
            // Assert
            viewModel.Result.Should().Be("-10");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        // ===== TESTS for "Multiplectional" method
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformMultiplication_TwoNumbers_UpdatesResultProperty()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "6",
                SecondNumberText = "7"
            };
            
            // Act
            viewModel.PerformMultiplication();
            
            // Assert
            viewModel.Result.Should().Be("42");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformMultiplication_ByZero_ReturnsZero()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "100",
                SecondNumberText = "0"
            };
            
            // Act
            viewModel.PerformMultiplication();
            
            // Assert
            viewModel.Result.Should().Be("0");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        // ===== TESTS for "Division" method
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformDivision_ValidNumbers_UpdatesResultProperty()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "20",
                SecondNumberText = "4"
            };
            
            // Act
            viewModel.PerformDivision();
            
            // Assert
            viewModel.Result.Should().Be("5.00");
            viewModel.ErrorMessage.Should().BeEmpty();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void PerformDivision_ZeroIsDevided_UpdatesResultProperty()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "0",
                SecondNumberText = "4"
            };
            
            // Act
            viewModel.PerformDivision();
            
            // Assert
            viewModel.Result.Should().Be("0.00");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformDivision_WithRemainder_ShowsDecimalResult()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "24",
                SecondNumberText = "3"
            };
            
            // Act
            viewModel.PerformDivision();
            
            // Assert
            viewModel.Result.Should().Contain("8.00");
            viewModel.ErrorMessage.Should().BeEmpty();
        }
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformDivision_ByZero_ShowsErrorMessage()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "10",
                SecondNumberText = "0"
            };
            
            // Act
            viewModel.PerformDivision();
            
            // Assert
            viewModel.Result.Should().BeEmpty();
            viewModel.ErrorMessage.Should().NotBeEmpty();
            viewModel.ErrorMessage.Should().Contain("You cannot divide by zero");
        }
        
        // ===== ERROR HANDLING TESTS =====
        
        [Fact]
        [Trait("Category", "Integration")]
        public void PerformAddition_AfterError_ClearsErrorMessage()
        {
            // Arrange
            var viewModel = new CalculatorViewModel
            {
                FirstNumberText = "10",
                SecondNumberText = "0"
            };
            
            // Cause an error first
            viewModel.PerformDivision();
            viewModel.ErrorMessage.Should().NotBeEmpty();
            viewModel.ErrorMessage.Should().Contain("You cannot divide by zero");
            
            // Act - perform valid operation
            viewModel.FirstNumberText = "5";
            viewModel.SecondNumberText = "3";
            viewModel.PerformAddition();
            
            // Assert - error should be cleared
            viewModel.ErrorMessage.Should().BeEmpty();
            viewModel.Result.Should().Be("8");
        }
    }
}