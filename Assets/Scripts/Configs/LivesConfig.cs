using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "LivesConfig", menuName = "Configs/LivesConfig", order = 0)]
	public class LivesConfig : Config
	{
		[Header("The maximum number of lives.")]
		[Range(1, 10)] public int MaxLives = 5;

		[Header("The number of minutes before life replenishment.")]
		[Range(0, 59)] public int MinuteToAddLife = 0;

		[Header("The number of seconds before life replenishment.")]
		[Range(1, 59)] public int SecondToAddLife = 20;
	}
}