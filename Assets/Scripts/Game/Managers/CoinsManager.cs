using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsManager : Manager<CoinsManager>
{
    [HideInInspector] public int CoinsAmount;
    private int cubeStreak = 0;
    private int streakBonus = 1;
    public TextMeshProUGUI CoinsText;
    public int CubesToIncreaseBonusByOne = 2;

    private void Start()
    {
        CoinsAmount =  PlayerPrefs.GetInt("CoinsAmount");
        CoinsText.text = CoinsAmount.ToString();
    }

    public void AddCoins(int CoinsToAdd)
    {
        CoinsAmount += CoinsToAdd * streakBonus;
        PlayerPrefs.SetInt("CoinsAmount", CoinsAmount);
        CoinsText.text = CoinsAmount.ToString();
    }

    public void AddCubeToStreak()
    {
        cubeStreak += 1;
        streakBonus = 1 + cubeStreak / CubesToIncreaseBonusByOne;
    }

    public void ClearStreak()
    {
        cubeStreak = 0;
        streakBonus = 1;
    }
}
