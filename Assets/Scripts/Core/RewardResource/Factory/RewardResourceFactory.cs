using System;
using System.Collections.Generic;

using SpaceSimulation.Core.RewardResource.Item;
using SpaceSimulation.Data.RewardResource;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.Core.RewardResource.Factory
{
	public class RewardResourceFactory:MonoBehaviour, IRewardResourceFactory
	{
		private IRewardResourceConfig _resourceConfig;
		private DiContainer _diContainer;
		[Inject]
		private void Construct
		(
			IRewardResourceConfig _resourceConfig ,
			DiContainer _diContainer
		)
		{
			this._resourceConfig = _resourceConfig;
			this._diContainer = _diContainer;
		}

		[SerializeField]
		private Transform ItemParent;

		private readonly  List<RewardResourceItem> _pool = new();

		public void Init()
		{
			foreach( RewardResourceType type in Enum.GetValues(typeof(RewardResourceType)) )
			{
				RewardResourceItem item = InstantiateItem(type);
				item.gameObject.SetActive(false);
				_pool.Add(item);
			}
		}

		public RewardResourceItem Get()
		{
			
			RewardResourceItem item;
			if( _pool.Count == 0 )
			{
				int randomType = UnityEngine.Random.Range(0 , Enum.GetValues(typeof(RewardResourceType)).Length);
				item = InstantiateItem((RewardResourceType)randomType);
			}
			else
			{
				int rand = UnityEngine.Random.Range(0 , _pool.Count);
				item = _pool[rand];
				_pool.Remove(item);
			}
			item.gameObject.SetActive(true);
			item.Init();
			return item;
		}

		public void Return( RewardResourceItem obj )
		{
			obj.gameObject.SetActive(false);
			_pool.Add(obj);
		}


		private RewardResourceItem InstantiateItem( RewardResourceType type )
		{
			return _diContainer.InstantiatePrefabForComponent<RewardResourceItem>(_resourceConfig.GetPrefab(type).gameObject , ItemParent);
		}

	}
}
