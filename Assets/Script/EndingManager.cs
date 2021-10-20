using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    [SerializeField] private Text[] levelText;
    [SerializeField] private int[] level;
    [SerializeField] private GameObject holdPannel;
    [SerializeField] private GameObject UpgradePannel;
    [SerializeField] private GameObject NextStagePannel;
    public void ShowNextStage()
    {
        Time.timeScale = 0;
        holdPannel.SetActive(true);
        NextStagePannel.SetActive(true);
    }
    public void ShowUpgrade()
    {
        NextStagePannel.SetActive(false);
        UpgradePannel.SetActive(true);
    }
    public void GoGame()
    {
        UpgradePannel.SetActive(false);
        holdPannel.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.BreakTime(10);
    }
    public void Upgrade(int get)
    {
        switch (get)
        {
            case 0:
                UpgradDamage();
                break;
            case 1:
                UpgradAttackSpeed();
                break;
            case 2:
                UpgradSpeed();
                break;
            default:
                Debug.LogError("Null!");
                break;
        }
        GoGame();
    }
    #region 실질 업그레이드 실행문
    void UpgradDamage()
    {
        if(level[0] < 10)
        {
            level[0]++;
            levelText[0].text = string.Format("{0} / {1}", level[0], 10);
            Debug.Log("무기의 데미지가 업그레이드 됨");
        }
        gameObject.SetActive(false);
    }
    void UpgradAttackSpeed()
    {
        if (level[1] < 10)
        {
            level[1]++;
            levelText[1].text = string.Format("{0} / {1}", level[1], 10);
            Debug.Log("무기의 속도를 업그레이드 됨");
        }
        gameObject.SetActive(false);
    }
    void UpgradSpeed()
    {
        if (level[2] < 10)
        {
            level[2]++;
            levelText[2].text = string.Format("{0} / {1}", level[2], 10);
            Debug.Log("플레이어의 속도가 업그레이드 됨");
        }
        gameObject.SetActive(false);
    }
    #endregion
}
