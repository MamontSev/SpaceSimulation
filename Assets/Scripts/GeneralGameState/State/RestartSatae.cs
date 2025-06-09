using Manmont.Tools.StateMashine;

using SpaceSimulation.SceneControl;

namespace SpaceSimulation.GeneralStateMashine
{
	public class RestartSatae:IGeneralGameState, IEnterState
	{
		private readonly ISceneControlService _sceneControlService;
		public RestartSatae
		(
			ISceneControlService _sceneControlService 
		)
		{
			this._sceneControlService = _sceneControlService;
		}

		public void Enter()
		{
			_sceneControlService.LoadRestart();
		}
	}

}

