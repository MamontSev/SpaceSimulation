using System.Collections.Generic;

using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.GamePrefs;
using SpaceSimulation.Core.RewardResource.Factory;
using SpaceSimulation.Core.RewardResource.Item;
using SpaceSimulation.Core.Spawn;
using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;

using UnityEngine;

namespace SpaceSimulation.Core.RewardResource.Control
{
	public class RewardResourceControl:IRewardResourceControl
	{
		private readonly IRewardResourceFactory _rewardResourceFactory;
		private readonly IGameLoopService _gameLoopControl;
		private readonly ISpawnPointFinder _spawnPointFinder;
		private readonly IGamePrefsService _gamePrefsService;
		public RewardResourceControl
		(
			IRewardResourceFactory _rewardResourceFactory,
			IGameLoopService _gameLoopControl,
			ISpawnPointFinder _spawnPointFinder	,
			IGamePrefsService _gamePrefsService
		)
        {
			this._rewardResourceFactory = _rewardResourceFactory;
			this._gameLoopControl = _gameLoopControl;
			this._spawnPointFinder = _spawnPointFinder;
			this._gamePrefsService = _gamePrefsService;
			RegisterGameLoop();
		}

		private List<IExtructableItem> _extructableItemsList = new();
		public List<IExtructableItem> ExtructableItemsList => _extructableItemsList;

		public void OnExtructableItemDestroyed( RewardResourceItem item )
		{
			_extructableItemsList.Remove(item);
			_rewardResourceFactory.Return(item);
		}


		private float _timeLastCreate = 0.0f;
		private float TimeNextCreate => _timeLastCreate + _gamePrefsService.FrequencyCreateRewardResource;
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

		private void RegisterGameLoop()
		{
			_gameLoopControl.Register(this);
		}
		public void Init()
		{
			CreateRewardResourceItem();
		}
	}
}
