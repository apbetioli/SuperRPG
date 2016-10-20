using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class HealingTest
{
	[Test]
	public void HealPlayer ()
	{
		Player p = new Player ();
		Assert.AreEqual (100, p.Health);

		p.TakeDamage (100);

		Assert.AreEqual (0, p.Health);

		p.Heal ();

		Assert.AreEqual (2, p.Health);
	}

	[Test]
	public void HealPlayerWithoutDamage ()
	{
		Player p = new Player ();
		Assert.AreEqual (100, p.Health);

		p.Heal ();

		Assert.AreEqual (100, p.Health);
	}

}
