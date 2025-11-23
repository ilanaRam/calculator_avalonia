using Avalonia.Controls;
using AvaloniaTestApp.ViewModels;

namespace AvaloniaTestApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // this line does: 
            // It connects the View to the ViewModel (connects UI elements located on the View (Main Window)
            // to View Model (Data Context = Functionality right behind the UI elements that calls to Calculator)
            /*
                MainWindow (View)
                ↓
                DataContext = CalculatorViewModel
                ↓
                All {Binding ...} in XAML now bind to CalculatorViewModel properties
            */

            // Set the DataContext to our CalculatorViewModel
            DataContext = new CalculatorViewModel();
        }
    }
}