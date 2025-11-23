


using System;
using System.Windows.Input;
using ReactiveUI;
using AvaloniaTestApp.Services;

namespace AvaloniaTestApp.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        private readonly Calculator _calculator;
        
        // Properties that the UI binds to
        private string _firstNumberText = "";
        private string _secondNumberText = "";
        private string _result = "";
        private string _errorMessage = "";
        
        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            
            // Create commands - these connect buttons to methods!
            AddCommand = ReactiveCommand.Create(PerformAddition);
            SubtractCommand = ReactiveCommand.Create(PerformSubtraction);
            MultiplyCommand = ReactiveCommand.Create(PerformMultiplication);
            DivideCommand = ReactiveCommand.Create(PerformDivision);
        }
        
        //=========================================//
        // ============ PROPERTIES ================//
        //=========================================//

        // Property per command - will be called Command Property
        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }
        
        // Property: First Number
        public string FirstNumberText
        {
            get => _firstNumberText;
            set => this.RaiseAndSetIfChanged(ref _firstNumberText, value);
        }
        
        // Property: Second Number
        public string SecondNumberText
        {
            get => _secondNumberText;
            set => this.RaiseAndSetIfChanged(ref _secondNumberText, value);
        }
        
        // Property: Result (displayed to user)
        public string Result
        {
            get => _result;
            private set => this.RaiseAndSetIfChanged(ref _result, value);
        }
        
        // Property: Error Message
        public string ErrorMessage
        {
            get => _errorMessage;
            private set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }
        
        // Method: Perform Addition
        // Button → Binds to → AddCommand → Executes → PerformAddition()
        public void PerformAddition()
        {
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
                var sum = _calculator.Add(first, second);
                Result = $"Result: {sum}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }
        
        // Method: Perform Subtraction
        public void PerformSubtraction()
        {
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
                Result = $"Result: {difference}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }
        
        // Method: Perform Multiplication
        public void PerformMultiplication()
        {
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
                Result = $"Result: {product}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }
        
        // Method: Perform Division
        public void PerformDivision()
        {
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
                Result = $"Result: {quotient:F2}";
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
        
        // Helper: Clear messages
        private void ClearMessages()
        {
            Result = "";
            ErrorMessage = "";
        }
    }
}
