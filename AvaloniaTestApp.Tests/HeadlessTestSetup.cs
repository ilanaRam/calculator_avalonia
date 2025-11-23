using Avalonia;
using Avalonia.Headless.XUnit;
using AvaloniaTestApp;
using Avalonia.Headless;

// This file contains special BuildAvaloniaApp() method
// This file contains the special BuildAvaloniaApp() method. 
// When you run dotnet test, the xUnit runner sees this setup file and knows, 
// "Before I run any test, I need to configure the Avalonia framework to use the Headless platform," 
// essentially loading the virtual graphics engine


public class HeadlessTestSetup
{
    // 2. This method is called by the test runner to configure Avalonia
    public static AppBuilder BuildAvaloniaApp() => 
        // 3. Configure the main application class (from your main project)
        AppBuilder.Configure<AvaloniaTestApp.App>() 
           // 4. Activate the headless platform, essential for CI/CD
          .UseHeadless(new AvaloniaHeadlessPlatformOptions()); 
}