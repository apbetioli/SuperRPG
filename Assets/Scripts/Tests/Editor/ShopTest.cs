using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ShopTest {

	[Test]
	public void BuyItem ()	{	
		Shop shop = new Shop ();

		Assert.AreEqual (2, shop.ItensToSell.Count);

		Item woodenSword = shop.BuyItem ("Wooden Sword");
		Assert.AreEqual ("Wooden Sword", woodenSword.Name());
		Assert.AreEqual (1, shop.ItensToSell.Count);

		Item woodenShield = shop.BuyItem ("Wooden Shield");
		Assert.AreEqual ("Wooden Shield", woodenShield.Name());
		Assert.AreEqual (0, shop.ItensToSell.Count);
	}

	[Test]
	public void ItensToSell ()	{
		Shop shop = new Shop ();

		Assert.AreEqual (2, shop.ItensToSell.Count);

		Assert.AreEqual ("Wooden Sword", shop.ItensToSell[0].Name());
		Assert.AreEqual ("Wooden Shield", shop.ItensToSell[1].Name());
	}

	[Test]
	[ExpectedException( typeof( Exception ), ExpectedMessage="Item not found: Espada" )]
	public void BuyUnknownItem() {
		Shop shop = new Shop ();

		shop.BuyItem ("Espada");
	}

}
