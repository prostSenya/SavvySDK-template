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
		private int _coinsAmount;

		private void CoinsCheat()
		{
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Coins:");
			_coinsAmount = EditorGUILayout.IntField(_coinsAmount, GUILayout.Width(InputFieldWidth));

			if (GUILayout.Button("Add", GUILayout.Width(ButtonWidth)))
				AddCoins(_coinsAmount);
			
			if (GUILayout.Button("Set", GUILayout.Width(ButtonWidth)))
				SetCoins(_coinsAmount);

			EditorGUILayout.EndHorizontal();
		}

		private void AddCoins(int amount)
		{
			if (!BaseEditor.IsRunning())
				return;

			if (BaseEditor.GetService<ICurrencyService>() is { } currencyService)
			{
				amount = Math.Clamp(amount, 0, int.MaxValue);
				SavvyLogger.Log($"{_prefix} Add Coins: '{amount}'");
				currencyService.AddCoins(amount);
			}
		}

		private void SetCoins(int amount)
		{
			if (!BaseEditor.IsRunning())
				return;

			if (BaseEditor.GetService<ICurrencyService>() is { } currencyService)
			{
				amount = Math.Clamp(amount, 0, int.MaxValue);
				SavvyLogger.Log($"{_prefix} Set Coins: '{amount}'");
				currencyService.SpendCoins(currencyService.Coins, null);
				currencyService.AddCoins(amount);
			}
		}
	}
}