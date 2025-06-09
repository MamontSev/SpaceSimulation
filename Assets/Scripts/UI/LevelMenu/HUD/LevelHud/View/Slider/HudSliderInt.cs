using System;

using Manmont.Tools;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace SpaceSimulation.UI.LevelMenu.HUD.LevelHud
{
	public class HudSliderInt:MonoBehaviour, IHudSliderInt
	{
		[SerializeField]
		private Slider ValueSlider;
		[SerializeField]
		private TextMeshProUGUI ValueText;

		private Action<int> _onValueChaged = null;
		public void Init( int min , int max , int startValue , Action<int> onValueChaged )
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
			int intVal = Mathf.RoundToInt(value);
			ValueText.text = intVal.DigitToString();
			_onValueChaged?.Invoke(intVal);
		}

		private void OnDestroy()
		{
			ValueSlider.onValueChanged.RemoveAllListeners();
		}

	}

}
