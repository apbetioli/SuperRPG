using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ShopTest {


	[Test]
	public void ItensToSell ()	{
		ShopInventory shop = new ShopInventory ();
		Item item = null;
		shop.putItem(new WoodenSword ());
		shop.ItensToSell.TryGetValue ("Wooden Shield", out item);

		Assert.AreEqual (1, shop.ItensToSell.Count);

		Assert.IsNotNull (item);
		Assert.AreEqual ("Wooden Shield", item.Name());
	}



}
