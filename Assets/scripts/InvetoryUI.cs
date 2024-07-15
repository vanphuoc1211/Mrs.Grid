using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvetoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();   
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = playerInventory.NumberofCoins.ToString();
    }
}
