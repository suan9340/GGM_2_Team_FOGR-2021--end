using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int exp;
    [SerializeField] private int[] expLevel;
    public Circle circle;
    public Player player;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject pausePannel;
    private int curExpLevel;
    public void ShowUpgradePannel()
    {
        
    }
    public void BreakTime(int time)
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(true);
        }
    }
    public void PauseGame(bool isOn)
    {
        if (isOn)
        {
            pausePannel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausePannel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
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