using System;
using App.Scripts.Interfaces.Currency;
using Savvy.Editor;
using Savvy.Logger;
using UnityEditor;
using UnityEngine;

namespace App.Editor.Cheats
{
	public partial class CheatsEditorWindow
	{
		private int _gemsAmount;

		private void GemsCheat()
		{
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Gems:");
			_gemsAmount = EditorGUILayout.IntField(_gemsAmount, GUILayout.Width(InputFieldWidth));

			if (GUILayout.Button("Add", GUILayout.Width(ButtonWidth)))
				AddGems(_gemsAmount);
			
			if (GUILayout.Button("Set", GUILayout.Width(ButtonWidth)))
				SetGems(_gemsAmount);

			EditorGUILayout.EndHorizontal();
		}

		private void AddGems(int amount)
		{
			if (!BaseEditor.IsRunning())
				return;

			if (BaseEditor.GetService<ICurrencyService>() is { } currencyService)
			{
				amount = Math.Clamp(amount, 0, int.MaxValue);
				SavvyLogger.Log($"{_prefix} Add Gems: '{amount}'");
				currencyService.AddGems(amount);
			}
		}

		private void SetGems(int amount)
		{
			if (!BaseEditor.IsRunning())
				return;

			if (BaseEditor.GetService<ICurrencyService>() is { } currencyService)
			{
				amount = Math.Clamp(amount, 0, int.MaxValue);
				SavvyLogger.Log($"{_prefix} Set Coins: '{amount}'");
				currencyService.SpendGems(currencyService.Gems, null);
				currencyService.AddGems(amount);
			}
		}
	}
}