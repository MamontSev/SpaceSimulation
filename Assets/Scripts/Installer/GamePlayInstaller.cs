using SpaceSimulation.Core.CameraControl;
using SpaceSimulation.Core.Fraction.Control;
using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.RewardResource.Control;
using SpaceSimulation.Core.RewardResource.Factory;
using SpaceSimulation.Core.Score;
using SpaceSimulation.Core.Spawn;
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
			BindRewardResourceFactory();
			BindRewardResourceControl();
			BindSpawnPointFinder();
			BindFractionBaseControl();
			BindMoveGamePlayCamera();
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

		private void BindRewardResourceFactory()
		{
			Container
			.Bind<IRewardResourceFactory>()
			.To<RewardResourceFactory>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

		private void BindRewardResourceControl()
		{
			Container
			.Bind<IRewardResourceControl>()
			.To<RewardResourceControl>()
			.AsSingle()
			.NonLazy();
		}

		private void BindSpawnPointFinder()
		{
			Container
			.Bind<ISpawnPointFinder>()
			.To<SpawnPointFinder>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}


		private void BindFractionBaseControl()
		{
			Container
			.Bind<IFractionBaseControl>()
			.To<FractionBaseControl>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

		private void BindMoveGamePlayCamera()
		{
			Container
			.Bind<MoveGamePlayCamera>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

		



	}
}
