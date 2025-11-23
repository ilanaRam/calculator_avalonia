


using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaTestApp.Services;

namespace AvaloniaTestApp.ViewModels
{
    public partial class CalculatorViewModel : ObservableObject
    {
        private readonly Calculator _calculator;        
        
        // Properties using CommunityToolkit - these will auto-generate public properties
        [ObservableProperty]
        private string _firstNumberText = "";
        [ObservableProperty]
        private string _secondNumberText = "";
        [ObservableProperty]
        private string _result = "";
        [ObservableProperty]
        private string _errorMessage = "";
        
        public CalculatorViewModel()
        {
            _calculator = new Calculator();
        }

        // Helper: Clear messages
        private void ClearMessages()
        {
            Result = "";
            ErrorMessage = "";
        }
        
        //=========================================//
        // ============ PROPERTIES ================//
        //=========================================//
        
        // Method: Perform Addition - must use Dispecher
        // Button → Binds to → AddCommand → Executes → PerformAddition()
        [RelayCommand]
        public void PerformAddition()
        {            
            Console.WriteLine("=== PerformAddition called ===");
            ClearMessages();
            
            Console.WriteLine($"FirstNumberText: '{FirstNumberText}'");
            Console.WriteLine($"SecondNumberText: '{SecondNumberText}'");

            if (!int.TryParse(FirstNumberText, out var first))
            {
                Console.WriteLine("First number parse failed");
                ErrorMessage = "Please enter a valid integer in First Number";
                return;
            }
            if (!int.TryParse(SecondNumberText, out var second))
            {
                Console.WriteLine("Second number parse failed");
                ErrorMessage = "Please enter a valid integer in Second Number";
                return;
            }

            try
            {
                Console.WriteLine($"Calling Add({first}, {second})");
                var sum = _calculator.Add(first, second);
                Result = $"{sum}";
                Console.WriteLine($"Result: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                ErrorMessage = $"Error: {ex.Message}";
            }
            Console.WriteLine("=== PerformAddition completed ===");           
        }
        
        // Method: Perform Subtraction
        [RelayCommand]
        public void PerformSubtraction()
        {
            Console.WriteLine("=== PerformSubtraction called ===");
            ClearMessages();

            if (!int.TryParse(FirstNumberText, out var first))
            {
                ErrorMessage = "Please enter a valid integer in First Number";
                return;
            }
            if (!int.TryParse(SecondNumberText, out var second))
            {
                ErrorMessage = "Please enter a valid integer in Second Number";
                return;
            }

            try
            {
                var difference = _calculator.Subtract(first, second);
                Result = $"{difference}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }
        
        // Method: Perform Multiplication
        [RelayCommand]
        public void PerformMultiplication()
        {
            Console.WriteLine("=== PerformMultiplication called ===");
            ClearMessages();

            if (!int.TryParse(FirstNumberText, out var first))
            {
                ErrorMessage = "Please enter a valid integer in First Number";
                return;
            }
            if (!int.TryParse(SecondNumberText, out var second))
            {
                ErrorMessage = "Please enter a valid integer in Second Number";
                return;
            }

            try
            {
                var product = _calculator.Multiply(first, second);
                Result = $"{product}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }
        
        // Method: Perform Division
        [RelayCommand]
        public void PerformDivision()
        {
            Console.WriteLine("=== PerformDivision called ===");
            ClearMessages();
            
            if (!int.TryParse(FirstNumberText, out var first))
            {
                ErrorMessage = "Please enter a valid integer in First Number";
                return;
            }
            if (!int.TryParse(SecondNumberText, out var second))
            {
                ErrorMessage = "Please enter a valid integer in Second Number";
                return;
            }            
            try
            {
                var quotient = _calculator.Divide(first, second);
                if (quotient == 0) quotient = 0;
                Result = $"{quotient:F2}";
            }
            catch (DivideByZeroException ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }
    }
}
