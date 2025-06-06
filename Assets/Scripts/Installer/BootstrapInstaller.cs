using SpaceSimulation.Data.GamePrefs;
using SpaceSimulation.Data.RewardResource;
using SpaceSimulation.Events;
using SpaceSimulation.GeneralStateMashine;
using SpaceSimulation.Log;
using SpaceSimulation.SceneControl;
using SpaceSimulation.UI.General.Loading;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.Installer
{
	public class BootstrapInstaller:MonoInstaller
	{
		public override void InstallBindings()
		{
			BindLoadingPanel();
			BindSceneControlService();
			BindGeneralGameStateMachine();
			BindBusService();
			BindLogService();
			BindRewardResourceConfig();
			BindGamePrefsConfig();
		}

		[SerializeField]
		private LoadingPanel _loadingPanel;
		private void BindLoadingPanel()
		{
			Container
			.Bind<ILoadingPanel>()
			.To<LoadingPanel>()
			.FromInstance(_loadingPanel)
			.AsSingle()
			.NonLazy();
		}

		[SerializeField]
		private SceneControlService _sceneControlService;
		private void BindSceneControlService()
		{
			Container
			.Bind<ISceneControlService>()
			.To<SceneControlService>()
			.FromInstance(_sceneControlService)
			.AsSingle()
			.NonLazy();
		}

		private void BindGeneralGameStateMachine()
		{
			Container.Bind<GeneralGameStateMachine>().AsSingle().NonLazy();
			Container.Bind<GeneralStateFactory>().AsSingle().NonLazy();
		}

		private void BindBusService()
		{
			Container.Bind<IEventBusService>().To<EventBusService>().AsSingle().NonLazy();
		}

		private void BindLogService()
		{
			Container.Bind<ILogService>().To<LogService>().AsSingle().NonLazy();
		}

		[SerializeField]
		private RewardResourcePreset _rewardResourcePreset;
		private void BindRewardResourceConfig()
		{
			Container
				.Bind<IRewardResourceConfig>()
				.To<RewardResourceConfig>()
				.AsSingle()
				.WithArguments(_rewardResourcePreset)
				.NonLazy();
		}

		[SerializeField]
		private GamePrefsPreset _gamePrefsPreset;
		private void BindGamePrefsConfig()
		{
			Container
				.Bind<IGamePrefsConfig>()
				.To<GamePrefsConfig>()
				.AsSingle()
				.WithArguments(_gamePrefsPreset)
				.NonLazy();
		}
	}
}
