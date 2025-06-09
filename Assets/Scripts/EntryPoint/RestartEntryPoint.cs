using SpaceSimulation.SceneControl;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.EntryPoint
{
	public class RestartEntryPoint:MonoBehaviour
	{
		private ISceneControlService _sceneControlService;
		[Inject]
		private void Construct
		(
			ISceneControlService _sceneControlService
		)
		{
			this._sceneControlService = _sceneControlService;
		}

		private void Start()
		{
			_sceneControlService.LoadGamePlay();
		}
	}
}



