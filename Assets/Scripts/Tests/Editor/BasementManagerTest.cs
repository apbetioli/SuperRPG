using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class BasementManagerTest
{

	[Test]
	public void SucessQuest ()
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

		for(int i=0; i<19; i++)
			questManager.Battle (player);

		Assert.False (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (0, questManager.GetNumberOfEnemiesAlive());	
		Assert.AreEqual (50, player.GetHealth());

		questManager.Battle (player);

		Assert.False (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (0, questManager.GetNumberOfEnemiesAlive());	
		Assert.AreEqual (50, player.GetHealth());
	}

	[Test]
	public void FailQuest ()
	{
		BasementQuestManager questManager = new BasementQuestManager ();
		Assert.True (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (10, questManager.GetNumberOfEnemiesAlive());
		Assert.AreEqual (10, questManager.GetCurrentEnemyHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.GetHealth());

		questManager.Battle (player);

		Assert.True (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (10, questManager.GetNumberOfEnemiesAlive());
		Assert.AreEqual (9, questManager.GetCurrentEnemyHealth());

		for(int i=0; i<21; i++)
			questManager.Battle (player);

		Assert.True (questManager.IsThereEnemiesAlive ());
		Assert.AreEqual (8, questManager.GetNumberOfEnemiesAlive());	
		Assert.AreEqual  (0, player.GetHealth());
		Assert.True (player.IsDead ());
	}
}
