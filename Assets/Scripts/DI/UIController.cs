using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
	public class UIController
	{
		private Dictionary<string, List<ItemUI>> _items = new Dictionary<string, List<ItemUI>>();

		public void AddItemUI(string id, ItemUI item)
		{
			if (_items.TryGetValue(id, out List<ItemUI> items))
			{
				items.Add(item);
			}
			else
			{
				List<ItemUI> newItems = new List<ItemUI> { item };
				_items.Add(id, newItems);
			}
		}

		public void SetAction(string id, UnityAction<string> func)
		{
			if (_items.TryGetValue(id, out List<ItemUI> items))
			{
				foreach (var item in items)
				{
					if (item.Btn == null) continue;
					item.Btn.onClick.AddListener(() => func(item.Parm));
				}
			}
		}

		public void SetAction(string id, UnityAction func)
		{
			if (_items.TryGetValue(id, out List<ItemUI> items))
			{
				foreach (var item in items)
				{
					if (item.Btn == null) continue;
					item.Btn.onClick.AddListener(func);
				}
			}
		}
	}

	public class ItemUI
	{
		public Button Btn;
		public string Parm;

		public ItemUI(Button btn)
		{
			Btn = btn;
		}

		public ItemUI(Button btn, string parm)
		{
			Btn = btn;
			Parm = parm;
		}
	}
}
