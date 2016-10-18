using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class BasementManagerTest
{

	[Test]
	public void StartQuest ()
	{
		BasementQuestManager questManager = new BasementQuestManager ();
		Assert.True (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (10, questManager.GetNumberOfEnemiesAlive());
		Assert.AreEqual (10, questManager.GetCurrentEnemyHealth());

		Player player = new Player ();
		player.Weapon = new WoodenSword ();
		Assert.AreEqual (100, player.GetHealth());

		questManager.Battle (player);

		Assert.True (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (10, questManager.GetNumberOfEnemiesAlive());
		Assert.AreEqual (5, questManager.GetCurrentEnemyHealth());

		questManager.Battle (player);

		Assert.True (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (9, questManager.GetNumberOfEnemiesAlive());
		Assert.AreEqual (10, questManager.GetCurrentEnemyHealth());
		Assert.AreEqual (95, player.GetHealth());
	}
}
