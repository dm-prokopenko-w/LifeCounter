using TMPro;
using UnityEngine;
using VContainer;

namespace Game.UI
{
	public class LivesCounter : MonoBehaviour
	{
		[Inject] private LivesManager _livesManager;

		[SerializeField] private TMP_Text _text;

		[Inject]
		public void Construct()
		{
			_livesManager.OnCountLives += UpdateCounter;
		}

		private void OnDestroy()
		{
			_livesManager.OnCountLives -= UpdateCounter;
		}

		private void UpdateCounter(int count) => _text.text = count.ToString();
	}
}