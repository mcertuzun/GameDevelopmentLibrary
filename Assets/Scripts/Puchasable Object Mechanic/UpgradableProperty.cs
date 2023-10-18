using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Obvious.Soap;

public class UpgradableProperty : UpgradablePropertyBase, ICanBeBought
{
    public Action<UpgradableProperty> OnLevelUp;
    [SerializeField] UnityEvent onLevelUp;
    [SerializeField] int remainingCost;
    [SerializeField] int currentLevel;
    [SerializeField] string id;
    [SerializeField] FloatReference relatedAttribute;
    [SerializeField] IntReference relatedCurrency;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text levelCostText;

    public override int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public override int RemainingCost { get => remainingCost; set => remainingCost = value; }

    public override int GetGetNextLevelsCost
    {
        get
        {
            if (currentLevel  < levelData.Levels.Count )
                return levelData.Levels[currentLevel].cost;
            else
                return -1;
        }
    }

    public int Cost => GetGetNextLevelsCost;

    public IntReference RelatedCurrency => relatedCurrency;

    public override void NextLevel()
    {
        if (GetGetNextLevelsCost == -1)
            return;

        currentLevel++;
        relatedAttribute.Value = levelData.Levels[currentLevel - 1].value;
        RemainingCost = GetGetNextLevelsCost;
        PlayerPrefs.SetInt(id + "_Level", currentLevel);
        UpdateUI();
        onLevelUp?.Invoke();
        OnLevelUp?.Invoke(this);
    }

    public override void UpdateUI()
    {
        if (levelText != null)
        {
            if (GetGetNextLevelsCost != -1)
                levelText.text = GetGetNextLevelsCost.ToString();
            else
                levelText.text = "MAX";

        }

        if(levelCostText != null)
        {

        }
    }

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt(id + "_Level", 1);
        RemainingCost = GetGetNextLevelsCost;

        UpdateUI();
    }
}
