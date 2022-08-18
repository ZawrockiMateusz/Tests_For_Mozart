using System;

namespace SpecFlow.Actions.WinAppDriver
{
    public interface IAppDriverCli : IDisposable
    {
        void Start();
    }
}
