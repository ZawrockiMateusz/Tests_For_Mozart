using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpecFlow.Actions.Configuration;
using SpecFlow.Actions.WindowsAppDriver.Configuration;
using System.Collections.Generic;

namespace SpecFlow.Actions.WinAppDriver.Tests
{
    public class WindowsAppDriverConfigurationTests
    {
        private static WindowsAppDriverConfiguration GetAppDriverConfiguration(string specflowJsonContent)
        {
            var specflowActionJsonLoader = new Mock<ISpecFlowActionJsonLoader>();
            specflowActionJsonLoader.Setup(m => m.Load()).Returns(specflowJsonContent);

            return new WindowsAppDriverConfiguration(specflowActionJsonLoader.Object);
        }
        [TestMethod]
        public void Capabilities_IsEmpty_If_Json_IsEmpty()
        {
            var specflowJsonContent = string.Empty;

            var appDriverConfiguration = GetAppDriverConfiguration(specflowJsonContent);

            appDriverConfiguration.Capabilities.Should().BeEmpty();
        }
        [TestMethod]
        public void Capabilities_IsEmpty_If_ValuesNotProvided()
        {
            var specflowJsonContent = "{\"windowsAppDriver\": {\"capabilities\": {}}}";

            var appDriverConfiguration = GetAppDriverConfiguration(specflowJsonContent);

            appDriverConfiguration.Capabilities.Should().BeEmpty();
        }
        [TestMethod]
        public void WindowsAppDriverPath_IsNull_If_Json_IsEmpty()
        {
            var specflowJsonContent = string.Empty;

            var appDriverConfiguration = GetAppDriverConfiguration(specflowJsonContent);

            appDriverConfiguration.WindowsAppDriverPath.Should().BeNull();
        }
        [TestMethod]
        public void EnableScreenshots_IsNull_If_Json_IsEmpty()
        {
            var specflowJsonContent = string.Empty;

            var appDriverConfiguration = GetAppDriverConfiguration(specflowJsonContent);

            appDriverConfiguration.EnableScreenshots.Should().BeNull();
        }
        [TestMethod]
        public void LoadSpecFlowJson_Ignores_Casing()
        {
            var specflowJsonContent = "{\"WINDOWSAPPDRIVER\": {\"CAPABILITIES\": {\"APP\": \"path\"}}}";
            var expected = new KeyValuePair<string, string>("APP", "path");

            var appDriverConfiguration = GetAppDriverConfiguration(specflowJsonContent);

            appDriverConfiguration.Capabilities!.Should().Contain(expected);
        }
        [TestMethod]
        public void Capabilities_ContainsAdditionalCapabilities_If_ValuesSpecified()
        {
            var specflowJsonContent = "{\"windowsAppDriver\": {\"capabilities\": {\"app\": \"path\", \"appArguments\": \"-env local\"}}}";

            var expectedApp = new KeyValuePair<string, string>("app", "path");
            var expectedAppArguments = new KeyValuePair<string, string>("appArguments", "-env local");

            var appDriverConfiguration = GetAppDriverConfiguration(specflowJsonContent);

            appDriverConfiguration.Capabilities.Should().Contain(expectedApp, expectedAppArguments);
        }
    }
}
