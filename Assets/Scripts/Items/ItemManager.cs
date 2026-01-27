using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetValues();
    }

    private void ResetValues()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
