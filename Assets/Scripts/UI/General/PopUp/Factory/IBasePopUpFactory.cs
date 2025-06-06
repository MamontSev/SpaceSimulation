using SpaceSimulation.UI.MVVM;

namespace SpaceSimulation.UI.General.PopUp
{
	public interface IBasePopUpFactory
	{
		void Show<T>( T vm ) where T : IPopUpViewModel;
	}
}
