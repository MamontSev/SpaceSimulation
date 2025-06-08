using Manmont.Tools.StateMashine;

using SpaceSimulation.Core.Drone.Item.Actions;
using SpaceSimulation.Core.RewardResource.Control;
using SpaceSimulation.Core.RewardResource.Item;

using UnityEngine;
using UnityEngine.AI;

namespace SpaceSimulation.Core.Drone.Item
{
	public class DronFindTargetState:IDronState, IUpdateState, IEnterState,IExitState
	{
		private readonly DronStateMachine _stateMachine;
		private readonly IRewardResourceControl _rewardResourceControl;
		private readonly NavMeshAgent _navMeshAgent;
		private readonly DroneActions _selActions;
		private readonly ExtractabelTargetFinder _currTarget;

		public DronFindTargetState
		(
			DronStateMachine _stateMachine,
			IRewardResourceControl _rewardResourceControl,
			NavMeshAgent _navMeshAgent,
			DroneActions _selActions ,
			ExtractabelTargetFinder _currTarge
		)
        {
			this._stateMachine = _stateMachine;
			this._rewardResourceControl = _rewardResourceControl;
			this._navMeshAgent = _navMeshAgent;
			this._selActions = _selActions;
			this._currTarget = _currTarge;

		}

		public void Enter()
		{
			_currTarget.ResetTarget();
			_selActions.FindTarget(true);
			_navMeshAgent.speed = 0.0f;
		}

		public void Exit()
		{
			_selActions.FindTarget(false);
		}

		public void Update()
		{
			_currTarget.Find(
				_navMeshAgent.transform.position,
				_rewardResourceControl.ExtructableItemsList,
				 complete=>
				 {
					 if( complete )
					 {
						 _stateMachine.Enter<DronGoToResourceState>();
					 }
				 });
        }
	}

}
