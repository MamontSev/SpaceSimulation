using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;
using SpaceSimulation.UI.LevelMenu.HUD.LevelHud;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.UI.LevelMenu.HUD
{
	public class LevelMenuHudFactory:MonoBehaviour 
	{
		private DiContainer _diContainer;
		[Inject]
		private void Construct
		(
			DiContainer _diContainer,
			IEventBusService _eventBusService
		)
		{
			this._diContainer = _diContainer;
		}

		public void Init( )
		{
			InitHud();
		}



		[SerializeField]
		private LevelMenuHudView _hudMenu;

		private void InitHud()
		{
			LevelMenuHudViewModel vm = _diContainer.Instantiate<LevelMenuHudViewModel>();
			_hudMenu.Bind(vm);
		}
	}
}
