using System;
using System.Collections.Generic;

using SpaceSimulation.Core.Drone.Item;
using SpaceSimulation.Core.Drone.Item.Actions;
using SpaceSimulation.Core.Fraction;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.Core.Drone.Factory
{
	public class DroneFactory:MonoBehaviour, IDroneFactory
	{
		private DiContainer _diContainer;
		[Inject]
		private void Construct( DiContainer _diContainer )
		{
			this._diContainer = _diContainer;

			
			InitPrefabDict();
			InitPoolDict();
		}
		[SerializeField]
		private DroneItem _dronItemPrefab;
		[SerializeField]
		private Transform _dronTransform;

		[SerializeField]
		private DroneSkin _skinRedPrefab;
		[SerializeField]
		private DroneSkin _skinBluePrefab;

		private readonly Dictionary<FractionType , DroneSkin> _prefabDict = new();
		private void InitPrefabDict()
		{
			_prefabDict.Add(FractionType.Red , _skinRedPrefab);
			_prefabDict.Add(FractionType.Blue , _skinBluePrefab);
		}

		private readonly Dictionary<FractionType , Queue<DroneItem>> _pool = new();
		private void InitPoolDict()
		{
			foreach( FractionType fractionType in Enum.GetValues(typeof(FractionType)) )
			{
				_pool.Add(fractionType , new());
			}
		}

		public DroneItem Get( FractionType fractionType )
		{
			DroneItem obj;
			if( _pool[fractionType].Count > 0 )
			{
				obj = _pool[fractionType].Dequeue();
			}
			else
			{
				obj = CreateDrone(fractionType);
			}
			return obj;
		}
		public void Return( DroneItem obj )
		{
			_pool[obj.FractionType].Enqueue(obj);
		}

		private DroneItem CreateDrone( FractionType fractionType )
		{
			DroneActions actions = new();
			DroneSkin skin = _diContainer
				.InstantiatePrefabForComponent<DroneSkin>(
				   _prefabDict[fractionType].gameObject ,
				   new object[] { actions });
			DroneItem item = _diContainer
				.InstantiatePrefabForComponent<DroneItem>(
				   _dronItemPrefab.gameObject ,
				   _dronTransform ,
				   new object[] { skin , actions , fractionType });
			return item;
		}

	}
}
