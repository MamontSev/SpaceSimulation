using System;

namespace SpaceSimulation.UI.MVVM
{
	public interface IPopUpView:IView
	{
		void Hide();
		void Show(Action<IPopUpView> OnCloze);
	}
}
