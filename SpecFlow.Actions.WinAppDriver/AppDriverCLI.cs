using SpecFlow.Actions.Appium.Configuration.WindowsAppDriver;
using SpecFlow.Actions.WindowsAppDriver;
using System.Diagnostics;

namespace SpecFlow.Actions.WinAppDriver
{
    public class AppDriverCli : IAppDriverCli
    {
        private readonly IWindowsAppDriverConfiguration _windowsAppDriverConfiguration;

        private Process? _appDriverProcess;

        public AppDriverCli(IWindowsAppDriverConfiguration windowsAppDriverConfiguration)
        {
            _windowsAppDriverConfiguration = windowsAppDriverConfiguration;
        }

        // Starts the WindowsAppDriver.exe process
        public void Start()
        {
            var path = _windowsAppDriverConfiguration.WindowsAppDriverPath ??
                           Environment.GetEnvironmentVariable("WINDOWS_APP_DRIVER_EXECUTABLE_PATH") ?? null;

            if (path != null)
            {
                _appDriverProcess = Process.Start(path);
            }
        }

        // Disposes the WindowsAppDriver.exe process
        public void Dispose()
        {
            _appDriverProcess?.Kill();
        }
    }
}
