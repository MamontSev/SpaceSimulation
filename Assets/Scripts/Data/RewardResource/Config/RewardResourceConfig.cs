#if UNITY_EDITOR
#endif

using System;
using System.Collections.Generic;
using System.Linq;

using SpaceSimulation.Core.RewardResource.Item;

using UnityEngine;

namespace SpaceSimulation.Data.RewardResource
{
	public class RewardResourceConfig:IRewardResourceConfig
	{
		private RewardResourcePreset _data;
		public RewardResourceConfig( RewardResourcePreset data )
		{
			_data = data;
			Validate();
		}

		public RewardResourceItem GetPrefab( RewardResourceType type ) => _dataDict[type];

		private readonly Dictionary<RewardResourceType , RewardResourceItem> _dataDict = new();

		private void Validate()
		{
			List<RewardResourceType> typeList = _data.ItemList.Select(x => x.SelfType).ToList();
			foreach( RewardResourceType type in Enum.GetValues(typeof(RewardResourceType)) )
			{
				if( typeList.Contains(type) == false )
				{
					throw new Exception($"RewardResourcePreset not contains `{type}`");
				}
			}
			foreach( var item in _data.ItemList )
			{
				if( item.Prafab == null )
				{
					throw new Exception($"RewardResourcePreset Prefab is null `{item.SelfType}`");
				}
				_dataDict.Add(item.SelfType , item.Prafab);

			}
		}
	}
}







