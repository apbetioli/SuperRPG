using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class BattleTest {

	[Test]
	public void AttackRatWithFist() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.GetHealth ());

		player.attack (rat);

		Assert.AreEqual (9, rat.GetHealth ());
		Assert.AreEqual (95, player.GetHealth ());
	}

	[Test]
	public void AttackOctopusKingWithFist() {

		Enemy octopusKing = new OctopusKing ();
		Assert.AreEqual (380, octopusKing.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.GetHealth ());

		for(int i=0; i<7; i++)
			player.attack (octopusKing);

		Assert.AreEqual (373, octopusKing.GetHealth ());
		Assert.AreEqual (-12, player.GetHealth ());
		Assert.True (player.IsDead ());

	}

	[Test]
	public void AttackRatWithWoodenSword() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.GetHealth ());

		player.Weapon = new WoodenSword ();
		player.attack (rat);

		Assert.AreEqual (5, rat.GetHealth ());
		Assert.AreEqual (95, player.GetHealth ());

		player.attack (rat);

		Assert.AreEqual (0, rat.GetHealth ());
		Assert.True ( rat.IsDead());
		Assert.AreEqual (95, player.GetHealth ());
	}

	[Test]
	public void AttackRatWithWoodenSwordAndWoodenShield() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.GetHealth ());

		player.Weapon = new WoodenSword ();
		player.Shield = new WoodenShield ();
		player.attack (rat);

		Assert.AreEqual (5, rat.GetHealth ());
		Assert.AreEqual (98, player.GetHealth ());

		player.attack (rat);

		Assert.AreEqual (0, rat.GetHealth ());
		Assert.True ( rat.IsDead());
		Assert.AreEqual (98, player.GetHealth ());
	}


}