using UnityEngine;
using System.Collections.Generic;

public class ShopInventory {
	private static List<Item> itens = new List<Item>();


	public void putItem(Item item){
		itens.Add(item);
	}

	public Dictionary<string, Item> ItensToSell{
		get{ 
			Dictionary<string, Item> dicItens = new Dictionary<string, Item> ();
			foreach(Item item in itens)
				dicItens.Add("Wooden Shield", item);		
			return dicItens;
		}
	}

}
