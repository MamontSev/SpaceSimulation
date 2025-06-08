namespace SpaceSimulation.Events.Signals
{
	public class NeedViewPathChangedSignal:IEventBusSignal
	{
		public readonly bool Need;
		public NeedViewPathChangedSignal( bool need )
		{
			Need = need;
		}
	}
}
