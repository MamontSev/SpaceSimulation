using SpaceSimulation.Core.Drone.Item;
using SpaceSimulation.Core.Fraction;

namespace SpaceSimulation.Core.Drone.Factory
{
	public interface IDroneFactory
	{
		DroneItem Get( FractionType fractionType );
		void Return( DroneItem obj );
	}
}