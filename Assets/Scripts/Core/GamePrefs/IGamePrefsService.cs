using SpaceSimulation.Core.Fraction;

namespace SpaceSimulation.Core.GamePrefs
{
	public interface IGamePrefsService
	{
		float FrequencyCreateRewardResource
		{
			get;
		}

		int DroneCount( FractionType fractionType );
		float DroneSpeed( FractionType fractionType );

		bool NeedViewPath
		{
			get;
		}
	}
}