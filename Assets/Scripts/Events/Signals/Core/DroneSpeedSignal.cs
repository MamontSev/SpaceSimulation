using SpaceSimulation.Core.Fraction;

namespace SpaceSimulation.Events.Signals
{
	public class DroneSpeedSignal:IEventBusSignal
	{
		public readonly FractionType FractionType;
		public readonly float Speed;
		public DroneSpeedSignal( FractionType fractionTyp, float speed )
		{
			FractionType = fractionTyp;
			Speed = speed;
		}
	}
}
