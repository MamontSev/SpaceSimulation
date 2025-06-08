using System;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public interface IHudSlider
	{
		void Init( float min , float max , float startValue , Action<float> onValueChaged );
		void SetValue( float value );
	}
}