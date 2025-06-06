using SpaceSimulation.UI.General.Loading;

using UnityEngine;

using Zenject;

namespace SpaceSimulation.EntryPoint
{
	public class MenuEntryPoint:MonoBehaviour
	{
		private ILoadingPanel _loadingPanel;
		[Inject]
		private void Construct
		(
			ILoadingPanel _loadingPanel
		)
		{
			this._loadingPanel = _loadingPanel;
		}
		private void Start()
		{
			_loadingPanel.Hide();

		}
	}
}



