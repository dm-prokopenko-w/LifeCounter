using TMPro;
using UnityEngine;
using VContainer;

namespace Game.UI
{
	public class ViewDailyBonus : MonoBehaviour
	{
		[Inject] private DailyBonusController _dailyBonusController;

		[SerializeField] private TMP_Text _text;

		[Inject]
		public void Construct()
		{
			_dailyBonusController.OnDailyBonus += UpdateCounter;
		}

		private void OnDestroy()
		{
			_dailyBonusController.OnDailyBonus -= UpdateCounter;
		}

		private void UpdateCounter(string count) => _text. text = $"You got \r\n {count} coins!";
	}
}
