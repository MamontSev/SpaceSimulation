using SpaceSimulation.Core.CameraControl;
using SpaceSimulation.Core.Drone.Control;
using SpaceSimulation.Core.Drone.Factory;
using SpaceSimulation.Core.Fraction.Control;
using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.GamePrefs;
using SpaceSimulation.Core.RewardResource.Control;
using SpaceSimulation.Core.RewardResource.Factory;
using SpaceSimulation.Core.Score;
using SpaceSimulation.Core.Spawn;
using SpaceSimulation.UI.LevelMenu.HUD;

using Zenject;

namespace SpaceSimulation.Installer
{
	public class GamePlayInstaller:MonoInstaller
	{
		public override void InstallBindings()
		{
			BindLevelScoreControl();
			BindGameLoopService();
			BindLevelMenuHudFactory();
			BindRewardResourceFactory();
			BindRewardResourceControl();
			BindSpawnPointFinder();
			BindFractionBaseControl();
			BindMoveGamePlayCamera();
			BindToCameraRotation();
			BindGamePrefsService();
			BindDroneFactory();
			BindDroneControl();
		}


		private void BindLevelScoreControl()
		{
			Container
			.Bind<IScoreControl>()
			.To<ScoreControl>()
			.AsSingle()
			.NonLazy();

		}
		private void BindGameLoopService()
		{
			Container
			.BindInterfacesAndSelfTo<GameLoopService>()
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
			.BindInterfacesAndSelfTo<RewardResourceControl>()
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
			.BindInterfacesAndSelfTo<MoveGamePlayCamera>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}
		private void BindToCameraRotation()
		{
			Container
			.Bind<ToCameraRotation>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}



		private void BindGamePrefsService()
		{
			Container
			.BindInterfacesAndSelfTo<GamePrefsService>()
			.AsSingle()
			.NonLazy();
		}

		private void BindDroneFactory()
		{
			Container
			.Bind<IDroneFactory>()
			.To<DroneFactory>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

		private void BindDroneControl()
		{
			Container
			.BindInterfacesAndSelfTo<DroneControl>()
			.AsSingle()
			.NonLazy();


		}









	}
}
