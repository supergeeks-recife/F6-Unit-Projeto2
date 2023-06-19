using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Item/Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemSlot> itemList = new List<ItemSlot>();

    public void AddItem(ItemBase item, int amount)
    {
        bool itemExists = false;

        foreach (ItemSlot slot in itemList)
        {
            if (slot.item == item)
            {
                slot.AddAmount(amount);
                itemExists = true;
                break;
            }
        }

        if (itemExists == false)
        {
            ItemSlot slot = new ItemSlot(item, amount);
            itemList.Add(slot);
        }

    }
}

    [Serializable]
public class ItemSlot
{
    public ItemBase item;
    public int amount;

    public ItemSlot(ItemBase new_item, int new_amount)
    {
        item = new_item;
        amount = new_amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }
}

