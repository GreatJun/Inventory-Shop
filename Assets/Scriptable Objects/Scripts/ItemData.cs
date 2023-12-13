using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Waepon,
    Armor,
    Accessories
}

public enum StatsType
{
    ATK,
    DEF,
    HP
}

[System.Serializable]
public class ItemDataStat
{
    public StatsType type;
    public Sprite icon;
    public int value;
}

[CreateAssetMenu(fileName = "Item", menuName = ("Creat Item"))]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("ItemStats")]
    public ItemDataStat[] stats;
}
