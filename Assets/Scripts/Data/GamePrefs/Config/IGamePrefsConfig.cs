namespace SpaceSimulation.Data.GamePrefs
{
	public interface IGamePrefsConfig
	{
		(float min, float max) DroneCount
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