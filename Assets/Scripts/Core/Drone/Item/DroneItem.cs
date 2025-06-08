using System;
using System.Collections.Generic;

using SpaceSimulation.Core.Drone.Item.Actions;
using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Core.Fraction.Control;
using SpaceSimulation.Core.GameLoop;
using SpaceSimulation.Core.GamePrefs;
using SpaceSimulation.Core.RewardResource.Control;
using SpaceSimulation.Core.RewardResource.Item;

using UnityEngine;
using UnityEngine.AI;

using Zenject;

namespace SpaceSimulation.Core.Drone.Item
{
	public class DroneItem:MonoBehaviour, IGameLoopUpdate
	{
		private IFractionBaseControl _fractionBaseControl;
		private IRewardResourceControl _rewardResourceControl;
		private IGamePrefsService _gamePrefsService;
		private IGameLoopService _gameLoopControl;
		private FractionType _fractionType;
		private DroneSkin _skin;
		private DroneActions _selActions;
		[Inject]
		private void Construct
		(
			IFractionBaseControl _fractionBaseControl,
			IRewardResourceControl _rewardResourceControl,
			IGamePrefsService _gamePrefsService,
			IGameLoopService _gameLoopControl,
			FractionType _fractionType,
			DroneSkin _skin,
			DroneActions _selActions
		)
		{
			this._fractionBaseControl = _fractionBaseControl;
			this._rewardResourceControl = _rewardResourceControl;
			this._gamePrefsService = _gamePrefsService;
			this._gameLoopControl = _gameLoopControl;
			this._fractionType = _fractionType;
			this._skin = _skin;
			this._selActions = _selActions;
			SetSkinParent();
			CreateStateMachine();
		}

		private void OnEnable()
		{
			_gameLoopControl.Register(this);
		}
		private void OnDisable()
		{
			_gameLoopControl.Unregister(this);
		}

		[SerializeField]
		private NavMeshAgent _navMeshAgent;

		private ExtractabelTargetFinder _currTarget = new ();

		public FractionType FractionType => _fractionType;

		private void SetSkinParent()
		{
			_skin.transform.SetParent(_navMeshAgent.transform);
		}

		private DronStateMachine _stateMachine;

		private void CreateStateMachine()
		{
			_stateMachine = new();

			_stateMachine.Register<DronStartAwaitState>(new DronStartAwaitState
				(_navMeshAgent,
				_selActions)
				);

			_stateMachine.Register<DronFindTargetState>(new DronFindTargetState
				(_stateMachine ,
				_rewardResourceControl,
				_navMeshAgent,
				_selActions,
				_currTarget));

			_stateMachine.Register<DronGoToResourceState>(new DronGoToResourceState
				(_stateMachine,
				_navMeshAgent,
				_selActions,
				 _currTarget,
				 _gamePrefsService,
				 _fractionType,
				 _rewardResourceControl));

			_stateMachine.Register<ExtructResourceState>(new ExtructResourceState
				(_stateMachine,
				_selActions,
				_currTarget,
				_navMeshAgent));

			_stateMachine.Register<DronGoToBaseState>(new DronGoToBaseState
				(_stateMachine,
				_navMeshAgent,
				_selActions,
				_gamePrefsService,
				_fractionBaseControl,
				_fractionType));

			_stateMachine.Register<HandOverResorcesState>(new HandOverResorcesState
				(_stateMachine,
				_selActions,
				_fractionBaseControl,
				_fractionType,
				_currTarget));

			_stateMachine.Enter<DronStartAwaitState>();

		}

		public void ActivateMe()
		{
			_stateMachine.Enter<DronStartAwaitState>();
			_stateMachine.Enter<DronFindTargetState>();
		}


		public void LoopUpdate()
		{
			_stateMachine.Update();
		}
	}

}
