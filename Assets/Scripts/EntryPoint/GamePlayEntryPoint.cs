using System.Collections;

using SpaceSimulation.Core.Drone.Control;
using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.GamePrefs;
using SpaceSimulation.Core.RewardResource.Control;
using SpaceSimulation.Core.RewardResource.Factory;
using SpaceSimulation.UI.General.Loading;
using SpaceSimulation.UI.LevelMenu.HUD;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.EntryPoint
{
	public class GamePlayEntryPoint:MonoBehaviour
	{
		private ILoadingPanel _loadingPanel;
		private IGameLoopService _gameLoopControl;
		private IRewardResourceFactory _rewardResourceFactory;
		private IGamePrefsService _gamePrefsService;
		private IRewardResourceControl _rewardResourceControl;
		private IDroneControl _droneControl;
		private LevelMenuHudFactory _levelMenuHudFactory;
		[Inject]
		private void Construct
		(
			ILoadingPanel _loadingPanel ,
			IGameLoopService _gameLoopControl ,
			IRewardResourceFactory _rewardResourceFactory ,
			IGamePrefsService _gamePrefsService ,
			IRewardResourceControl _rewardResourceControl ,
			IDroneControl _droneControl ,
			LevelMenuHudFactory _levelMenuHudFactory
		)
		{
			this._loadingPanel = _loadingPanel;
			this._gameLoopControl = _gameLoopControl;
			this._rewardResourceFactory = _rewardResourceFactory;
			this._gamePrefsService = _gamePrefsService;
			this._rewardResourceControl = _rewardResourceControl;
			this._droneControl = _droneControl;
			this._levelMenuHudFactory = _levelMenuHudFactory;
		}
		private void Start()
		{
			StartCoroutine(delay());
			IEnumerator delay()
			{
				_rewardResourceFactory.Init();
				_rewardResourceControl.Init();
				_droneControl.Init();

				yield return new WaitForSeconds(0.1f);
				_levelMenuHudFactory.Init();

				yield return new WaitForSeconds(0.1f);
				_gameLoopControl.StartGame();
				_loadingPanel.Hide();
				
			}


		}
	}
}



