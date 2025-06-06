using UnityEngine;

namespace SpaceSimulation.Core.Spawn
{
	public interface ISpawnPointFinder
	{
		Vector3 GetSpawnPosition();
	}
}