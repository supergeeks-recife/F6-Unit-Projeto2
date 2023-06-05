using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public Inventory playerInventory;
    public GameObject itemPanel;

    MouseItem mouse = new MouseItem();
    private void Start()
    {
        DrawInventory();
    }


    void AddTriggerEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    void DrawInventory()
    {
        foreach (ItemSlot slot in playerInventory.itemList)
        {
            GameObject new_icon = Instantiate(slot.item.icon, itemPanel.transform);

            new_icon.GetComponentInChildren<TextMeshProUGUI>().text =
                slot.amount.ToString();

            AddTriggerEvent(new_icon, EventTriggerType.PointerEnter,
                delegate { OnEnter(new_icon); });

            AddTriggerEvent(new_icon, EventTriggerType.PointerExit,
                delegate { OnExit(new_icon); });

            AddTriggerEvent(new_icon, EventTriggerType.BeginDrag,
                delegate { OnStartDrag(new_icon); });

            AddTriggerEvent(new_icon, EventTriggerType.Drag,
                delegate { OnDrag(new_icon); });

            AddTriggerEvent(new_icon, EventTriggerType.EndDrag,
                delegate { OnStopDrag(new_icon); });
        }
    }

    public void OnEnter(GameObject obj) //quando o ponteiro passar pelo ícone
    {

    }

    public void OnExit(GameObject obj) //quando o ponteiro sair de cima do ícone
    {

    }

    public void OnStartDrag(GameObject obj) //quando começamos a arrastar o ícone
    {
        GameObject pointerIcon = new GameObject();
        RectTransform rect = pointerIcon.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(32, 32);
        pointerIcon.transform.SetParent(transform);
        Image img = pointerIcon.AddComponent<Image>();
        img.sprite = obj.GetComponent<Image>().sprite;
        img.raycastTarget = false;

        mouse.itemIcon = pointerIcon;
    }

    public void OnDrag(GameObject obj) //quando estamos arrastando o ícone
    {

    }

    public void OnStopDrag(GameObject obj) //quando paramos de arrastar o ícone
    {

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