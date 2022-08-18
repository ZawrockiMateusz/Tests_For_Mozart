using OpenQA.Selenium.Appium.Windows;
using SpecFlow.Actions.Appium.Configuration.WindowsAppDriver;
using SpecFlow.Actions.Appium.Driver;

namespace SpecFlow.Actions.WinAppDriver
{
    public class AppDriver : IDisposable
    {
        private readonly IWindowsAppDriverConfiguration _windowsAppDriverConfiguration;
        private readonly IDriverFactory _driverFactory;
        private readonly IDriverOptions _driverOptions;

        private readonly Uri _driverUri = new("http://127.0.0.1:4723/");

        protected readonly Lazy<WindowsDriver<WindowsElement>> _lazyDriver;
        private bool _isDisposed;

        public AppDriver(IWindowsAppDriverConfiguration windowsAppDriverConfiguration, IDriverFactory driverFactory, IDriverOptions driverOptions)
        {
            _windowsAppDriverConfiguration = windowsAppDriverConfiguration;
            _driverFactory = driverFactory;
            _driverOptions = driverOptions;
            _lazyDriver = new Lazy<WindowsDriver<WindowsElement>>(CreateAppDriver);
        }

        //The current AppDriver instance
        public WindowsDriver<WindowsElement> Current => _lazyDriver.Value;

        // Creates the AppDriver instance
        private WindowsDriver<WindowsElement> CreateAppDriver()
        {
            return _driverFactory.GetWindowsAppDriver(_windowsAppDriverConfiguration, _driverOptions, _driverUri);
        }

        // Disposes the current AppDriver instance
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_lazyDriver.IsValueCreated)
            {
                Current.CloseApp();
            }

            _isDisposed = true;
        }
    }
}