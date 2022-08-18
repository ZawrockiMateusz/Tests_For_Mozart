using SpecFlow.Actions.WindowsAppDriver;
using TechTalk.SpecFlow;

namespace SpecFlow.Actions.WinAppDriver
{
    public interface IScreenshotHelper
    {
        void TakeScreenshot(AppDriver appDriver, FeatureContext featureContext, ScenarioContext scenarioContext);
    }
}
