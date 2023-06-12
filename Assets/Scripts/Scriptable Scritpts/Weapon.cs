using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "Item/Weapon")]
public class Weapon : ItemBase
{
    public float attackBonus;
    public float durability;
    private void Awake()
    {
        type = ItemType.weapon;
    }
}
