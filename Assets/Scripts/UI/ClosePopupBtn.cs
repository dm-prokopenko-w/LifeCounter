using UnityEngine;
using UnityEngine.UI;
using VContainer;
using static Game.Constants;

namespace Game.UI
{
	public class ClosePopupBtn : MonoBehaviour
	{
		[Inject] private UIController _uiController;

		[SerializeField] private Button _button;

		[Inject]
		public void Construct()
		{
			_uiController.AddItemUI(ClosePopup, new ItemUI(_button));
		}
	}
}