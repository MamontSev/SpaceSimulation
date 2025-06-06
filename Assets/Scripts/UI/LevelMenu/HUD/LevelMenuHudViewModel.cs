using SpaceSimulation.Core.Score;
using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;
using SpaceSimulation.UI.LevelMenu.PopUp;
using SpaceSimulation.UI.MVVM;

using Manmont.Tools;

namespace SpaceSimulation.UI.LevelMenu.HUD
{
	public class LevelMenuHudViewModel:IViewModel
	{
		private readonly ILevelMenuPopUpFacrtory _levelMenuPopUpFacrtory;
		private readonly IEventBusService _eventBusService;
		private readonly IScoreControl _levelScoreControl;
		public LevelMenuHudViewModel
		(
			ILevelMenuPopUpFacrtory _levelMenuPopUpFacrtory,
			IEventBusService _eventBusService,
			IScoreControl _levelScoreControl
		)
		{
			this._levelMenuPopUpFacrtory = _levelMenuPopUpFacrtory;
			this._eventBusService = _eventBusService;
			this._levelScoreControl = _levelScoreControl;
			SubscribeEvents();
		}

		private bool _isSubscribe = false;
		private void SubscribeEvents()
		{
			if( _isSubscribe == true )
			{
				return;
			}
			_isSubscribe = true;
			_eventBusService.Subscribe<LevelScoreChangedSignal>(OnLevelScoreChangedSignal);
			_eventBusService.Subscribe<ExitGamePlayState>(OnExitGamePlayState);
		}
		private void UnSubscribeEvents()
		{
			if( _isSubscribe == false )
			{
				return;
			}
			_isSubscribe = false;

			_eventBusService.Unsubscribe<LevelScoreChangedSignal>(OnLevelScoreChangedSignal);
			_eventBusService.Unsubscribe<ExitGamePlayState>(OnExitGamePlayState);
		}

		private void OnExitGamePlayState( ExitGamePlayState signal )
		{
			UnSubscribeEvents();
		}

		private void OnLevelScoreChangedSignal( LevelScoreChangedSignal signal )
		{
			SetScore();
		}

		private ILevelMenuHudView _myView = null;
		public void OnInitView( ILevelMenuHudView myView )
		{
			_myView = myView;
			SetLevelNameText();
			SetScore();
		}

		public void PressedPause() 
		{
			_levelMenuPopUpFacrtory.Show(new LevelPauseMenuViewModel());
		}

		private void SetLevelNameText()
		{
			
		}

		private void SetScore()
		{
		//	_myView.SetScoreText($"Score: {_levelScoreControl.CurrScore.DigitToString()}");
		}
	}
}
