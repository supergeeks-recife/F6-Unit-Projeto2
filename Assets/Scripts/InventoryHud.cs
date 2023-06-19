using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class InventoryHud : MonoBehaviour
{
    public Inventory playerInventory;
    public GameObject itemPanel;

    private void Start()
    {
        DrawInventory();
    }

    void DrawInventory()
    {
        foreach (ItemSlot slot in playerInventory.itemList)
        {
            GameObject new_icon = Instantiate(slot.item.icon, itemPanel.transform);
            new_icon.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString();
        }
    }

    public void UpdateInventory()
    {
        foreach (Transform child in itemPanel.transform)
        {
            Destroy(child.gameObject);
        }

        DrawInventory();
    }
}
