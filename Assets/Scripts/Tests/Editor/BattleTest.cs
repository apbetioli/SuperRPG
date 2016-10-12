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

		Character player = new Character ();
		Assert.AreEqual (100, player.GetHealth ());

		player.attack (rat);

		Assert.AreEqual (9, rat.GetHealth ());
		Assert.AreEqual (95, player.GetHealth ());
	}

	[Test]
	public void AttackRatWithWoodenSword() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Character player = new Character ();
		Assert.AreEqual (100, player.GetHealth ());

		player.weapon = new WoodenSword ();
		player.attack (rat);

		Assert.AreEqual (5, rat.GetHealth ());
		Assert.AreEqual (95, player.GetHealth ());

		player.attack (rat);

		Assert.AreEqual (0, rat.GetHealth ());
		Assert.AreEqual (95, player.GetHealth ());
	}

	[Test]
	public void AttackRatWithWoodenSwordAndWoodenShield() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Character player = new Character ();
		Assert.AreEqual (100, player.GetHealth ());

		player.weapon = new WoodenSword ();
		player.shield = new WoodenShield ();
		player.attack (rat);

		Assert.AreEqual (5, rat.GetHealth ());
		Assert.AreEqual (98, player.GetHealth ());
	}


}