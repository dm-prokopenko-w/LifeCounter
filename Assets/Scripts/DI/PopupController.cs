using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using static Game.Constants;

namespace Game.UI
{
	public class PopupController : IStartable
    {
		[Inject] private UIController _uiController;

		private Dictionary<string, PopupView> _popups = new Dictionary<string, PopupView>();
		private string _currentPopup = "";
		
		public void Start()
		{
			_uiController.SetAction(OpenPopup, (string id) => ActivePopup(id, true));
			_uiController.SetAction(ClosePopup, (string id) => ActivePopup(id, false));
		}

		public void AddPopupView(string id, PopupView popupView) => _popups.Add(id, popupView);

		public void ActivePopup(string id, bool value)
		{
			if (value)
			{
				_currentPopup = id;
			}

			string keyName = value ? ShowKey : HideKey;
			if (_popups.TryGetValue(_currentPopup, out PopupView popup))
			{
				popup.GetAnimator().Play(keyName);
			}
			if (_popups.TryGetValue(PopupsID.Blackout.ToString(), out PopupView blackout))
			{
				blackout.GetAnimator().Play(keyName);
			}
		}
	}
}