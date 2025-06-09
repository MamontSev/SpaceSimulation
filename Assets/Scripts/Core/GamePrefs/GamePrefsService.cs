using System;
using System.Collections.Generic;

using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Data.GamePrefs;
using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;

using UnityEngine;

namespace SpaceSimulation.Core.GamePrefs
{
	public class GamePrefsService:IGamePrefsService, IDisposable
	{
		private readonly IGamePrefsConfig _gamePrefsConfig;
		private readonly IEventBusService _eventBusService;
		private readonly IGameLoopService _gameLoopControl;
		public GamePrefsService
		(
			 IGamePrefsConfig _gamePrefsConfig ,
			 IEventBusService _eventBusService ,
			 IGameLoopService _gameLoopControl
		)
		{
			this._gamePrefsConfig = _gamePrefsConfig;
			this._eventBusService = _eventBusService;
			this._gameLoopControl = _gameLoopControl;
			Subscribe();
			Init();
		}

		private void Init()
		{
			foreach( FractionType fractionType in Enum.GetValues(typeof(FractionType)) )
			{
				_droneSpeedDict.Add(fractionType , UnityEngine.Random.Range(_gamePrefsConfig.DroneSpeed.min , _gamePrefsConfig.DroneSpeed.max));
			}
			int droneCount = UnityEngine.Random.Range(_gamePrefsConfig.DroneCount.min , _gamePrefsConfig.DroneCount.max + 1) * 2;
			if( droneCount < 3 )
				droneCount = 3;
			int droneCountRed = droneCount / 2;
			int droneCountBlue = droneCount - droneCountRed;
			_droneCountDict.Add(FractionType.Red , droneCountRed);
			_droneCountDict.Add(FractionType.Blue , droneCountBlue);

			_frequencyCreateRewardResource = _gamePrefsConfig.FrequencyCreateRewardResource;
		}

		private Dictionary<FractionType , float> _droneSpeedDict = new();
		public float DroneSpeed( FractionType fractionType ) => _droneSpeedDict[fractionType];

		private Dictionary<FractionType , int> _droneCountDict = new();
		public int DroneCount( FractionType fractionType ) => _droneCountDict[fractionType];

		private float _frequencyCreateRewardResource;
		public float FrequencyCreateRewardResource => _frequencyCreateRewardResource;

		private bool _needViewPath = true;
		public bool NeedViewPath => _needViewPath;

		private void OnDroneSpeedSignal( DroneSpeedSignal signal )
		{
			if( _gameLoopControl.IsPlaying == false )
			{
				return;
			}
			_droneSpeedDict[signal.FractionType] = signal.Speed;
		}
		private void OnDroneCountSignal( DroneCountSignal signal )
		{
			if( _gameLoopControl.IsPlaying == false )
			{
				return;
			}
			_droneCountDict[signal.FractionType] = signal.Count;
		}
		private void OnFrequencyCreateRewardResourceSignal( FrequencyCreateRewardResourceSignal signal )
		{
			if( _gameLoopControl.IsPlaying == false )
			{
				return;
			}
			_frequencyCreateRewardResource = signal.Frequency;
		}
		private void OnNeedViewPathChangedSignal( NeedViewPathChangedSignal signal )
		{
			if( _gameLoopControl.IsPlaying == false )
			{
				return;
			}
			_needViewPath = signal.Need;
		}


		private void Subscribe()
		{
			_eventBusService.Subscribe<DroneSpeedSignal>(OnDroneSpeedSignal);
			_eventBusService.Subscribe<DroneCountSignal>(OnDroneCountSignal);
			_eventBusService.Subscribe<FrequencyCreateRewardResourceSignal>(OnFrequencyCreateRewardResourceSignal);
			_eventBusService.Subscribe<NeedViewPathChangedSignal>(OnNeedViewPathChangedSignal);
		}

		public void Dispose()
		{
			_eventBusService.Unsubscribe<DroneSpeedSignal>(OnDroneSpeedSignal);
			_eventBusService.Unsubscribe<DroneCountSignal>(OnDroneCountSignal);
			_eventBusService.Unsubscribe<FrequencyCreateRewardResourceSignal>(OnFrequencyCreateRewardResourceSignal);
			_eventBusService.Unsubscribe<NeedViewPathChangedSignal>(OnNeedViewPathChangedSignal);
		}
	}
}
