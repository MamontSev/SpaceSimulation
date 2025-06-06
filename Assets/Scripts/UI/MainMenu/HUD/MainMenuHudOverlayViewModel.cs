using SpaceSimulation.GeneralStateMashine;
using SpaceSimulation.UI.MVVM;

namespace SpaceSimulation.UI.MainMenu.HUD
{
	public class MainMenuHudOverlayViewModel:IViewModel
	{
		private readonly GeneralGameStateMachine _stateMachine; 
		public MainMenuHudOverlayViewModel( GeneralGameStateMachine _stateMachine )
		{
			this._stateMachine = _stateMachine;
		}
		private IMainMenuHudOverlayView _view;
		public void OnInitView( IMainMenuHudOverlayView _view )
		{
			this._view = _view;
			this._view.SetHeaderText("Space Simulation Game");
		}

		public void OnStartGamePressed()
		{
			_stateMachine.Enter<GamePlayState>();
		}
	}
}
