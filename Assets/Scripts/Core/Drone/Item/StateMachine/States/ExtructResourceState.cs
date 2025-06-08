using Manmont.Tools.StateMashine;

using SpaceSimulation.Core.Drone.Item.Actions;

using UnityEngine;
using UnityEngine.AI;

namespace SpaceSimulation.Core.Drone.Item
{
	public class ExtructResourceState:IDronState, IUpdateState, IEnterState, IExitState
	{
		private readonly DronStateMachine _stateMachine;
		private readonly DroneActions _selActions;
		private readonly ExtractabelTargetFinder _currTarget;
		private readonly NavMeshAgent _navMeshAgent;

		public ExtructResourceState
		(
			DronStateMachine _stateMachine ,
			DroneActions _selActions ,
			ExtractabelTargetFinder _currTarge,
			NavMeshAgent _navMeshAgent
		) 
		{
			this._stateMachine = _stateMachine;
			this._selActions = _selActions;
			this._currTarget = _currTarge;
			this._navMeshAgent = _navMeshAgent;
		}

		private float _timeRemaining;
		public void Enter()
		{
			if( _currTarget.Target == null || _currTarget.Target.MayExtruct == false )
			{
				_stateMachine.Enter<DronFindTargetState>();
				return;
			}
			_selActions.Extruct(true);
			_currTarget.Target.StartExtruct();
			_timeRemaining = _currTarget.Target.ExtractDuration;
		}

		public void Exit()
		{
			_selActions.Extruct(false);
		}

		public void Update()
		{
			_timeRemaining -= Time.deltaTime;
			if( _timeRemaining <= 0.0f ) 
			{
				_timeRemaining = 0.0f;
			}
			_selActions.SetExtructValue(_timeRemaining, _navMeshAgent.transform.position, _currTarget.Target.Position);
			if( _timeRemaining == 0.0f )
			{
				_currTarget.Target.FinishExtruct();
				_stateMachine.Enter<DronGoToBaseState>();
			}
		}
	}

}
