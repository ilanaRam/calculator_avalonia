using Avalonia;
using Avalonia.Headless.XUnit;
using AvaloniaTestApp;
using Avalonia.Headless;

// 1. This attribute links the entire test assembly to our custom setup


public class HeadlessTestSetup
{
    // 2. This method is called by the test runner to configure Avalonia
    public static AppBuilder BuildAvaloniaApp() => 
        // 3. Configure the main application class (from your main project)
        AppBuilder.Configure<AvaloniaTestApp.App>() 
           // 4. Activate the headless platform, essential for CI/CD
          .UseHeadless(new AvaloniaHeadlessPlatformOptions()); 
}