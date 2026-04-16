using App.Scripts.Interfaces.TestServices;
using App.Scripts.Services.Windows.Buttons;
using UnityEngine;

namespace App.Scripts.Services.Windows.Error
{
	public class TestUIWindow : WindowBase
	{
		[Header("Buttons")]
		[SerializeField] private ActionButton _okBtn;

		private ITestService _testService;

		protected override void OnAwake()
		{
			base.OnAwake();
			Debug("TestUIWindow Awake");
			_testService = GetService<ITestService>();
		}
		
		private void Start()
		{
			Debug("TestUIWindow Start");
			_okBtn.Construct(_testService.TestMethod);
		}
	}
}