using System.Collections.Generic;

using SpaceSimulation.Core.Drone.Item.Actions;
using SpaceSimulation.Core.GamePrefs;

using UnityEngine;
using UnityEngine.AI;

namespace SpaceSimulation.Core.Drone.Item
{
	public class AbstractGoState:IDronState
	{
		private readonly NavMeshAgent _navMeshAgent;
		private readonly DroneActions _selActions;
		private readonly IGamePrefsService _gamePrefsService;
		public AbstractGoState
		(
			NavMeshAgent _navMeshAgent ,
			DroneActions _selActions,
			IGamePrefsService _gamePrefsService
		)
		{
			this._navMeshAgent = _navMeshAgent;
			this._selActions = _selActions;
			this._gamePrefsService = _gamePrefsService;
		}
		private List<Vector3> _path = new();
		protected void DrawPath()
		{
			_path.Clear();
			if( _gamePrefsService.NeedViewPath == false )
			{
				_selActions.SetPathToGo(_path);
				return;
			}
			_path.Add(_navMeshAgent.transform.position);
			if( _navMeshAgent.path.corners.Length < 2 )
			{
				_selActions.SetPathToGo(_path);
				return;
			}
			for( int i = 1; i < _navMeshAgent.path.corners.Length; i++ )
			{
				Vector3 pos = new Vector3(_navMeshAgent.path.corners[i].x , _navMeshAgent.path.corners[i].y , _navMeshAgent.path.corners[i].z);
				_path.Add(pos);
				_selActions.SetPathToGo(_path);
			}
		}
	}

}
