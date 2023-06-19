using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Item/Food")]
public class Food : ItemBase
{
    public float lifeHeal;
    
    private void Awake()
    {
        type = ItemType.food;
    }
}
