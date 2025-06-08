namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public interface ILevelMenuHudView
	{
		HudSlider CountRed
		{
			get;
		}
		HudSlider CountBlue
		{
			get;
		}
		HudSlider SpeedRed
		{
			get;
		}
		HudSlider SpeedBlue
		{
			get;
		}
		HudSlider SimulationSpeed
		{
			get;
		}

		void InitFrequenceText( float value );
		void InitNeedViewPath( bool state );
		void SetScoreText( string redText , string blueText );
	}

}
