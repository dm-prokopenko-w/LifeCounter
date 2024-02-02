using UnityEngine;
using UnityEngine.UI;
using VContainer;
using static Game.Constants;

namespace Game.UI
{
	public class OpenPopupBtn : MonoBehaviour
	{
		[Inject] private UIController _uiController;

		[SerializeField] private PopupsID _id;
		[SerializeField] private Button _button;

		[Inject]
		public void Construct()
		{
			_uiController.AddItemUI(OpenPopup, new ItemUI(_button, _id.ToString()));
		}
	}
}
