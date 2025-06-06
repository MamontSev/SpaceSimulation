using System;
using System.Collections.Generic;

using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.RewardResource.Factory;
using SpaceSimulation.Core.RewardResource.Item;
using SpaceSimulation.Core.Spawn;
using SpaceSimulation.Data.GamePrefs;
using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;

using UnityEngine;
using UnityEngine.AI;

using Zenject;

namespace SpaceSimulation.Core.RewardResource.Control
{
	public interface IRewardResourceControl:IGameLoopUpdate, ILateDisposable
	{
		List<IExtructableItem> ExtructableItemsList
		{
			get;
		}

		void OnExtructableItemDestroyed( RewardResourceItem item );
	}
	public class RewardResourceControl:IRewardResourceControl
	{
		private readonly IRewardResourceFactory _rewardResourceFactory;
		private readonly IEventBusService _eventBusService;
		private readonly IGameLoopControl _gameLoopControl;
		private readonly IGamePrefsConfig _gamePrefsConfig;
		private readonly ISpawnPointFinder _spawnPointFinder; 
		public RewardResourceControl
		(
			IRewardResourceFactory _rewardResourceFactory,
			IEventBusService _eventBusService,
			IGameLoopControl _gameLoopControl,
			IGamePrefsConfig _gamePrefsConfig,
			ISpawnPointFinder _spawnPointFinder
		)
        {
			this._rewardResourceFactory = _rewardResourceFactory;
			this._eventBusService = _eventBusService;
			this._gameLoopControl = _gameLoopControl;
			this._gamePrefsConfig = _gamePrefsConfig;
			this._spawnPointFinder = _spawnPointFinder;
			RegisterGameLoop();
			InitFrequency();
			Subscribe();
		}

		private List<IExtructableItem> _extructableItemsList = new();
		public List<IExtructableItem> ExtructableItemsList => _extructableItemsList;

		public void OnExtructableItemDestroyed( RewardResourceItem item )
		{
			_extructableItemsList.Remove(item);
			_rewardResourceFactory.Return(item);
		}


		private float _timeLastCreate = 0.0f;
		private float TimeNextCreate => _timeLastCreate + _frequency;
		private void CreateRewardResourceItem()
		{
			_timeLastCreate = Time.time;
			RewardResourceItem item = _rewardResourceFactory.Get();
			item.transform.position = _spawnPointFinder.GetSpawnPosition();
		
			_extructableItemsList.Add(item);
		}
		public void LoopUpdate()
		{
			if( Time.time < TimeNextCreate )
				return;
			CreateRewardResourceItem();
		}

		private float _frequency;
		private void InitFrequency()
		{
			_frequency = _gamePrefsConfig.FrequencyCreateRewardResource;
		}
		private void OnFrequencyCreateRewardResourceSignal( FrequencyCreateRewardResourceSignal signal )
		{
			_frequency = signal.Frequency;
		}

		private void RegisterGameLoop()
		{
			_gameLoopControl.Register(this);
		}
		private void OnLevelInitCompletedSignal( LevelInitCompletedSignal signal )
		{
			CreateRewardResourceItem();
		}


		


		private void Subscribe()
		{
			_eventBusService.Subscribe<FrequencyCreateRewardResourceSignal>(OnFrequencyCreateRewardResourceSignal);
			_eventBusService.Subscribe<LevelInitCompletedSignal>(OnLevelInitCompletedSignal);
		}

		public void LateDispose()
		{
			_eventBusService.Unsubscribe<FrequencyCreateRewardResourceSignal>(OnFrequencyCreateRewardResourceSignal);
			_eventBusService.Unsubscribe<LevelInitCompletedSignal>(OnLevelInitCompletedSignal);
		}
	}
}
