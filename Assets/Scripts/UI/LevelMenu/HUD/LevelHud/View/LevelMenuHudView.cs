using Manmont.Tools;

using SpaceSimulation.UI.MVVM;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public class LevelMenuHudView:BaseHudView<LevelMenuHudViewModel>, ILevelMenuHudView
	{
		private LevelMenuHudViewModel _model;
		protected override void OnBind( LevelMenuHudViewModel model )
		{
			_model = model;
			Init();
		}


		private void Init()
		{
			_model.OnInitView(this);
			RestartButton.onClick.AddListener(_model.OnRestartPressed);
		}

		private void OnDestroy()
		{
			RestartButton.onClick.RemoveAllListeners();
		}

		[SerializeField]
		private Button RestartButton;


		[Header("ScoreText")]
		[SerializeField]
		private TextMeshProUGUI ScoreTextRed;
		[SerializeField]
		private TextMeshProUGUI ScoreTextBlue;
		public void SetScoreText( string redText, string blueText )
		{
			ScoreTextRed.text = redText;
			ScoreTextBlue.text = blueText;
		}

		[SerializeField]
		private HudSliderInt _countRed;
		public HudSliderInt CountRed => _countRed;

		[SerializeField]
		private HudSliderInt _countBlue;
		public HudSliderInt CountBlue => _countBlue;

		[SerializeField]
		private HudSliderFloat _speedRed;
		public HudSliderFloat SpeedRed => _speedRed;

		[SerializeField]
		private HudSliderFloat _speedBlue;
		public HudSliderFloat SpeedBlue => _speedBlue;

		[SerializeField]
		private HudSliderFloat _simulationSpeed;
		public HudSliderFloat SimulationSpeed => _simulationSpeed;




		[SerializeField]
		private TMP_InputField FrequenceText;
		public void InitFrequenceText( float value )
		{
			FrequenceText.text = value.ToString();
		}
		public void OnFrequenceChanged(string s)
		{
			_model.OnFrequenceChanged(s);
		}


		[SerializeField]
		private Toggle NeedPathToggle;
		public void InitNeedViewPath( bool state )
		{
			NeedPathToggle.isOn = state;
		}
		public void OnNeedViewPathToggleChanged( bool state )
		{
			_model.OnNeedViewPathToggleChanged(state);
		}



	}

}
