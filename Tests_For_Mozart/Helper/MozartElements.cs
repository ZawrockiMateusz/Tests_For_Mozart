using OpenQA.Selenium.Appium.Windows;
using SpecFlow.Actions.WindowsAppDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_For_Mozart.Helper
{
    public class MozartElements
    {
        protected readonly AppDriver _appDriver;

        public MozartElements(AppDriver appDriver)
        {
            _appDriver = appDriver;
        }
        public WindowsElement listaBaz =>
            _appDriver.Current.FindElementByAccessibilityId("listaBaz");
        public WindowsElement okButton =>
            _appDriver.Current.FindElementByName("Ok");
        public WindowsElement formularzLogowania =>
            _appDriver.Current.FindElementByName("Formularz logowania");
        public WindowsElement listaOperatorow =>
            _appDriver.Current.FindElementByClassName("WindowsForms10");
        public WindowsElement licencjaProgramu =>
            _appDriver.Current.FindElementByAccessibilityId("MyLicenc");
        public WindowsElement mainForm =>
            _appDriver.Current.FindElementByAccessibilityId("MainForm");
    }
}
