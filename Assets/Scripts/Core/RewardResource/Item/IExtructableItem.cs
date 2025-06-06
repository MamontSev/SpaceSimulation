namespace SpaceSimulation.Core.RewardResource.Item
{
	public interface IExtructableItem
	{
		float ExtractDuration
		{
			get;
		}
		bool MayExtruct
		{
			get;
		}

		void FinishExtruct();
		void StartExtruct();
	}
}