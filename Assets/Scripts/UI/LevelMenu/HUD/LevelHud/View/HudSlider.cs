using System;

using Manmont.Tools;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public class HudSlider:MonoBehaviour, IHudSlider
	{
		[SerializeField]
		private Slider ValueSlider;
		[SerializeField]
		private TextMeshProUGUI ValueText;

		private Action<float> _onValueChaged;
		public void Init( float min , float max , float startValue , Action<float> onValueChaged )
		{
			_onValueChaged = onValueChaged;
			ValueSlider.minValue = min;
			ValueSlider.maxValue = max;
			SetValue(startValue);
		}
		public void SetValue( float value )
		{
			ValueSlider.value = value;
			ValueText.text = value.DigitToString();
		}

		public void ValueChanged( float value )
		{
			_onValueChaged?.Invoke(value);
		}
	}

}
