using SpaceSimulation.Core.Fraction;

namespace SpaceSimulation.Core.Score
{
	public interface IScoreControl
	{
		void AddScore( FractionType type , float amount );
		float GetAmount( FractionType type );
	}
}
