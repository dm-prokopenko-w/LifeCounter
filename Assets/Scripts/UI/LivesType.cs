using UnityEngine;
using VContainer;
using static Game.Constants;

namespace Game.UI
{
	public class LivesType : MonoBehaviour
	{
		[Inject] private LivesManager _livesManager;

		[SerializeField] private TypeLives _type;

		[Inject]
		public void Construct()
		{
			_livesManager.OnLivesType += UpdateCounter;
		}

		private void OnDestroy()
		{
			_livesManager.OnLivesType -= UpdateCounter;
		}

		private void UpdateCounter(TypeLives type) => gameObject.SetActive(_type == type);
	}
}
