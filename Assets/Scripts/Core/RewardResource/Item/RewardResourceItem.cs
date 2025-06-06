using SpaceSimulation.Core.RewardResource.Control;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.Core.RewardResource.Item
{
	public class RewardResourceItem:MonoBehaviour, IExtructableItem
	{
		private IRewardResourceControl _rewardResourceControl; 
		[Inject]
		private void Construct( IRewardResourceControl _rewardResourceControl )
		{
			this._rewardResourceControl = _rewardResourceControl;
		}
		[SerializeField]
		private float _extractDuration = 2.0f;
		public float ExtractDuration => _extractDuration;

		private State _currState = State.Disabled;
		private enum State
		{
			Disabled = 0,
			AwaitExstruct = 1,
			ProcessExtruct = 2
		}

		public void Init()
		{
			_currState = State.AwaitExstruct;
		}

		public void StartExtruct()
		{
			_currState = State.ProcessExtruct;
		}

		public void FinishExtruct()
		{

		}

		public bool MayExtruct => _currState == State.AwaitExstruct;
	}
}
