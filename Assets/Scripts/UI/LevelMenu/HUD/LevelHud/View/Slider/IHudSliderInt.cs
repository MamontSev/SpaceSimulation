using System;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public interface IHudSliderInt
	{
		void Init( int min , int max , int startValue , Action<int> onValueChaged );
	}
}