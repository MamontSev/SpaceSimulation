using System;
using System.Collections.Generic;

using SpaceSimulation.Core.Drone.Factory;
using SpaceSimulation.Core.Drone.Item;
using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.GamePrefs;
using SpaceSimulation.Core.Spawn;
using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;

namespace SpaceSimulation.Core.Drone.Control
{
	public class DroneControl:IDroneControl
	{
		private readonly IDroneFactory _droneFactory;
		private readonly ISpawnPointFinder _spawnPointFinder;
		private readonly IGamePrefsService _gamePrefsService;
		private readonly IEventBusService _eventBusService;
		public DroneControl
		(
			IDroneFactory _droneFactory ,
			ISpawnPointFinder _spawnPointFinder ,
			IGamePrefsService _gamePrefsService ,
			IEventBusService _eventBusService
		)
		{
			this._droneFactory = _droneFactory;
			this._spawnPointFinder = _spawnPointFinder;
			this._gamePrefsService = _gamePrefsService;
			this._eventBusService = _eventBusService;
			Subscribe();
			InitDroneList();
		}


		private void OnDroneCountSignal( DroneCountSignal signal )
		{
			Init(signal.FractionType , signal.Count);
		}

		public void Init()
		{
			Init(FractionType.Red, _gamePrefsService.DroneCount(FractionType.Red));
			Init(FractionType.Blue, _gamePrefsService.DroneCount(FractionType.Blue));
		}

		private readonly Dictionary<FractionType , List<DroneItem>> _droneList = new();
		private void InitDroneList()
		{
			foreach( FractionType fractionType in Enum.GetValues(typeof(FractionType)) )
			{
				_droneList.Add(fractionType , new());
			}
		}

		private void Init( FractionType fractionType , int newCount )
		{
			int existCount = _droneList[fractionType].Count;
			if( existCount < newCount )
			{
				int addedCount = newCount - existCount;
				for( int i = 0; i < addedCount; i++ )
				{
					DroneItem item = _droneFactory.Get(fractionType);
					item.transform.position = _spawnPointFinder.GetSpawnPosition();
					item.gameObject.SetActive(true);
					item.ActivateMe();
					_droneList[fractionType].Add(item);
				}
			}
			else if( existCount > newCount )
			{
				int removeCount = existCount - newCount;
				for( int i = 0; i < removeCount; i++ )
				{
					DroneItem item = _droneList[fractionType][0];
					item.gameObject.SetActive(false);
					_droneFactory.Return(item);
					_droneList[fractionType].RemoveAt(0);
				}
			}
		}


		private void Subscribe()
		{
			_eventBusService.Subscribe<DroneCountSignal>(OnDroneCountSignal);
		}



		public void LateDispose()
		{
			_eventBusService.Unsubscribe<DroneCountSignal>(OnDroneCountSignal);
		}
	}
}
