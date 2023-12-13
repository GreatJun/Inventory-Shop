using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Stats")]
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefenseText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI GoldText;

    private PlayerConditions player;

    private int compareGold;

    private void Start()
    {
        player = PlayerConditions.instance;
    }

    private void Update()
    {
        if (compareGold != player.gold.currentValue)
            GoldUpdate();
    }


    public void StatsUpdate()
    {
        AttackText.text = player.strikingPower.currentValue.ToString() + $" (+<color=red>{player.strikingPower.addValue.ToString()}</color>) ";
        DefenseText.text = player.defensivePower.currentValue.ToString() + $" (+<color=red>{player.defensivePower.addValue.ToString()}</color>) ";
        HealthText.text = player.healthPoint.currentValue.ToString() + $" (+<color=red>{player.healthPoint.addValue.ToString()}</color>) ";
    }

    public void GoldUpdate()
    {
        compareGold = player.gold.currentValue;
        GoldText.text = compareGold.ToString();
    }

    public void OnEquipButton()
    {
        Inventory.instance.EquipItem();
    }

    public void OnReleaseButton()
    {
        Inventory.instance.ReleaseItem();
    }
}
