using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.Score;
using SpaceSimulation.UI.LevelMenu.HUD;
using SpaceSimulation.UI.LevelMenu.PopUp;

using Zenject;

namespace SpaceSimulation.Installer
{
	public class GamePlayInstaller:MonoInstaller
	{
		public override void InstallBindings()
		{
			BindLevelScoreControl();
			BindLevelStateControl();
			BindLevelMenuPopUpFacrtory();
			BindLevelMenuHudFactory();
		}


		private void BindLevelScoreControl()
		{
			Container.Bind<IScoreControl>().To<ScoreControl>().AsSingle().NonLazy();
		}
		
		private void BindLevelStateControl()
		{
			Container.BindInterfacesAndSelfTo<GameLoopControl>().AsSingle().NonLazy();
		}
		

		private void BindLevelMenuPopUpFacrtory()
		{
			Container
			.Bind<ILevelMenuPopUpFacrtory>()
			.To<LevelMenuPopUpFacrtory>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

		private void BindLevelMenuHudFactory()
		{
			Container
			.Bind<LevelMenuHudFactory>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

		

	}
}
