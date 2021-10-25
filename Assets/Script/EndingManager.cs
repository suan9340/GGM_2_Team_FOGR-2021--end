using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    [SerializeField] private int[] levelWappenDamage;
    [SerializeField] private int[] level;
    [SerializeField] private float[] levelWappenSpeed;
    [SerializeField] private float[] levelSize;
    [SerializeField] private GameObject holdPannel;
    [SerializeField] private GameObject UpgradePannel;
    [SerializeField] private GameObject NextStagePannel;
    [SerializeField] private Wappen[] wappen;
    [SerializeField] private Text[] levelText;
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
    #region ���� ���׷��̵� ���๮
    void UpgradDamage()
    {
        if(level[0] < 10)
        {
            for(int i = 0; i < 3; i++)
            {
                wappen[i].ChangeDamage(levelWappenDamage[level[0]]);
            }
            level[0]++;
            levelText[0].text = string.Format("{0} / {1}", level[0], 10);
            Debug.Log("������ �������� ���׷��̵� ��");
        }
        gameObject.SetActive(false);
    }
    void UpgradAttackSpeed()
    {
        if (level[1] < 10)
        {
            GameManager.Instance.player.ChangeWappenSpeed(levelWappenSpeed[level[1]]);
            level[1]++;
            levelText[1].text = string.Format("{0} / {1}", level[1], 10);
            Debug.Log("������ �ӵ��� ���׷��̵� ��");
        }
        gameObject.SetActive(false);
    }
    void UpgradSpeed()
    {
        if (level[2] < 10)
        {
            GameManager.Instance.circle.ChangeSpeed(levelSize[level[2]]);
            level[2]++;
            levelText[2].text = string.Format("{0} / {1}", level[2], 10);
            Debug.Log("�÷��̾��� �ӵ��� ���׷��̵� ��");
        }
        gameObject.SetActive(false);
    }
    #endregion
}
