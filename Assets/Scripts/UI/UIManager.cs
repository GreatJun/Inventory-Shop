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
        compareGold = player.gold.currentValue;
    }

    private void Update()
    {
        if (compareGold != player.gold.currentValue)
            GoldUpdate();
    }


    public void StatsUpdate()
    {
        AttackText.text = player.strikingPower.currentValue.ToString();
        DefenseText.text = player.defensivePower.currentValue.ToString();
        HealthText.text = player.healthPoint.currentValue.ToString();
    }

    public void GoldUpdate()
    {
        GoldText.text = player.gold.currentValue.ToString();
    }
}
