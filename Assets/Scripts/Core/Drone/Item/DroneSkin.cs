using System.Collections.Generic;
using System;

using SpaceSimulation.Core.Drone.Item.Actions;

using UnityEngine;

using Zenject;
using UnityEngine.AI;
using TMPro;
using Manmont.Tools;
using SpaceSimulation.Core.CameraControl;

namespace SpaceSimulation.Core.Drone.Item
{
	public class DroneSkin:MonoBehaviour
	{
		private IDroneActions _selActions;
		private ToCameraRotation _toCameraRotation;
		[Inject]
		private void Construct
		(
			IDroneActions _selActions,
			ToCameraRotation _toCameraRotation
		)
		{
			this._selActions = _selActions;
			this._toCameraRotation = _toCameraRotation;
		}
		private void OnEnable()
		{
			_selActions.OnExtruct += OnExtruct;
			_selActions.OnFindTarget += OnFindTarget;
			_selActions.OnGoToBase += OnGoToBase;
			_selActions.OnGoToRes += OnGoToRes;
			_selActions.OnHandOverResources += OnHandOverResources;
			_selActions.OnSetExtructValue += OnSetExtructValue;
			_selActions.OnSetPathToGo += OnSetPathToGo;
			_selActions.OnStartAwait += OnStartAwait;
		}
		private void OnDisable()
		{
			_selActions.OnExtruct -= OnExtruct;
			_selActions.OnFindTarget -= OnFindTarget;
			_selActions.OnGoToBase -= OnGoToBase;
			_selActions.OnGoToRes -= OnGoToRes;
			_selActions.OnHandOverResources -= OnHandOverResources;
			_selActions.OnSetExtructValue -= OnSetExtructValue;
			_selActions.OnSetPathToGo -= OnSetPathToGo;
			_selActions.OnStartAwait -= OnStartAwait;
		}

		private void OnStartAwait( bool state )
		{
			if( state == true )
			{
				LineRendererPath.enabled = false;
				LineRendererExtruct.enabled = false;
				FindTarget.SetActive(false);
				GoToResource.SetActive(false);
				ExtructResource.SetActive(false);
				GoToBase.SetActive(false);
			}
		}
		private void OnFindTarget( bool state )
		{
			FindTarget.SetActive(state);
		}
		private void OnGoToRes( bool state )
		{
			GoToResource.SetActive(state);
			LineRendererPath.enabled = state;
		}

		private void OnSetPathToGo( List<Vector3> path )
		{
			if( path.Count < 2 )
			{
				LineRendererPath.positionCount = 0;
				return;
			}
			LineRendererPath.positionCount = path.Count;
			for( int i = 0; i < path.Count; i++ )
			{
				LineRendererPath.SetPosition(i , path[i]);
			}
		}
		private void OnExtruct( bool state )
		{
			ExtructResource.SetActive(state);
			LineRendererExtruct.enabled = state;
		}
		private void OnSetExtructValue( float value, Vector3 from, Vector3 to )
		{
			ExtructResourceValueText.text = value.DigitToString();
			ExtructResource.transform.rotation = _toCameraRotation.GetRotation();

			LineRendererExtruct.positionCount = 2;
			LineRendererExtruct.SetPosition(0 , from);
			LineRendererExtruct.SetPosition(1 , to);
		}
		private void OnGoToBase( bool state )
		{
			GoToBase.SetActive(state);
			LineRendererPath.enabled = state;
		}

		private void OnHandOverResources( bool state )
		{
			
		}

		
		[SerializeField]
		private LineRenderer LineRendererPath;
		[SerializeField]
		private LineRenderer LineRendererExtruct;

		[SerializeField]
		private GameObject FindTarget;

		[SerializeField]
		private GameObject GoToResource;

		[SerializeField]
		private GameObject ExtructResource;
		[SerializeField]
		private TextMeshPro ExtructResourceValueText;

		[SerializeField]
		private GameObject GoToBase;




	}

}
