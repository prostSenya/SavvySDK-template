using App.Scripts.Constants;
using App.Scripts.Interfaces.TestServices;
using Savvy.Container;

namespace Samples.Savvy_SDK._4._5._0.Project_template.App.Scripts.Services.TestServices
{
	public class TestService : NetSavvyResources, ITestService
	{
		private readonly string _settingsPath = $"{PathConstants.ServicesDir}/{nameof(TestSettings)}";
		private TestSettings _testSettings;

		public TestService()
		{
			Debug("Constructed TestService");
			_testSettings = LoadResources<TestSettings>(_settingsPath);
		}
		
		public void TestMethod()
		{
			Debug("TestMethod");
		}

		public void Inject()
		{
			Debug("Injected TestService");
		}

		public void Init()
		{
			Debug("Initialized TestService");
		}
	}
}