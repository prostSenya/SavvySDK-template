using System;
using Savvy.Interfaces;

namespace App.Scripts.Interfaces.Windows
{
    public interface IWindowsFactory : IService
    {
        void CreateInfo(string description);
        void CreateError(string description);
        void CreateConfirmation(string description, Action confirm, Action cancel, string confirmText, string cancelText);
        void CreateRateUsWindow();
        void CreateRateUsStars();
        void CreateRateUsFeedback();
        void CreateMenu();
        void CreateGame();
    }
}