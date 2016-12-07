using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;
public class ItemDatabase : MonoBehaviour
{

    private List<ItemDTO> database = new List<ItemDTO>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
    }

    public ItemDTO FetchItemDTOByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new ItemDTO(
                (int)itemData[i]["id"],
                itemData[i]["title"].ToString(),
                (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["power"],
                (int)itemData[i]["stats"]["defence"],
                itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"],
                (int)itemData[i]["rarity"],
                itemData[i]["slug"].ToString()
                ));
        }
    }
}

public class ItemDTO
{

    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public ItemDTO(int id, string title, int value, int power, int defence, string description, bool stackable, int rarity, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Power = power;
        this.Defence = defence;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public ItemDTO()
    {
        this.ID = -1;
    }
}