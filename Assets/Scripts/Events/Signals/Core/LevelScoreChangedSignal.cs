using SpaceSimulation.Core.Fraction;

using UnityEngine;

namespace SpaceSimulation.Events.Signals
{
	public class LevelScoreChangedSignal:IEventBusSignal
	{
		public readonly FractionType FractionType;
		public readonly float NewAmount;
		public LevelScoreChangedSignal( FractionType fractionType, float newAmount )
		{
			this.FractionType = fractionType;
			this.NewAmount = newAmount;
		}
	}
}
