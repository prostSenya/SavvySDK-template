using App.Scripts.Interfaces.Windows;
using Savvy.Editor;
using UnityEditor;

namespace App.Editor.Tools
{
    public static class ExampleTools
    {
        [MenuItem(ButtonConstants.GameTools + "/" + ButtonConstants.ExampleTools, false, PriorityConstants.ExampleTools)]
        private static void OpenErrorWindow()
        {
            if (!BaseEditor.IsRunning())
                return;

            if (BaseEditor.GetService<IWindowsFactory>() is { } windowsFactory) 
                windowsFactory.CreateError(description: "Error Description 404");
        }
    }
}