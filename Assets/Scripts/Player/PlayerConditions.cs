using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Condition
{
    [HideInInspector]
    public int currentValue;
    public int startValue;
    public int addValue;

    public void Add(int newValue)
    {
        currentValue += newValue;
    }

    public void Subtract(int newValue)
    {
        currentValue -= newValue;
    }

    public void SaveAddValue(int newValue)
    {
        addValue += newValue;
    }

    public void SaveSubtractValue(int newValue)
    {
        addValue -= newValue;
    }
}

public class PlayerConditions : MonoBehaviour
{
    public Condition strikingPower;
    public Condition defensivePower;
    public Condition healthPoint;
    public Condition gold;

    public static PlayerConditions instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        strikingPower.currentValue = strikingPower.startValue;
        defensivePower.currentValue = defensivePower.startValue;
        healthPoint.currentValue = healthPoint.startValue;
        gold.currentValue = gold.startValue;
    }
}
