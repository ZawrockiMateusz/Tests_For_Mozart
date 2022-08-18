using OpenQA.Selenium;
using SpecFlow.Actions.WindowsAppDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_For_Mozart.Helper
{
    public class MozartApp : MozartElements
    {
        AppDriver driver;
        public MozartApp(AppDriver appDriver) : base(appDriver)
        {
            driver = appDriver;
        }
        public void ChooseDataBase(string database)
        {
            listaBaz.FindElementByName(database).Click();
        }
        public void ClickOkButton()
        {
            okButton.Click();
        }
        public void SwitchFocus()
        {
            Thread.Sleep(3000);
            var allWindowHandles = driver.Current.WindowHandles;
            driver.Current.SwitchTo().Window(allWindowHandles.First());
        }
        public void SetTheOperatorsLoginAndPassword(string login, string password)
        {
            formularzLogowania.FindElementByName("Otwórz").Click();
            formularzLogowania.FindElementByName("Nazwa filter row").SendKeys(login);
            formularzLogowania.FindElementByName("Nazwa filter row").SendKeys(Keys.ArrowDown);
            formularzLogowania.FindElementByName("Nazwa row0").SendKeys(Keys.Enter);
            Thread.Sleep(500);

            formularzLogowania.FindElementByAccessibilityId("textEditPassword").SendKeys(password);

            formularzLogowania.FindElementByName("Zaloguj").Click();
        }
        public void AcceptTheLicence()
        { 
            licencjaProgramu.FindElementByAccessibilityId("cmdOk").Click();
        }
        public void OpenWindow(string window)
        {
            mainForm.FindElementByName(window).Click();
        }
        public void SelectAProductCode(string code)
        {
            mainForm.FindElementByName("Kod filter row").SendKeys(code);
            mainForm.FindElementByName("Kod row0").Click();
            mainForm.FindElementByAccessibilityId("cmdEdit").Click();
            Thread.Sleep(500);

            Assert.AreEqual(code, mainForm.FindElementByAccessibilityId("textEditSymbol").Text);
        }
        public void ChangeProductType(string type)
        {
            mainForm.FindElementByName(type).Click();
            Thread.Sleep(500);
            mainForm.FindElementByName("Nie").Click();
        }
        public void SetMP(string mp)
        {            
            while(mainForm.FindElementByAccessibilityId("lookUpWydzial").Text != mp)
            {
                mainForm.FindElementByAccessibilityId("lookUpWydzial").SendKeys(Keys.ArrowDown);
            }

            mainForm.FindElementByAccessibilityId("textStawka").SendKeys(Keys.ArrowUp);
            mainForm.FindElementByAccessibilityId("btnZapisz").Click();
        }
        public void EnsureValuesIsChanged(string type, string mp)
        {
            Assert.AreEqual(type, mainForm.FindElementByName("Typ row0").Text);
            Assert.AreEqual(mp, mainForm.FindElementByName("Wydział row0").Text);
        }
    }
}
