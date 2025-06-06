using System;
using System.Collections.Generic;

using SpaceSimulation.Core.Fraction;
using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;

namespace SpaceSimulation.Core.Score
{
	public class ScoreControl:IScoreControl
	{
		private IEventBusService _eventBusService;
		public ScoreControl
		(
			 IEventBusService _eventBusService
		)
		{
			this._eventBusService = _eventBusService;
			InitAmountDict();
		}

		private readonly Dictionary<FractionType , float> _amountDict = new();
		private void InitAmountDict()
		{
			foreach( FractionType type in Enum.GetValues(typeof(FractionType)) )
			{
				_amountDict.Add(type , 0.0f);
			}
		}

		public float GetAmount( FractionType type ) => _amountDict[type];

		public void AddScore( FractionType type , float amount )
		{
			_amountDict[type] += amount;
			_eventBusService.Invoke(new LevelScoreChangedSignal(type, GetAmount(type)));
		}
    }
}
