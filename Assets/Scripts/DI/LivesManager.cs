using Game.UI;
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using static Game.Constants;

namespace Game
{
	public class LivesManager : IStartable, ITickable
	{
		[Inject] private AssetLoader _assetLoader;
		[Inject] private UIController _uiController;

		public event Action<string> OnUpdateTime;
		public event Action<int> OnCountLives;
		public event Action<TypeLives> OnLivesType;

		private bool _isFull = false;
		private float _curTime = 0f;

		private int _second = 0;
		private int _minute = 0;
		private int _startSecond = 0;
		private int _startMinute = 0;

		private int _updateSec;
		private int _curUpdateSec = 0;
		private int _countLives = 0;
		private int _maxCountLives;

		public void Start()
		{
			LivesConfig data = _assetLoader.LoadConfig(Constants.LivesConfig) as LivesConfig;

			_updateSec = data.SecondToAddLife + data.MinuteToAddLife * 60;
			_maxCountLives = data.MaxLives;
			_startSecond = data.SecondToAddLife;
			_startMinute = data.MinuteToAddLife;

			ResetTimer();
			OnCountLives?.Invoke(0);

			_uiController.SetAction(AddOneLive, RefillLifves);
			_uiController.SetAction(RemoveOneLive, UseOneLife);

			ActiveLivesType();
		}

		public void Tick()
		{
			if (_isFull)
			{
				_curTime = 0;
				_curUpdateSec = 0;
				return;
			}

			_curTime += Time.deltaTime;

			if (_curTime > 1)
			{
				_curTime = 0;
				_second--;

				if (_second < 0)
				{
					_second = 59;
					_minute--;

					if (_minute <= 0)
					{
						_minute = 0;
					}
				}

				OnUpdateTime?.Invoke(GetTimeText(_minute) + ":" + GetTimeText(_second));

				_curUpdateSec++;
				if (_curUpdateSec > _updateSec)
				{
					_curUpdateSec = 0;
					ResetTimer();
					_countLives++;
					UpdateLivesCount();
				}
			}
		}

		private void RefillLifves()
		{
			_countLives = _maxCountLives;
			UpdateLivesCount();
		}

		private void UseOneLife()
		{
			if (_countLives >= _maxCountLives)
			{
				ResetTimer();
			}
			_countLives--;
			UpdateLivesCount();
		}

		private void UpdateLivesCount()
		{
			if (_countLives >= _maxCountLives)
			{
				_isFull = true;
				OnUpdateTime?.Invoke("Full");
				OnCountLives?.Invoke(_countLives);
			}
			else
			{
				_isFull = false;
				OnCountLives?.Invoke(_countLives);
			}

			ActiveLivesType();
		}

		private void ResetTimer()
		{
			_second = _startSecond;
			_minute = _startMinute;
			OnUpdateTime?.Invoke(GetTimeText(_startMinute) + ":" + GetTimeText(_startSecond));
		}

		private void ActiveLivesType()
		{
			if (_countLives >= _maxCountLives)
			{
				OnLivesType?.Invoke(TypeLives.MaxLives);
			}
			else if (_countLives == 0)
			{
				OnLivesType?.Invoke(TypeLives.NoLives);
			}
			else
			{
				OnLivesType?.Invoke(TypeLives.NormalLives);
			}
		}

		private string GetTimeText(int time)
		{
			if (time == 0) return "00";
			if (time < 10) return "0" + time.ToString();
			return time.ToString();
		}
	}
}
