using DG.Tweening;

using UnityEngine;

namespace SpaceSimulation.Core.Fraction
{
	public class FractionBase:MonoBehaviour
	{
		private Tween _takeResAnim;

		private void Awake()
		{
			_takeResAnim = transform
			.DOPunchPosition(Vector3.forward * 0.3f , 0.5f)
			.SetAutoKill(false);
		}

		public void PlayAdedResAnim()
		{
			_takeResAnim.Restart();
		}
	}
}
