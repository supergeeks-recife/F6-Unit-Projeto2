using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    quest,
    weapon,
    armor,
    food
}

public class ItemBase : ScriptableObject
{
    public string itemName;
    public string desctiption;
    public float value;
    public ItemType type;
    public GameObject icon;
}
