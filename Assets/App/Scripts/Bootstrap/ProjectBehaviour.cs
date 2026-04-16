using App.Scripts.Interfaces.Analytics;
using App.Scripts.Interfaces.Currency;
using App.Scripts.Interfaces.GameNavigation;
using App.Scripts.Interfaces.GameStateMachine;
using App.Scripts.Interfaces.SaveLoad;
using App.Scripts.Interfaces.StaticData;
using App.Scripts.Interfaces.Statistics;
using App.Scripts.Interfaces.TestServices;
using App.Scripts.Interfaces.UI;
using App.Scripts.Interfaces.Vibration;
using App.Scripts.Interfaces.Windows;
using App.Scripts.Services.Analytics;
using App.Scripts.Services.Currency;
using App.Scripts.Services.GameNavigation;
using App.Scripts.Services.GameStateMachine;
using App.Scripts.Services.StaticData;
using App.Scripts.Services.Statistics;
using App.Scripts.Services.UI;
using App.Scripts.Services.Vibration;
using App.Scripts.Services.Windows;
using Samples.Savvy_SDK._4._5._0.Project_template.App.Scripts.Services.TestServices;
using Savvy.Bootstrap;
using Savvy.Interfaces;

namespace App.Scripts.Bootstrap
{
    public class ProjectBehaviour : ProjectBehaviourBase
    {
        protected override void OnProjectBehaviourInitialized()
        {
            var gameNavigationService = GetService<IGameNavigationService>();
            gameNavigationService.ToLoad();
        }

        protected override void RegisterSaveLoadService() =>
            RegisterSaveLoadService<ProgressData>();

        protected override void RegisterProjectServices()
        {
            RegisterService<IStaticDataService>(new StaticDataService());
            RegisterService<IGameNavigationService>(new GameNavigationService());
            RegisterService<IAnalyticsService>(new AnalyticsService());
            RegisterService<IStatisticsService>(new StatisticsService());
            RegisterService<IUIService>(new UIService());
            RegisterService<IWindowsFactory>(new WindowsFactory());
            RegisterService<ICurrencyService>(new CurrencyService());
            RegisterService<ITestService>(new TestService());
            RegisterService<ICustomVibrationAdapter>(new AndroidVibrationAdapter());
            RegisterService<ICustomVibrationService>(new CustomVibrationService());
        }

        protected override void RegisterStates(IGameStateMachine gameStateMachine)
        {
            gameStateMachine.AddState(StateType.Load, new LoadState());
            gameStateMachine.AddState(StateType.Menu, new MenuState());
            gameStateMachine.AddState(StateType.Game, new GameState());
        }
    }
}