using System;

using Manmont.Tools;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public class HudSliderFloat:MonoBehaviour, IHudSliderFloat
	{
		[SerializeField]
		private Slider ValueSlider;
		[SerializeField]
		private TextMeshProUGUI ValueText;

		private Action<float> _onValueChaged = null;
		public void Init( float min , float max , float startValue, Action<float> onValueChaged )
		{
			_onValueChaged = onValueChaged;
			ValueSlider.minValue = min;
			ValueSlider.maxValue = max;
			ValueSlider.value = startValue;
			ValueText.text = startValue.DigitToString();
			ValueSlider.onValueChanged.AddListener(ValueChanged);
		}

		public void ValueChanged( float value )
		{
			ValueText.text = value.DigitToString();
			_onValueChaged?.Invoke(value);
		}

		private void OnDestroy()
		{
			ValueSlider.onValueChanged.RemoveAllListeners();
		}

	}

}
