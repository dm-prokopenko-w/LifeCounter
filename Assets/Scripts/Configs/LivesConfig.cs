using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "LivesConfig", menuName = "Configs/LivesConfig", order = 0)]
	public class LivesConfig : Config
	{
		[Range(1, 10)] public int MaxLives = 5;
		[Range(0, 59)] public int MinuteToAddLife = 0;
		[Range(0, 59)] public int SecondToAddLife = 20;

		public bool IsCurrentDay;

	}
}
