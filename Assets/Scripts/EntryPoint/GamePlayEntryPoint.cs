using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.UI.General.Loading;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.EntryPoint
{
	public class GamePlayEntryPoint:MonoBehaviour
	{
		private ILoadingPanel _loadingPanel;
		private IGameLoopControl _gameLoopControl;
		[Inject]
		private void Construct
		(
			ILoadingPanel _loadingPanel ,
			IGameLoopControl _gameLoopControl
		)
		{
			this._loadingPanel = _loadingPanel;
			this._gameLoopControl = _gameLoopControl;
		}
		private void Start()
		{

			_gameLoopControl.Start();
			_loadingPanel.Hide();
		}
	}
}



