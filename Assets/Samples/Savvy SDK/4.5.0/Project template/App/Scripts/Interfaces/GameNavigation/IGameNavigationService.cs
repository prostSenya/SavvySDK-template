using Savvy.Interfaces;

namespace App.Scripts.Interfaces.GameNavigation
{
    public interface IGameNavigationService : IService
    {
        void ToLoad();
        void ToMenu();
        void ToGame();
    }
}