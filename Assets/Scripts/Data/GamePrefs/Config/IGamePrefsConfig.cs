namespace SpaceSimulation.Data.GamePrefs
{
	public interface IGamePrefsConfig
	{
		(int min, int max) DroneCount
		{
			get;
		}
		(float min, float max) DroneSpeed
		{
			get;
		}
		float FrequencyCreateRewardResource
		{
			get;
		}
	}
}