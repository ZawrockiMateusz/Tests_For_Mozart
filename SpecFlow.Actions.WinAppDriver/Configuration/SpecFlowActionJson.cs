using System.Text.Json.Serialization;


namespace SpecFlow.Actions.WinAppDriver.Configuration
{
    public class SpecFlowActionJson
    {
        [JsonInclude]
        public WindowsAppDriverJsonPart WindowsAppDriver { get; private set; } = new WindowsAppDriverJsonPart();
    }
}
