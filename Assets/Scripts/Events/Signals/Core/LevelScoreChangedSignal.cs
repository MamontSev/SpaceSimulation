using UnityEngine;

namespace SpaceSimulation.Events.Signals
{
	public class LevelScoreChangedSignal:IEventBusSignal
	{
		public readonly float Value;
		public LevelScoreChangedSignal( float value )
		{
			this.Value = value;
		}
	}
}
