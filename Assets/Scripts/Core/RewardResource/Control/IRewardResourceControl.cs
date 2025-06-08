using System.Collections.Generic;

using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.RewardResource.Item;

using Zenject;

namespace SpaceSimulation.Core.RewardResource.Control
{
	public interface IRewardResourceControl:IGameLoopUpdate
	{
		List<IExtructableItem> ExtructableItemsList
		{
			get;
		}

		void Init();
		void OnExtructableItemDestroyed( RewardResourceItem item );
	}
}
