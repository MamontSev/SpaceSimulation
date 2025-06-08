namespace SpaceSimulation.Core.GameLoop
{
	public interface IGameLoopService
	{
		bool IsPlaying
		{
			get;
		}
		GameLoopService.State SelState
		{
			get;
		}

		void Pause();
		void Register( IGameLoopUpdate item );
		void SetSimulationScale( float value );
		void StartGame();
		void UnPause();
		void Unregister( IGameLoopUpdate item );
	}
}
