using Manmont.Tools.StateMashine;

using SpaceSimulation.Core.Drone.Item.Actions;
using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Core.Fraction.Control;
using SpaceSimulation.Core.GamePrefs;

using UnityEngine;
using UnityEngine.AI;

namespace SpaceSimulation.Core.Drone.Item
{
	public class DronGoToBaseState:AbstractGoState, IUpdateState, IEnterState, IExitState
	{
		private readonly DronStateMachine _stateMachine;
		private readonly NavMeshAgent _navMeshAgent;
		private readonly DroneActions _selActions;
		private readonly IGamePrefsService _gamePrefsService;
		private readonly IFractionBaseControl _fractionBaseControl;
		private readonly FractionType _fractionType;

		public DronGoToBaseState
		(
			DronStateMachine _stateMachine ,
			NavMeshAgent _navMeshAgent ,
			DroneActions _selActions ,
			IGamePrefsService _gamePrefsService ,
			IFractionBaseControl _fractionBaseControl,
			FractionType _fractionType
		) : base(_navMeshAgent , _selActions, _gamePrefsService)
		{
			this._stateMachine = _stateMachine;
			this._navMeshAgent = _navMeshAgent;
			this._selActions = _selActions;
			this._gamePrefsService = _gamePrefsService;
			this._fractionBaseControl = _fractionBaseControl;
			this._fractionType = _fractionType;
		}

		private const float CompleteDistance = 2.0f;

		public void Enter()
		{
			_selActions.GoToBase(true);
			_navMeshAgent.stoppingDistance = 1.5f;
			_navMeshAgent.destination = _fractionBaseControl.GetFractionBaseTransform(_fractionType).position;
		}

		public void Exit()
		{
			_selActions.GoToBase(false);
			_navMeshAgent.speed = 0.0f;
		}

		public void Update()
		{
			_navMeshAgent.speed = _gamePrefsService.DroneSpeed(_fractionType);
			DrawPath();
			CheckComplete();
		}

		private void CheckComplete()
		{
			float dist = Vector3.Distance(_navMeshAgent.transform.position , _fractionBaseControl.GetFractionBaseTransform(_fractionType).position);
			if( dist < CompleteDistance )
			{
				_stateMachine.Enter<HandOverResorcesState>();
			}
		}

	}

}
