using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public Image equipIcon;
    private ItemSlot currentSlot;

    public int index;
    public bool equipped;

    private void OnEnable()
    {
        equipIcon.color = Color.red;
        equipIcon.enabled = equipped;
    }

    public void Set(ItemSlot slot)
    {
        currentSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
    }

    public void Clear()
    {
        currentSlot = null;
        icon.gameObject.SetActive(false);
    }

    public void OnItemClickButton()
    {
        Inventory.instance.SelectItem(index);
    }

    public void OnCloseEquipButton()
    {
        Inventory.instance.ClearSeletedItemSettinf();
        Inventory.instance.EquipScreen.gameObject.SetActive(false);
    }
}
