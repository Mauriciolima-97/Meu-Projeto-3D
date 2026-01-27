using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate02 : MonoBehaviour
{
    public SORedInt redCoins;

    public TextMeshProUGUI uiTextRedValue;

    void Start()
    {
        uiTextRedValue.text = redCoins.value.ToString();
    }

    void Update()
    {
        uiTextRedValue.text = redCoins.value.ToString();
    }
}
