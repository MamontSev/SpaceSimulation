using System;

using SpaceSimulation.Events.Signals;

namespace SpaceSimulation.Events
{
	public interface IEventBusService
	{
		void Subscribe<T>( Action<T> callback ) where T : IEventBusSignal;
		void Invoke<T>( T signal ) where T : IEventBusSignal;
		void Unsubscribe<T>( Action<T> callback ) where T : IEventBusSignal; 
	}
}
