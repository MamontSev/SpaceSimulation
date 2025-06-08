using UnityEngine;

namespace SpaceSimulation.Core.CameraControl
{
	public class ToCameraRotation:MonoBehaviour
	{
		[SerializeField]
		private Camera _mainCamera;
		GameObject _temp;
		private void Awake()
		{
			_temp = GameObject.Instantiate(new GameObject(),transform);

		}

		public Quaternion GetRotation()
		{
			_temp.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward * 10.0f;
			_temp.transform.LookAt(_mainCamera.transform);
			return _temp.transform.rotation;
		}
	}
}
