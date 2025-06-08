using System.Collections.Generic;

using Manmont.Tools;

using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.GamePrefs;
using SpaceSimulation.Core.Score;
using SpaceSimulation.Data.GamePrefs;
using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;
using SpaceSimulation.UI.MVVM;

using UnityEngine;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public class LevelMenuHudViewModel:IViewModel
	{
		private readonly IEventBusService _eventBusService;
		private readonly IScoreControl _levelScoreControl;
		private readonly IGamePrefsService _gamePrefsService;
		private readonly IGamePrefsConfig _gamePrefsConfig;
		private readonly IGameLoopService _gameLoopControl;
		public LevelMenuHudViewModel
		(
			IEventBusService _eventBusService ,
			IScoreControl _levelScoreControl ,
			IGamePrefsService _gamePrefsService ,
			IGamePrefsConfig _gamePrefsConfig,
			IGameLoopService _gameLoopControl
		)
		{
			this._eventBusService = _eventBusService;
			this._levelScoreControl = _levelScoreControl;
			this._gamePrefsService = _gamePrefsService;
			this._gamePrefsConfig = _gamePrefsConfig;
			this._gameLoopControl = _gameLoopControl;
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
			SetScore();

			_myView.InitFrequenceText(_gamePrefsService.FrequencyCreateRewardResource);

			_myView.InitNeedViewPath(_gamePrefsService.NeedViewPath);

			_droneCountDict.Add(FractionType.Red , _myView.CountRed);
			_droneCountDict.Add(FractionType.Blue , _myView.CountBlue);
			InitCount();

			_droneSpeedDict.Add(FractionType.Red , _myView.SpeedRed);
			_droneSpeedDict.Add(FractionType.Blue , _myView.SpeedBlue);
			InitSpeed();

			InitSimulationSpeed();
		}

		private Dictionary<FractionType , IHudSlider> _droneCountDict = new();
		private Dictionary<FractionType , IHudSlider> _droneSpeedDict = new();


		private void InitCount()
		{
			foreach( var item in _droneCountDict )
			{
				FractionType fractionType = item.Key;
				IHudSlider hudSlider = item.Value;
				hudSlider.Init
				  (
					_gamePrefsConfig.DroneCount.min ,
					_gamePrefsConfig.DroneCount.max ,
					_gamePrefsService.DroneCount(fractionType) ,
					  value =>
					  {
				
						  int intVal = Mathf.RoundToInt(value);
						  hudSlider.SetValue(intVal);
						  if( _gameLoopControl.IsPlaying )
						  {
							  _eventBusService.Invoke(new DroneCountSignal(fractionType , intVal));
						  }
					  });
			}
		}
		private void InitSpeed()
		{
			foreach( var item in _droneSpeedDict )
			{
				FractionType fractionType = item.Key;
				IHudSlider hudSlider = item.Value;
				hudSlider.Init
				  (
					_gamePrefsConfig.DroneCount.min ,
					_gamePrefsConfig.DroneCount.max ,
					_gamePrefsService.DroneCount(fractionType) ,
					  value =>
					  {
						  hudSlider.SetValue(value);
						  if( _gameLoopControl.IsPlaying )
						  {
							  _eventBusService.Invoke(new DroneSpeedSignal(fractionType , value));
						  }
					  });
			}
		}
		private void InitSimulationSpeed()
		{
		   	_myView.SimulationSpeed.Init
				  (
					0.0f ,
					10.0f ,
					1.0f ,
					  value =>
					  {
						  _myView.SimulationSpeed.SetValue(value);
						  _gameLoopControl.SetSimulationScale(value);
					  });
		}


		public void OnFrequenceChanged( string s )
		{
			bool complete = float.TryParse(s , out float value);
			if( complete )
			{
				_myView.InitFrequenceText(value);
				if( _gameLoopControl.IsPlaying )
				{
					_eventBusService.Invoke(new FrequencyCreateRewardResourceSignal(value));
				}
			}
			else
			{
				_myView.InitFrequenceText(_gamePrefsService.FrequencyCreateRewardResource);
			}
		}

		public void OnNeedViewPathToggleChanged( bool state )
		{
			_myView.InitNeedViewPath(state);
			if( _gameLoopControl.IsPlaying )
			{
				_eventBusService.Invoke(new NeedViewPathChangedSignal(state));
			}
		}

		private void SetScore()
		{
			string red = $"Red Team: {_levelScoreControl.GetAmount(FractionType.Red).DigitToString()}";
			string blue = $"Blue Team: {_levelScoreControl.GetAmount(FractionType.Blue).DigitToString()}";
			_myView.SetScoreText(red , blue);
		}
	}
}
