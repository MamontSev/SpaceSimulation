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
		}





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
		private HudSlider _countRed;
		public HudSlider CountRed => _countRed;

		[SerializeField]
		private HudSlider _countBlue;
		public HudSlider CountBlue => _countBlue;

		[SerializeField]
		private HudSlider _speedRed;
		public HudSlider SpeedRed => _speedRed;

		[SerializeField]
		private HudSlider _speedBlue;
		public HudSlider SpeedBlue => _speedBlue;

		[SerializeField]
		private HudSlider _simulationSpeed;
		public HudSlider SimulationSpeed => _simulationSpeed;




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
