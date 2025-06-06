using UnityEngine;

namespace SpaceSimulation.Data.GamePrefs
{
	[CreateAssetMenu(menuName = "Data/GamePrefsPreset" , fileName = "GamePrefsPreset.asset")]
	public class GamePrefsPreset:ScriptableObject
	{
		[SerializeField]
		private int _minDroneCount;
		public int MinDroneCount => _minDroneCount;

		[SerializeField]
		private int _maxDroneCount;
		public int MaxDroneCount => _maxDroneCount;

		[SerializeField]
		private int _minDroneSpeed;
		public int MinDroneSpeed => _minDroneSpeed;

		[SerializeField]
		private int _maxDroneSpeed;
		public int MaxDroneSpeed => _maxDroneSpeed;

		[SerializeField]
		private float _frequencyCreateRewardResource = 1.0f;

		public float FrequencyCreateRewardResource => _frequencyCreateRewardResource;
	}
}

