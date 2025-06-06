using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.RewardResource.Factory;
using SpaceSimulation.UI.General.Loading;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.EntryPoint
{
	public class GamePlayEntryPoint:MonoBehaviour
	{
		private ILoadingPanel _loadingPanel;
		private IGameLoopControl _gameLoopControl;
		private IRewardResourceFactory _rewardResourceFactory;
		[Inject]
		private void Construct
		(
			ILoadingPanel _loadingPanel ,
			IGameLoopControl _gameLoopControl,
			IRewardResourceFactory _rewardResourceFactory
		)
		{
			this._loadingPanel = _loadingPanel;
			this._gameLoopControl = _gameLoopControl;
			this._rewardResourceFactory = _rewardResourceFactory;
		}
		private void Start()
		{
			_rewardResourceFactory.Init();
			_gameLoopControl.Start();
			_loadingPanel.Hide();
		}
	}
}



