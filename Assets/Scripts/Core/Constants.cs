using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public static class Constants
	{
		public enum PopupsID
		{
			None,
			Blackout,
			LivesPopup,
			DailyBonusPopup
		}

		public enum TypeLives
		{
			None,
			NormalLives,
			NoLives,
			MaxLives
		}

		public const string ConfigsPath = "Configs/";

		public const string LivesConfig = "LivesConfig";

		public const string OpenPopup = "OpenPopupBtn";
		public const string ClosePopup = "ClosePopupBtn";
		public const string AddOneLive = "AddOneLiveBtn";
		public const string RemoveOneLive = "RemoveOneLiveBtn";

		public const string ShowKey = "Show";
		public const string HideKey = "Hide";
	}
}
