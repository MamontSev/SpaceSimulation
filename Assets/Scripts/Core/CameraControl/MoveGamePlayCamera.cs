using System;

using SpaceSimulation.Core.GameLoop;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.Core.CameraControl
{
	public class MoveGamePlayCamera:MonoBehaviour, IGameLoopUpdate
	{
		private IGameLoopControl _gameLoopControl;
		[Inject]
		private void Construct( IGameLoopControl _gameLoopControl )
		{
			_gameLoopControl.Register(this);
		}

		private void Awake()
		{
			_rotY = CameraTransform.rotation.eulerAngles.y;
			_rotX = CameraTransform.rotation.eulerAngles.x;
		}


		[SerializeField]
		private Camera _mainCamera;
		private Transform CameraTransform => _mainCamera.transform;

		public void LoopUpdate()
		{
			CheckMousePressed();

			float xAxisValue = Input.GetAxis("Horizontal")/3.0f;
			float zAxisValue = Input.GetAxis("Vertical")/3.0f;
			CameraTransform.Translate(new Vector3(xAxisValue , 0.0f , zAxisValue));

			if( _mousePressed )
			{
				_rotY += 4.0f * Input.GetAxis("Mouse X");
				_rotX -= 4.0f * Input.GetAxis("Mouse Y");

				CameraTransform.eulerAngles = new Vector3(_rotX , _rotY , 0.0f);
			}
			

		}

		private float _rotY = 0.0f;
		private float _rotX = 0.0f;



		private bool _mousePressed = false;
		private void CheckMousePressed()
		{
			if( Input.GetMouseButtonDown(0) )
			{
				_mousePressed = true;
			}
			if( Input.GetMouseButtonUp(0) )
			{
				_mousePressed = false;
			}
		}
	}
}
