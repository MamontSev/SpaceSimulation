using UnityEngine;

namespace SpaceSimulation.Core.Fraction.Control
{
	public interface IFractionBaseControl
	{
		Transform GetFractionBaseTransform( FractionType type );
		void HandOverResources( FractionType type , float amount );
	}
}