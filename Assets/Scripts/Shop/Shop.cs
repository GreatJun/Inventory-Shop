using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ItemData FireIceSword;
    public ItemData BoneWeapon;
    public ItemData ClamArmor;
    public ItemData FourClover;

    public Image buyScreen;
    public Image buyFailScreen;

    Inventory inventory;
    PlayerConditions player;

    private void Start()
    {
        inventory = Inventory.instance;
        player = PlayerConditions.instance;
    }

    public void BuySwordItem()
    {
        GoldCheck(FireIceSword);
    }

    public void BuyBoneItem()
    {
        GoldCheck(BoneWeapon);
    }

    public void BuyClamItem()
    {
        GoldCheck(ClamArmor);
    }

    public void BuyCloverItem()
    { 
        GoldCheck(FourClover);
    }

    private void GoldCheck(ItemData item)
    {
        if (player.gold.currentValue < item.value)
        {
            buyFailScreen.gameObject.SetActive(true);
            return;
        }

        player.gold.currentValue -= item.value;
        Debug.Log(player.gold.currentValue);
        inventory.AddItem(item);
        buyScreen.gameObject.SetActive(true);
    }
}
