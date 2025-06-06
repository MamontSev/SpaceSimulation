namespace SpaceSimulation.Core.Score
{
	public interface IScoreControl
	{
		float CurrScore
		{
			get;
		}

		void AddScore( float amount );
	}
}
