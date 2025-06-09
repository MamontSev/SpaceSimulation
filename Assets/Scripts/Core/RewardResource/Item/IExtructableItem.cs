using UnityEngine;

namespace SpaceSimulation.Core.RewardResource.Item
{
	public interface IExtructableItem
	{
		float ExtractDuration
		{
			get;
		}
		float ExtructResourceAmount
		{
			get;
		}
		bool MayExtruct
		{
			get;
		}

		Vector3 Position
		{
			get;
		}


		void FinishExtruct();
		void StartExtruct();
		void StopExtruct();
	}
}