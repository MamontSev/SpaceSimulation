using System;
using System.Collections.Generic;

using UnityEngine;

namespace SpaceSimulation.Core.Drone.Item.Actions
{
	public interface IDroneActions
	{
		event Action<bool> OnExtruct;
		event Action<bool> OnFindTarget;
		event Action<bool> OnGoToBase;
		event Action<bool> OnGoToRes;
		event Action<bool> OnHandOverResources;
		event Action<float, Vector3, Vector3> OnSetExtructValue;
		event Action<List<Vector3>> OnSetPathToGo;
		event Action<bool> OnStartAwait;
	}
}