using SpaceSimulation.UI.MVVM;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace SpaceSimulation.UI.MainMenu.HUD
{
	public interface IMainMenuHudOverlayView
	{
		void SetHeaderText( string s );
	}
	public class MainMenuHudOverlayView:BaseHudView<MainMenuHudOverlayViewModel>, IMainMenuHudOverlayView
	{
		private MainMenuHudOverlayViewModel _model;
		protected override void OnBind( MainMenuHudOverlayViewModel model )
		{
			_model = model;
			_model.OnInitView(this);
			StartGame.onClick.AddListener(_model.OnStartGamePressed);
		}

		[Header("HedaerText")]
		[SerializeField]
		private TextMeshProUGUI HedaerText;
		public void SetHeaderText( string s )
		{
			HedaerText.text = s;
		}

		[Header("StartGame Button")]
		[SerializeField]
		private Button StartGame;
	}
}
