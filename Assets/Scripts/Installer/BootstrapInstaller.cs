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
	}
}
