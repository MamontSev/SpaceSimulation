namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public interface ILevelMenuHudView
	{
		HudSliderInt CountRed
		{
			get;
		}
		HudSliderInt CountBlue
		{
			get;
		}
		HudSliderFloat SpeedRed
		{
			get;
		}
		HudSliderFloat SpeedBlue
		{
			get;
		}
		HudSliderFloat SimulationSpeed
		{
			get;
		}

		void InitFrequenceText( float value );
		void InitNeedViewPath( bool state );
		void SetScoreText( string redText , string blueText );
	}

}
