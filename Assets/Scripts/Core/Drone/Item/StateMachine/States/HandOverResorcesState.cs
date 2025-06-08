using Manmont.Tools.StateMashine;

using SpaceSimulation.Core.Drone.Item.Actions;
using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Core.Fraction.Control;

using UnityEngine;

namespace SpaceSimulation.Core.Drone.Item
{
	public class HandOverResorcesState:IDronState, IUpdateState, IEnterState, IExitState
	{
		private readonly DronStateMachine _stateMachine;
		private readonly DroneActions _selActions;
		private readonly IFractionBaseControl _fractionBaseControl;
		private readonly FractionType _fractionType;
		private readonly ExtractabelTargetFinder _currTarget;

		public HandOverResorcesState
		(
			DronStateMachine _stateMachine ,
			DroneActions _selActions ,
			IFractionBaseControl _fractionBaseControl ,
			FractionType _fractionType,
			ExtractabelTargetFinder _currTarget
		) 
		{
			this._stateMachine = _stateMachine;
			this._selActions = _selActions;
			this._fractionBaseControl = _fractionBaseControl;
			this._fractionType = _fractionType;
			this._currTarget = _currTarget;
		}

		private float _timeToEnd;
		public void Enter()
		{
			_selActions.HandOverResources(true);
			_fractionBaseControl.HandOverResources(_fractionType, _currTarget.Target.ExtructResourceAmount);
			_timeToEnd = Time.time + 1.0f;
		}

		public void Exit()
		{
			_selActions.HandOverResources(false);
		}

		public void Update()
		{
			if( Time.time < _timeToEnd )
				return;
			_stateMachine.Enter<DronFindTargetState>();
		}
	}

}
