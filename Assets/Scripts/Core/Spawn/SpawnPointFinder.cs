
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

using Zenject;

namespace SpaceSimulation.Core.Spawn
{
	public class SpawnPointFinder:MonoBehaviour, ISpawnPointFinder
	{
		[SerializeField]
		private GameObject _plane;

		public Vector3 GetSpawnPosition()
		{
			List<Vector3> VerticeList = new List<Vector3>(_plane.GetComponent<MeshFilter>().sharedMesh.vertices);
			Vector3 leftTop = _plane.transform.TransformPoint(VerticeList[0]);
			Vector3 rightTop = _plane.transform.TransformPoint(VerticeList[10]);
			Vector3 leftBottom = _plane.transform.TransformPoint(VerticeList[110]);
			Vector3 rightBottom = _plane.transform.TransformPoint(VerticeList[120]);
			Vector3 XAxis = rightTop - leftTop;
			Vector3 ZAxis = leftBottom - leftTop;
			Vector3 randomPos = leftTop + XAxis * Random.value + ZAxis * Random.value;

			if( NavMesh.SamplePosition(randomPos , out NavMeshHit myNavHit , 100 , -1) )
			{
				randomPos = myNavHit.position;
			}
			return randomPos + _plane.transform.up * 0.5f;
		}

	}
}
