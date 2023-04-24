using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Amount of money")]
    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Settings Button buy LevelUP")]
    [SerializeField] private TextMeshProUGUI buttonBuyLevelUPText;

    [Header("Change player color")]
    [SerializeField] private ChangeColor changeColor;

    [Header("Condition for LevelUP")]
    [SerializeField] private int currentLimitStack = 1;
    [SerializeField] private int currentMoneyPerBodyEnemyInStack = 0;
    [SerializeField] private int priceLevelUP = 20;

    [SerializeField] private int accumulateMoney = 0;
    
    public int CurrentLimitStack { get => currentLimitStack; }
    public int CurrentMoneyPerBodyEnemyInStack { get => currentMoneyPerBodyEnemyInStack; }
    public int AccumulateMoney { get => accumulateMoney; }

    private void Start()
    {
        SetMoneyText("R$ " ,accumulateMoney);
        buttonBuyLevelUPText.text = $"LevelUP \nR$: {priceLevelUP}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetAccumulateMoney(int value)
    {
        accumulateMoney += value;
    }

    public void SetMoneyText(string text, int currentMoney)
    {
        moneyText.text = text + currentMoney;
    }

    public void LevelUP()
    {
        if (accumulateMoney >= priceLevelUP)
        {
            accumulateMoney -= priceLevelUP;

            SetMoneyText("R$ ", AccumulateMoney);

            changeColor.SetChangeColorPlayer();

            currentLimitStack++;
        }
    }
}
