using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SORedInt redCoins;
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextRedCoins;
    private void Start()
    {
        Reset();
    }


    private void Reset()
    {
        coins.value = 0;
        redCoins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }
    public void AddRedCoins(int amount = 1)
    {
        redCoins.value += amount;
        UpdateUI();

    }
    private void UpdateUI()
    {
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
