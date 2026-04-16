using UnityEditor;
using UnityEngine;

namespace App.Editor.Cheats
{
	public partial class CheatsEditorWindow : EditorWindow
	{
		private const int InputFieldWidth = 100;
		private const int ButtonWidth = 80;
		private const int FieldSpace = 10;
		
		private readonly string _prefix = $"[{ButtonConstants.Cheats}]";

		[MenuItem(ButtonConstants.GameTools + "/" + ButtonConstants.Cheats, false, PriorityConstants.Cheats)]
		public static void Open()
		{
			var window = GetWindow<CheatsEditorWindow>(ButtonConstants.Cheats);
			window.minSize = new Vector2(400, 400);
		}

		private void OnGUI()
		{
			CurrencyGroup();
			GUILayout.Space(FieldSpace);
		}

		private void CurrencyGroup()
		{
			GUILayout.Label("Currency", EditorStyles.boldLabel);
			CoinsCheat();
			GemsCheat();
		}
	}
}