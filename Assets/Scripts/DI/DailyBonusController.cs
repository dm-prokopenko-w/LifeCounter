using Game.UI;
using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using static Game.Constants;

namespace Game
{
	public class DailyBonusController : IStartable
	{
		[Inject] private AssetLoader _assetLoader;
		[Inject] private PopupController _popupController;

		public event Action<string> OnDailyBonus;

		public void Start()
		{
			DailyBonusConfig data = _assetLoader.LoadConfig(Constants.DailyBonusConfig) as DailyBonusConfig;

			CalculateDay(
				data.PercentageBeyondPreviousDay,
				data.PercentagePreviousDay,
				data.CountCoinInFirstDay,
				data.CountCoinInSecondDay);
		}

		private void CalculateDay(int percentageBeyondPreviousDay, int percentagePreviousDay, int firstDay, int secondDay)
		{
			decimal reward = 0;
			int countDays;

			switch (DateTime.Today.Month)
			{
				case 12:
					if (DateTime.Today.Day == 1)
					{
						reward = firstDay;
						OnDailyBonus?.Invoke(firstDay.ToString());
					}
					else if (DateTime.Today.Day == 2)
					{
						reward = secondDay;
						OnDailyBonus?.Invoke(secondDay.ToString());
					}
					else
					{
						reward = CalculateRewards(DateTime.Today.Day, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
						OnDailyBonus?.Invoke(reward.ToString());
					}
					break;
				case 1:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year - 1, 12) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
				case 2:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year - 1, 12) + DateTime.DaysInMonth(DateTime.Today.Year, 1) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
				case 3:
					if (DateTime.Today.Day == 1)
					{
						reward = firstDay;
						OnDailyBonus?.Invoke(firstDay.ToString());
					}
					else if (DateTime.Today.Day == 2)
					{
						reward = secondDay;
						OnDailyBonus?.Invoke(secondDay.ToString());
					}
					else
					{
						reward = CalculateRewards(DateTime.Today.Day, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
						OnDailyBonus?.Invoke(reward.ToString());
					}
					break;
				case 4:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year, 3) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
				case 5:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year, 3) + DateTime.DaysInMonth(DateTime.Today.Year, 4) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
				case 6:
					if (DateTime.Today.Day == 1)
					{
						reward = firstDay;
						OnDailyBonus?.Invoke(firstDay.ToString());
					}
					else if (DateTime.Today.Day == 2)
					{
						reward = secondDay;
						OnDailyBonus?.Invoke(secondDay.ToString());
					}
					else
					{
						reward = CalculateRewards(DateTime.Today.Day, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
						OnDailyBonus?.Invoke(reward.ToString());
					}
					break;
				case 7:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year, 6) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
				case 8:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year, 6) + DateTime.DaysInMonth(DateTime.Today.Year, 7) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
				case 9:
					if (DateTime.Today.Day == 1)
					{
						reward = firstDay;
						OnDailyBonus?.Invoke(firstDay.ToString());
					}
					else if (DateTime.Today.Day == 2)
					{
						reward = secondDay;
						OnDailyBonus?.Invoke(secondDay.ToString());
					}
					else
					{
						reward = CalculateRewards(DateTime.Today.Day, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
						OnDailyBonus?.Invoke(reward.ToString());
					}
					break;
				case 10:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year, 9) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
				case 11:
					countDays = DateTime.DaysInMonth(DateTime.Today.Year, 9) + DateTime.DaysInMonth(DateTime.Today.Year, 10) + DateTime.Today.Day;
					reward = CalculateRewards(countDays, firstDay, secondDay, percentageBeyondPreviousDay, percentagePreviousDay);
					OnDailyBonus?.Invoke(reward.ToString());
					break;
			}

			if (reward > 0)
			{
				_popupController.ActivePopup(PopupsID.DailyBonusPopup.ToString(), true);
			}
		}

		private decimal CalculateRewards(int countDays, decimal firstDay, decimal secondDay, int percentageBeyondPreviousDay, int percentagePreviousDay)
		{
			List<decimal> rewards = new List<decimal>();
			decimal reward;
			rewards.Add(firstDay);
			rewards.Add(secondDay);

			for (int i = 2; i < countDays; i++)
			{
				reward = GetCoins(percentageBeyondPreviousDay, rewards[i - 2]) + GetCoins(percentagePreviousDay, rewards[i - 1]);
				reward = decimal.Round(reward, 0, MidpointRounding.AwayFromZero);
				rewards.Add(reward);
			}

			return rewards[rewards.Count - 1];
		}

		private decimal GetCoins(int coef, decimal coins) => ((coins * coef) / 100m);
	}
}
