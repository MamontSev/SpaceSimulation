using System.Collections.Generic;

using Manmont.Tools;

using SpaceSimulation.Events;
using SpaceSimulation.Events.Signals;
using SpaceSimulation.Log;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.Core.GameLoop
{
	public class GameLoopService: IGameLoopService, ITickable
	{
		private  IEventBusService _eventBusService;
		private  ILogService _logService;

		public GameLoopService
		( 
			IEventBusService _eventBusService,
			ILogService _logService
		)
		{
			this._eventBusService = _eventBusService;
			this._logService = _logService;
		}

		private State _currState = State.waitForStart;
		public State SelState => _currState;

		public void StartGame()
		{
			_currState = State.playing;
		}

		private int _pauseCounter = 0;
		public void Pause()
		{
			_pauseCounter++;
			if( IsPlaying == true )
			{
				_currState = State.paused;
				_eventBusService.Invoke(new LevelPauseSignal(true));
			}
			_simulationScaleOnPaused = _simulationScale;
			Time.timeScale = 0.0f;
		}
		public void UnPause()
		{
			_pauseCounter--;
			if( _pauseCounter == 0 )
			{
				_currState = State.playing;
				_eventBusService.Invoke(new LevelPauseSignal(false));
			}
			Time.timeScale = _simulationScaleOnPaused;
		}

		public bool IsPlaying => _currState == State.playing;

		public enum State
		{
			waitForStart,
			playing,
			paused
		}

		private float _simulationScale = 1.0f;
		private float _simulationScaleOnPaused;

		public void SetSimulationScale( float value )
		{
			if( value < 0.0f )
			{
				value = 0.0f;
			}
			_simulationScale = value;
			Time.timeScale = _simulationScale;
		}


		private List<IGameLoopUpdate> _gameLoopList1 = new();
		public void Register( IGameLoopUpdate item )
		{
			if( _gameLoopList1.Contains(item) )
			{
				_logService.LogError($"GameLoopControl Register - try add again `{item}`");
				return;
			}
			_gameLoopList1.Add(item);
		}
		public void Unregister( IGameLoopUpdate item )
		{
			if( _gameLoopList1.Contains(item) == false )
			{
				_logService.LogError($"GameLoopControl Unregister - not contains `{item}`");
				return;
			}
			_gameLoopList1.Remove(item);
		}


		public void Tick()
		{
			if( IsPlaying == false )
				return;
			_gameLoopList1.ForEach(x => x.LoopUpdate());
		}
	}
}
