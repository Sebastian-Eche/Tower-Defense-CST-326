using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    void Update()
    {
        //SHOW negative money floating away
        moneyText.text = $"${PlayerStats.Money.ToString()}";
    }

}
