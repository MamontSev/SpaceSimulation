using System.Collections.Generic;

using SpaceSimulation.Core.Score;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.Core.Fraction.Control
{
	public class FractionBaseControl:MonoBehaviour, IFractionBaseControl
	{
		private IScoreControl _scoreControl;
		[Inject]
		private void Construct( IScoreControl _scoreControl )
		{
			this._scoreControl = _scoreControl;
		}
		[SerializeField]
		private FractionBase _baseRed;
		[SerializeField]
		private FractionBase _baseBlue;

		private void Awake()
		{
			_baseDict.Add(FractionType.Red , _baseRed);
			_baseDict.Add(FractionType.Blue , _baseBlue);
		}

		private readonly Dictionary<FractionType , FractionBase> _baseDict = new();

		public Transform GetFractionBaseTransform( FractionType type ) => _baseDict[type].GoTargetTransform;

		public void HandOverResources( FractionType type , float amount )
		{
			_baseDict[type].PlayAdedResAnim();
			_scoreControl.AddScore(type , amount);

		}
	}
}