using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Tests_For_Mozart.Helper;

namespace Tests_For_Mozart.StepDefinitions
{
    [Binding]
    public sealed class SkladnikiStepDefinitions
    {
        private readonly MozartApp _mozartApp;
        public SkladnikiStepDefinitions(MozartApp mozartApp)
        {
            _mozartApp = mozartApp;
        }
        [Given(@"choose database '([^']*)'")]
        public void GivenChooseDatabase(string database)
        {
            _mozartApp.ChooseDataBase(database);
            _mozartApp.ClickOkButton();
            _mozartApp.SwitchFocus();
        }

        [Given(@"log in as '([^']*)' with '([^']*)' password")]
        public void GivenLogIn(string login, string password)
        {
            _mozartApp.SetTheOperatorsLoginAndPassword(login, password);
            _mozartApp.SwitchFocus();
        }

        [Given(@"accept product licence")]
        public void GivenAcceptProductLicence()
        {
            _mozartApp.AcceptTheLicence();
            _mozartApp.SwitchFocus();
        }

        [Given(@"open '([^']*)'")]
        public void GivenOpen(string window)
        {
            _mozartApp.OpenWindow(window);
        }

        [Given(@"select a product with '([^']*)' code")]
        public void GivenSelectAProductWithCode(string code)
        {
            _mozartApp.SelectAProductCode(code);
        }

        [Given(@"change product type to '([^']*)'")]
        public void GivenChangeProductTypeTo(string type)
        {
            _mozartApp.ChangeProductType(type);
            _mozartApp.SwitchFocus();
        }

        [Given(@"set monitoring points to '([^']*)'")]
        public void GivenSetMonitoringPointsTo(string mp)
        {
            _mozartApp.SetMP(mp);
        }

        [Then(@"I should see values '([^']*)' as Type and '([^']*)' as Monitoring Point")]
        public void ThenIShouldSeeChangedValues(string type, string mp)
        {
            _mozartApp.EnsureValuesIsChanged(type, mp);
        }
    }
}
