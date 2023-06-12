using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new food", menuName = "Item/Food")]
public class Food : ItemBase
{
    public float heal;

    private void Awake()
    {
        type = ItemType.food;
    }
}
