using static Game.Constants;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
	public class AddOneLiveBtn : MonoBehaviour
	{
		[Inject] private UIController _uiController;

		[SerializeField] private Button _button;

		[Inject]
		public void Construct()
		{
			_uiController.AddItemUI(AddOneLive, new ItemUI(_button));
		}
	}
}