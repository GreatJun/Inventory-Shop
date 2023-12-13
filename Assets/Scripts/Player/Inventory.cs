using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot
{
    public ItemData item;
}

public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlot;
    public ItemSlot[] slots;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selcetedItemIndex;
    public Text selectedItemName;
    public Text selectedItemDescription;
    public Image selectedItemIcon;
    public TextMeshProUGUI selectedItemTypeName;
    public TextMeshProUGUI selectedItemTypeValue;
    public Image selectedItemTypeIcon;

    public Image EquipScreen;

    private PlayerConditions player;

    public ItemData testItem;
    public ItemData testItem2;
    public ItemData testItem3;

    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        player = PlayerConditions.instance;
        slots = new ItemSlot[uiSlot.Length];

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlot[i].index = i;
            uiSlot[i].Clear();
        }

        AddItem(testItem);
        AddItem(testItem2);
        AddItem(testItem3);
    }

    public void AddItem(ItemData item)
    {
        ItemSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.item = item;
            UpdateUI();
            return;
        }
    }

    // UI ������Ʈ
    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                uiSlot[i].Set(slots[i]);
            else
                uiSlot[i].Clear();
        }
    }

    // Inventory���� ������ Ŭ���ϸ� ��� ���� ����
    public void SelectItem(int index)   // �������� Ŭ���ϸ� Ȯ��â�� �߰� �ű⿡ ������ ������(�ؽ�Ʈ �̹���) ���� ���;���
    {
        if (slots[index].item == null) 
            return;

        EquipScreen.gameObject.SetActive(true);

        selectedItem = slots[index];
        selcetedItemIndex = index;

        selectedItemName.text = selectedItem.item.itemName;
        selectedItemDescription.text = selectedItem.item.description;
        selectedItemIcon.sprite = selectedItem.item.icon;

        selectedItemTypeName.text = string.Empty;
        selectedItemTypeValue.text = string.Empty;

        selectedItemTypeIcon.color = Color.black;
        for (int i = 0; i < selectedItem.item.stats.Length; i++)
        {
            selectedItemTypeName.text += selectedItem.item.stats[i].type.ToString();
            selectedItemTypeValue.text += selectedItem.item.stats[i].value.ToString();
            selectedItemTypeIcon.sprite = selectedItem.item.stats[i].icon;
        }
    }

    // ������ ������
    public void EquipItem()
    {
        if (uiSlot[selcetedItemIndex].equipIcon.gameObject.activeSelf == true)  // �̹� �����ߴ��� üũ
            return;

        for (int i = 0; i < selectedItem.item.stats.Length; i++)
        {
            if (selectedItem.item.stats[i].type == StatsType.ATK)
            {
                player.strikingPower.SaveAddValue(selectedItem.item.stats[i].value);
                player.strikingPower.Add(player.strikingPower.addValue);
            }
            else if (selectedItem.item.stats[i].type == StatsType.DEF)
            {
                player.defensivePower.SaveAddValue(selectedItem.item.stats[i].value);
                player.defensivePower.Add(player.defensivePower.addValue);
            }
            else if (selectedItem.item.stats[i].type == StatsType.HP)
            {
                player.healthPoint.SaveAddValue(selectedItem.item.stats[i].value);
                player.healthPoint.Add(player.healthPoint.addValue);
            }
        }
        uiSlot[selcetedItemIndex].equipIcon.gameObject.SetActive(true);
        Debug.Log(selcetedItemIndex);
        EquipScreen.gameObject.SetActive(false);
    }

    // seletedItem �ʱ�ȭ �۾�
    public void ClearSeletedItemSettinf()
    {
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemIcon.sprite = null;

        selectedItemTypeName.text = string.Empty;
        selectedItemTypeValue.text = string.Empty;
        selectedItemTypeIcon.sprite = null;
    }


    ItemSlot GetEmptySlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }

        return null;
    }
}
