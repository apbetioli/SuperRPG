using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class EnemyManagerTest{

	[Test]
	public void CreateEnemies() {
		EnemyManager manager = new EnemyManager(typeof(Rat), 1);
		Assert.IsNotNull (manager.GetEnemies());
		Assert.AreEqual (1, manager.GetEnemies().Count);
		Assert.IsNotNull (manager.GetNextEnemy());

		Assert.IsTrue (manager.KillEnemy(manager.GetNextEnemy()));

		Assert.IsNotNull (manager.GetEnemies());
		Assert.AreEqual (0, manager.GetEnemies().Count);
		Assert.IsNull (manager.GetNextEnemy());
	}
}


