using Manmont.Tools.StateMashine;

using SpaceSimulation.Core.Drone.Item.Actions;

using UnityEngine.AI;

namespace SpaceSimulation.Core.Drone.Item
{
	public class DronStartAwaitState:IDronState,  IEnterState, IExitState
	{
		private readonly NavMeshAgent _navMeshAgent;
		private readonly DroneActions _selActions;

		public DronStartAwaitState
		(
			NavMeshAgent _navMeshAgent ,
			DroneActions _selActions
		)
		{
			this._navMeshAgent = _navMeshAgent;
			this._selActions = _selActions;

		}

		public void Enter()
		{
			_selActions.StartAwait(true);
			_navMeshAgent.enabled = false;
		}

		public void Exit()
		{
			_selActions.StartAwait(false);
			_navMeshAgent.enabled = true;
		}
	}

}
