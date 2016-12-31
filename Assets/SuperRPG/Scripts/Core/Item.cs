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
    public Color colorText;


    public string Stats()
    {

        if (damage > 0)
        {
            ColorUtility.TryParseHtmlString("#FF2626FF", out colorText);
            return damage.ToString();
        }
        if (defense > 0)
        {
            ColorUtility.TryParseHtmlString("#00CC45FF", out colorText);
            return defense.ToString();
        }
        ColorUtility.TryParseHtmlString("#FFFFFFFF", out colorText);
        return hp.ToString();
    }
}
