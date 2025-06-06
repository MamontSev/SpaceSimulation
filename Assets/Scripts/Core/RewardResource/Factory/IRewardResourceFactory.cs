using SpaceSimulation.Core.RewardResource.Item;

namespace SpaceSimulation.Core.RewardResource.Factory
{
	public interface IRewardResourceFactory
	{
		RewardResourceItem Get();
		void Init();
		void Return( RewardResourceItem obj );
	}
}