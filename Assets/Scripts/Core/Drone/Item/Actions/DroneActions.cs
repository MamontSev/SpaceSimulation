using System;
using System.Collections.Generic;

using UnityEngine;

namespace SpaceSimulation.Core.Drone.Item.Actions
{
	public class DroneActions:IDroneActions
	{
		public event Action<bool> OnStartAwait;
		public event Action<bool> OnFindTarget;
		public event Action<bool> OnGoToRes;
		public event Action<List<Vector3>> OnSetPathToGo;
		public event Action<bool> OnExtruct;
		public event Action<float, Vector3, Vector3> OnSetExtructValue;
		public event Action<bool> OnGoToBase;
		public event Action<bool> OnHandOverResources;

		public void StartAwait(bool state)
		{
			OnStartAwait?.Invoke(state);
		}
		public void FindTarget( bool state )
		{
			OnFindTarget?.Invoke(state);
		}
		public void GoToRes( bool state )
		{
			OnGoToRes?.Invoke(state);
		}
		public void SetPathToGo( List<Vector3> path )
		{
			OnSetPathToGo?.Invoke(path);
		}
		public void Extruct( bool state )
		{
			OnExtruct?.Invoke(state);
		}
		public void SetExtructValue( float vale, Vector3 from, Vector3 to )
		{
			OnSetExtructValue?.Invoke(vale, from, to);
		}
		public void GoToBase( bool state )
		{
			OnGoToBase?.Invoke(state);
		}
		public void HandOverResources( bool state )
		{
			OnHandOverResources?.Invoke(state);
		}

	}
}
