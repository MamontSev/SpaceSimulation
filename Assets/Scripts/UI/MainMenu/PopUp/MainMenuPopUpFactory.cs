using SpaceSimulation.Log;
using SpaceSimulation.UI.General.PopUp;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.UI.MainMenu.PopUp
{
	public interface IMainMenuPopUpFactory:IBasePopUpFactory
	{
	}
	public class MainMenuPopUpFactory:BasePopUpFactory, IMainMenuPopUpFactory
	{
		[Inject]
		private void Construct(
			ILogService _logService ,
			DiContainer _diContainer
		)
		{
			this._logService = _logService;
			this._diContainer = _diContainer;
		}

		protected sealed override void InitPrefabs()
		{
			_prefabDict.Add(typeof(StartLevelViewModel) , _startLevelView.gameObject);
		}

		[SerializeField]
		private StartLevelView _startLevelView;


	}
}
