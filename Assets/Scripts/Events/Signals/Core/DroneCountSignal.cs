using SpaceSimulation.Core.Fraction;

namespace SpaceSimulation.Events.Signals
{
	public class DroneCountSignal:IEventBusSignal
	{
		public readonly FractionType FractionType;
		public readonly int Count;
		public DroneCountSignal( FractionType fractionTyp , int count )
		{
			FractionType = fractionTyp;
			Count = count;
		}
	}
}
