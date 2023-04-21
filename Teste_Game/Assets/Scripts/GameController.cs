using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void SetMoneyText(int currentMoney)
    {
        moneyText.text = $"R$: {currentMoney}";
    }
}
