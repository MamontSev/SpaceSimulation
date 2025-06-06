using SpaceSimulation.UI.General.Loading;
using SpaceSimulation.UI.MainMenu.Pages;
using SpaceSimulation.UI.MainMenu.PopUp;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.EntryPoint
{
	public class MenuEntryPoint:MonoBehaviour
	{
		private ILoadingPanel _loadingPanel;
		private IMainMenuPagesFactory _mainMenuPagesFactory;
		private IMainMenuPopUpFactory _mainMenuPopUpFactory;
		[Inject]
		private void Construct
		(
			ILoadingPanel _loadingPanel ,
			IMainMenuPagesFactory _mainMenuPagesFactory,
			IMainMenuPopUpFactory _mainMenuPopUpFactory 
		)
		{
			this._loadingPanel = _loadingPanel;
			this._mainMenuPagesFactory = _mainMenuPagesFactory;
			this._mainMenuPopUpFactory = _mainMenuPopUpFactory;
		}
		private void Start()
		{
			_loadingPanel.Hide();

		}
	}
}



