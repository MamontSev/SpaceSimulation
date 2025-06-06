namespace SpaceSimulation.Events.Signals
{
	public class FrequencyCreateRewardResourceSignal:IEventBusSignal
	{
		public readonly float Frequency;
		public FrequencyCreateRewardResourceSignal( float frequency )
		{
			Frequency = frequency;
		}
	}
}
