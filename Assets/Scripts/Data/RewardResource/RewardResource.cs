using System;

using SpaceSimulation.Core.RewardResource.Item;

using UnityEngine;


#if UNITY_EDITOR
#endif

namespace SpaceSimulation.Data.RewardResource
{
	[Serializable]
	public class RewardResource
	{
		public RewardResource( RewardResourceType selfType )
		{
			_selfType = selfType;
		}
		[SerializeField]
		private RewardResourceType _selfType;
		public RewardResourceType SelfType => _selfType;

		[SerializeField]
		private RewardResourceItem _prefab;
		public RewardResourceItem Prafab => _prefab;

	}
}







