using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "DailyBonusConfig", menuName = "Configs/DailyBonusConfig", order = 0)]
	public class DailyBonusConfig : Config
	{
		[Header("The number of coins provided on the first day of the season.")]
		[Range(0, 100)] public int CountCoinInFirstDay = 2;
		
		[Header("The number of coins provided on the second day of the season.")]
		[Range(0, 100)] public int CountCoinInSecondDay = 3;
		
		[Header("The percentage of coins provided for the day before yesterday.")]
		[Range(0, 100)] public int PercentageBeyondPreviousDay = 100;
		
		[Header("The percentage of coins provided for the previous day.")]
		[Range(0, 100)] public int PercentagePreviousDay = 60;
	}
}
