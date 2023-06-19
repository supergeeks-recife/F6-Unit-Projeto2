using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

public class PlayerCollectItem : NetworkBehaviour
{
    public Inventory inventory;

    public UnityEvent OnItemCollect;

    public InventoryHud hud;

    private void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<InventoryHud>();
        OnItemCollect.AddListener(hud.UpdateInventory);
    }

    void Update()
    {
        if(isLocalPlayer)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject inventoryPanel =
                    hud.transform.GetChild(0).gameObject;

                inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item collectedItem = collision.GetComponent<Item>();

        if (collectedItem)
        {
            if (isLocalPlayer)
            {
                inventory.AddItem(collectedItem.itemData, 1);
                OnItemCollect.Invoke();
            }

            Destroy(collision.gameObject);
        }
    }
}