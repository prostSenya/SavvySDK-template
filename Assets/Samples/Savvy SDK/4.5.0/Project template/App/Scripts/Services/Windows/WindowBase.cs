using App.Scripts.Interfaces.Windows;

namespace App.Scripts.Services.Windows
{
    public abstract class WindowBase : WindowPrefab
    {
        protected IWindowsFactory _windowsFactory;

        private void Awake()
        {
            _windowsFactory = GetService<IWindowsFactory>();
            OnAwake();
        }

        protected void Close()
        {
            OnClose();
            Destroy(gameObject);
        }

        protected virtual void OnAwake() { }
        protected virtual void OnClose() { }
    }
}