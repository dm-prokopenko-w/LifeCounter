using static Game.Constants;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
	public class RemoveOneLiveBtn : MonoBehaviour
	{
		[Inject] private UIController _uiController;

		[SerializeField] private Button _button;

		[Inject]
		public void Construct()
		{
			_uiController.AddItemUI(RemoveOneLive, new ItemUI(_button));
		}
	}
}