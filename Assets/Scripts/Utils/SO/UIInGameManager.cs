using UnityEngine;
using TMPro;

public class UIInGameManager : MonoBehaviour
{
    public static UIInGameManager Instance;

    public TextMeshProUGUI uiTextCoins;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTextCoins(string s)
    {
        uiTextCoins.text = s;
    }
}
