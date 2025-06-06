using SpaceSimulation.Core.RewardResource.Item;

using UnityEngine;

namespace SpaceSimulation.Data.RewardResource
{
	public interface IRewardResourceConfig
	{
		RewardResourceItem GetPrefab( RewardResourceType type );
	}
}