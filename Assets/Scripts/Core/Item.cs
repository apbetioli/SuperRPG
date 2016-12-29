using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int damage;
    public int defense;
    public int price;
    /* Quantidade que irá aumentar a health */
    public int hp;
    /* Quantidade que irá aumentar a max health */
    public int maxHp;

    public Sprite sprite;


    public string Stats()
    {
        if (damage > 0)
            return damage.ToString();
        return defense.ToString();
    }
}
