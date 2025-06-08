using DG.Tweening;

using UnityEngine;

namespace SpaceSimulation.Core.Fraction
{
	public class FractionBase:MonoBehaviour
	{
		private Tween _takeResAnim;

		[SerializeField]
		private Transform _goTargetTransform;
		public Transform GoTargetTransform => _goTargetTransform;

		private void Awake()
		{
			_takeResAnim = transform
			.DOPunchPosition(Vector3.up * 0.8f , 0.5f)
			.SetAutoKill(false);
		}

		public void PlayAdedResAnim()
		{
			_takeResAnim.Restart();
		}
	}
}
