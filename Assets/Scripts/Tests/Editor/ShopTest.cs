using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ShopTest {

	[Test]
	public void BuyItem ()	{	

		Assert.AreEqual (2, GameManager.Shop.ItensToSell.Count);
		Item woodenSword = GameManager.Shop.BuyItem ("Wooden Sword");
		Assert.NotNull (woodenSword);
		Assert.AreEqual ("Wooden Sword", woodenSword.Name());

		Assert.AreEqual (1, GameManager.Shop.ItensToSell.Count);
		Item woodenShield = GameManager.Shop.BuyItem ("Wooden Shield");
		Assert.NotNull (woodenShield);
		Assert.AreEqual ("Wooden Shield", woodenShield.Name());

		Assert.AreEqual (0, GameManager.Shop.ItensToSell.Count);

	}

	[Test]
	public void ItensToSell ()	{
		Assert.AreEqual (2, GameManager.Shop.ItensToSell.Count);

		Assert.AreEqual ("Wooden Sword", GameManager.Shop.ItensToSell[0].Name());
		Assert.AreEqual ("Wooden Shield", GameManager.Shop.ItensToSell[1].Name());

	}
}
