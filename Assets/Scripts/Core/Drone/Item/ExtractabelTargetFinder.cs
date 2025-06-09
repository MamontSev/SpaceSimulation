using System;
using System.Collections.Generic;

using SpaceSimulation.Core.RewardResource.Item;

using UnityEngine;

namespace SpaceSimulation.Core.Drone.Item
{
	public class ExtractabelTargetFinder
	{
		public void Find(Vector3 selfPos, List<IExtructableItem> list, Action<bool> callback)
		{
			float bestDistance = float.MaxValue;
			IExtructableItem newTraget = null;
			foreach( var item in list )
			{
				if( item.MayExtruct == false )
					continue;
				float dist = Vector3.Distance(selfPos , item.Position);
				if( dist < bestDistance )
				{
					bestDistance = dist;
					newTraget = item;
				}
			}
			if( newTraget == null )
			{
				callback?.Invoke(false);
				return;
			}
			if( newTraget == _target )
			{
				callback?.Invoke(false);
				return;
			}
			_target = newTraget;
			callback?.Invoke(true);
		}
		public void ResetTarget()
		{
			_target = null;
		}
		private IExtructableItem _target = null;
		public IExtructableItem Target => _target;
	}

}
