using SpaceSimulation.UI.MainMenu.PopUp;

namespace SpaceSimulation.UI.MainMenu.Pages
{
	public class SelectLevelViewModel:IMainMenuPageViewModel
	{
		private readonly IMainMenuPopUpFactory _mainMenuPopUpFactory;
		public SelectLevelViewModel
		(
			 IMainMenuPopUpFactory _mainMenuPopUpFactory
		)
		{
			this._mainMenuPopUpFactory = _mainMenuPopUpFactory;
		}
		private ISelectLevelView _myView;

		public void OnShowView( ISelectLevelView _myView )
		{
			this._myView = _myView;
			SetHeaderText();
			CreateLevelItems();
		}

		private void SetHeaderText()
		{
			_myView.SetHeaderText("Select level");
		}

		private void CreateLevelItems()
		{
			
		}

		private void OnPressedLevel( int levelIndex )
		{
		
		}



	}
}
