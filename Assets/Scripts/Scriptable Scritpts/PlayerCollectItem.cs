using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollectItem : MonoBehaviour
{
    public Inventory inventory;

    public UnityEvent OnItemCollect;

    InventoryHUD hud;

    private void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<InventoryHUD>();
        OnItemCollect.AddListener(hud.UpdateInventory);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item collectedItem = collision.GetComponent<Item>();

        if (collectedItem)
        {
            inventory.AddItem(collectedItem.itemData, 1);
            OnItemCollect.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
