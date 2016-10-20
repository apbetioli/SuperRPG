using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerTest {

	[Test]
	public void AttackRatWithFist() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.Health);

		player.Attack (rat);

		Assert.AreEqual (9, rat.GetHealth ());
		Assert.AreEqual (95, player.Health );
	}

	[Test]
	public void AttackOctopusKingWithFist() {

		Enemy octopusKing = new OctopusKing ();
		Assert.AreEqual (380, octopusKing.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.Health);

		for(int i=0; i<7; i++)
			player.Attack (octopusKing);

		Assert.AreEqual (373, octopusKing.GetHealth ());
		Assert.AreEqual (0, player.Health);
		Assert.True (player.IsDead ());
	}

	[Test]
	[ExpectedException( typeof( Exception ), ExpectedMessage="You should not try to attack when you're dead." )]
	public void PlayerKilledTryingToAttack ()
	{
		Enemy octopusKing = new OctopusKing ();
		Assert.AreEqual (380, octopusKing.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.Health);

		for(int i=0; i<7; i++)
			player.Attack (octopusKing);

		Assert.AreEqual (373, octopusKing.GetHealth ());
		Assert.AreEqual (0, player.Health);
		Assert.True (player.IsDead ());

		player.Attack (octopusKing);
	}

	[Test]
	public void AttackRatWithWoodenSword() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.Health);

		player.Weapon = new WoodenSword ();
		player.Attack (rat);

		Assert.AreEqual (5, rat.GetHealth ());
		Assert.AreEqual (95, player.Health);

		player.Attack (rat);

		Assert.AreEqual (0, rat.GetHealth ());
		Assert.True ( rat.IsDead());
		Assert.AreEqual (95, player.Health);
	}

	[Test]
	public void AttackRatWithWoodenSwordAndWoodenShield() {

		Enemy rat = new Rat ();
		Assert.AreEqual (10, rat.GetHealth());

		Player player = new Player ();
		Assert.AreEqual (100, player.Health);

		player.Weapon = new WoodenSword ();
		player.Shield = new WoodenShield ();
		player.Attack (rat);

		Assert.AreEqual (5, rat.GetHealth ());
		Assert.AreEqual (98, player.Health);

		player.Attack (rat);

		Assert.AreEqual (0, rat.GetHealth ());
		Assert.True ( rat.IsDead());
		Assert.AreEqual (98, player.Health);
	}


}