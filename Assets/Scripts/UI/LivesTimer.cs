using TMPro;
using UnityEngine;
using VContainer;

namespace Game.UI
{
	public class LivesTimer : MonoBehaviour
	{
		[Inject] private LivesManager _livesManager;

		[SerializeField] private TMP_Text _text;

		[Inject]
		public void Construct()
		{
			_livesManager.OnUpdateTime += UpdateTimer;
		}

		private void OnDestroy()
		{
			_livesManager.OnUpdateTime -= UpdateTimer;
		}

		private void UpdateTimer(string time)  => _text.text = time;
	}
}
