using Manmont.Tools.StateMashine;

using SpaceSimulation.Core.Drone.Item.Actions;
using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Core.GamePrefs;
using SpaceSimulation.Core.RewardResource.Control;

using UnityEngine;
using UnityEngine.AI;

namespace SpaceSimulation.Core.Drone.Item
{
	public class DronGoToResourceState:AbstractGoState, IUpdateState, IEnterState, IExitState
	{
		private readonly DronStateMachine _stateMachine;
		private readonly NavMeshAgent _navMeshAgent;
		private readonly DroneActions _selActions;
		private readonly ExtractabelTargetFinder _currTarget;
		private readonly IGamePrefsService _gamePrefsService;
		private readonly FractionType _fractionType;
		private readonly IRewardResourceControl _rewardResourceControl;

		public DronGoToResourceState
		(
			DronStateMachine _stateMachine ,
			NavMeshAgent _navMeshAgent ,
			DroneActions _selActions ,
			ExtractabelTargetFinder _currTarge ,
			IGamePrefsService _gamePrefsService	,
			FractionType _fractionType ,
			IRewardResourceControl _rewardResourceControl
		) :base(_navMeshAgent, _selActions, _gamePrefsService)
		{
			this._stateMachine = _stateMachine;
			this._navMeshAgent = _navMeshAgent;
			this._selActions = _selActions;
			this._currTarget = _currTarge;
			this._gamePrefsService = _gamePrefsService;
			this._fractionType = _fractionType;
			this._rewardResourceControl = _rewardResourceControl;
		}

		private const float ExtructDistance = 4.0f;

		private float _timeLastRepath = 0.0f;
		public void Enter()
		{
			if( _currTarget.Target == null || _currTarget.Target.MayExtruct == false )
			{
				_stateMachine.Enter<DronFindTargetState>();
				return;
			}
			_timeLastRepath = Time.time;
			_selActions.GoToRes(true);
			_navMeshAgent.stoppingDistance = 3.0f;
			_navMeshAgent.destination = _currTarget.Target.Position;
		}

		
		public void Exit()
		{
			_selActions.GoToRes(false);
			_navMeshAgent.speed = 0.0f;
		}

		public void Update()
		{
			if( _currTarget.Target == null || _currTarget.Target.MayExtruct == false )
			{
				_stateMachine.Enter<DronFindTargetState>();
				return;
			}
			if( Time.time > _timeLastRepath + 0.2f )
			{
				_currTarget.Find(
				_navMeshAgent.transform.position ,
				_rewardResourceControl.ExtructableItemsList ,
				 complete => { _navMeshAgent.destination = _currTarget.Target.Position; });
				
			}
			_navMeshAgent.speed = _gamePrefsService.DroneSpeed(_fractionType);
			DrawPath();
			CheckComplete();
		}

		private void CheckComplete()
		{
			if( _currTarget.Target == null || _currTarget.Target.MayExtruct == false )
			{
				_stateMachine.Enter<DronFindTargetState>();
				return;
			}
			float dist = Vector3.Distance(_navMeshAgent.transform.position , _currTarget.Target.Position);
			if( dist < ExtructDistance )
			{
				_stateMachine.Enter<ExtructResourceState>();
			}
		}

	}

}
