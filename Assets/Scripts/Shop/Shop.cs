using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ItemData FireIceSword;
    public ItemData BoneWeapon;
    public ItemData ClamArmor;
    public ItemData FourClover;

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
        inventory.AddItem(FireIceSword);
    }

    public void BuyBoneItem()
    {
        GoldCheck(BoneWeapon);
        inventory.AddItem(BoneWeapon);
    }

    public void BuyClamItem()
    {
        GoldCheck(FourClover);
        inventory.AddItem(ClamArmor);
    }

    public void BuyCloverItem()
    { 
        GoldCheck(FourClover);
        inventory.AddItem(FourClover);
    }

    private void GoldCheck(ItemData item)
    {
        if (player.gold.currentValue < item.value)
            return;

        player.gold.currentValue -= item.value;
    }
}
