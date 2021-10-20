using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Slider slider;
    [SerializeField] private Circle circle;
    [SerializeField] private Player player;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private int[] expLevel;
    [SerializeField] private int exp;
    private int curExpLevel;
    public void ShowUpgradePannel()
    {

    }
    public void BreakTime(int time)
    {

    }
    public void PauseGame()
    {

    }
    public void GetExp(int get)
    {
        exp += get;
        if(exp >= expLevel[curExpLevel])
        {
            curExpLevel++;
            upgradePanel.SetActive(true);
        }
        slider.value = (float)exp / (float)expLevel[curExpLevel];
    }
}