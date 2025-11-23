using System.Threading.Tasks;
using Avalonia.Threading;
using Xunit;                         // For [AvaloniaFact] and Assert
using Avalonia.Interactivity;        // Defines RoutedEventArgs
using Avalonia.Controls;             // Defines ButtonBase
using Avalonia.Headless.XUnit;       // For the special test attribute
using AvaloniaTestApp.Views;
using AvaloniaTestApp.ViewModels;
using FluentAssertions;         // To access your MainWindow class


namespace AvaloniaTestApp.Tests.Views
{
    public class MainWindowTests
    {
        // THis special attribute: [AvaloniaFact] instead of [Fact] because tests for GUI will not actually move frames, click on button, 
        // fill in the text boxes but will access the UI elements equivalents that are in memory 
        // tests will run in virtualized Avalonia environment for this [Fact] need to be replaced with [AvaloniaFact]
        [AvaloniaFact]
        public async Task AddButton_Click_CalculatesCorrectResult()
        {
            // 1. Arrange: Instantiate the actual UI window (the View)
            var window = new MainWindow();
            
            // IMPORTANT: set DataContext so bindings and commands are connected
            window.DataContext = new CalculatorViewModel();
             // Show in headless environment (initializes template/bindings)
            window.Show(); 

            // locate controls by name (works even if fields are not public)
            // with "!" to check if control (UI element) not null (it is null if was not found) we will get clear error message
            // it is "fail immediately" and it is good for tests because: it is imidiate stop and test exit with failur
            var firstBox  = window.FindControl<TextBox>("FirstNumberBox")!;
            var secondBox = window.FindControl<TextBox>("SecondNumberBox")!;
            var addBtn    = window.FindControl<Button>("AddButton")!;
            var resultLbl = window.FindControl<TextBlock>("ResultText")!;

            // // Assert controls exist
            // Assert.NotNull(firstBox);
            // Assert.NotNull(secondBox);
            // Assert.NotNull(addBtn);
            // Assert.NotNull(resultLbl);

            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                firstBox.Text  = "20";
                secondBox.Text = "5";
                addBtn.Command?.Execute(null);
            });
            
            await Task.Delay(50); // allow binding to propagate
            resultLbl.Text.Should().Be("25");
            // Assert.Equal("25", resultLbl.Text);
        }       
    }
}