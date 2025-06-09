using System;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public interface IHudSliderFloat
	{									 
		void Init( float min , float max , float startValue , Action<float> onValueChaged );
	}
}