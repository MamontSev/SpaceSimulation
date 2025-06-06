using System;

namespace SpaceSimulation.Data.GamePrefs
{
	public class GamePrefsConfig:IGamePrefsConfig
	{
		private readonly GamePrefsPreset _data;
		public GamePrefsConfig( GamePrefsPreset data )
		{
			_data = data;
			ValidateData();
		}

		public (float min, float max) DroneCount => (_data.MinDroneCount, _data.MaxDroneCount);
		public (float min, float max) DroneSpeed => (_data.MinDroneSpeed, _data.MaxDroneSpeed);
		public float FrequencyCreateRewardResource => _data.FrequencyCreateRewardResource;

		private void ValidateData()
		{
			if( _data.MaxDroneCount <= _data.MinDroneCount )
			{
				throw new Exception($"GamePrefsPreset MaxDroneCount:{_data.MaxDroneCount} <= MinDroneCount:{_data.MinDroneCount}");
			}
			if( _data.MaxDroneSpeed <= _data.MinDroneSpeed )
			{
				throw new Exception($"GamePrefsPreset MaxDroneSpeed:{_data.MaxDroneSpeed} <= MinDroneSpeed:{_data.MinDroneSpeed}");
			}
		}
	}
}

