using App.Scripts.Constants;
using UnityEngine;

namespace App.Scripts.Interfaces.TestServices
{
	[CreateAssetMenu(menuName = PathConstants.ServicesDir + "/" + nameof(TestSettings), fileName = nameof(TestSettings))]
	public class TestSettings : ScriptableObject
	{
		[Header("Logging")]
		[SerializeField] private bool _debug;
        
		public bool Debug => _debug;
	}
}