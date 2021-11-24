using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    #region �ν�����
    [Header("������ �����ϴ� ���� ������")] [SerializeField] private int[] levelWappenDamage;
    [Header("����")] [SerializeField] private int[] level;
    [Header("������ �����ϴ� ��¡ �ӵ�")] [SerializeField] private float[] levelWappenSpeed;
    [Header("������ ũ��")] [SerializeField] private float[] levelSize;
    [Header("�̻��Ѱ�")] [SerializeField] private GameObject holdPannel;
    [Header("���׷��̵� �ǳ�")] [SerializeField] private GameObject upgradePannel;
    [Header("���� �������� �ǳ�")] [SerializeField] private GameObject NextStagePannel;
    [Header("���� �迭 ?")] [SerializeField] private Wappen[] wappen;
    [Header("���� ���� ǥ���ϴ� �ؽ�Ʈ")] [SerializeField] private Text[] levelText;
    #endregion
    public void ShowNextStage()
    {
        holdPannel.SetActive(true);
        NextStagePannel.SetActive(true);
    }
    public void ShowUpgrade()
    {
        NextStagePannel.SetActive(false);
        upgradePannel.SetActive(true);
    }
    public void GoGame()
    {
        NextStagePannel.SetActive(false);
        upgradePannel.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.UIManager.BreakTime(10);
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
        if (level[0] < 10)
        {
            for (int i = 0; i < 3; i++)
            {
                wappen[i].ChangeDamage(levelWappenDamage[level[0]]);
            }
            level[0]++;
            levelText[0].text = string.Format("{0} / {1}", level[0], 10);
            //Debug.Log("������ �������� ���׷��̵� ��");
        }
    }
    void UpgradAttackSpeed()
    {
        if (level[1] < 10)
        {
            GameManager.Instance.Player.ChangeWappenSpeed(levelWappenSpeed[level[1]]);
            level[1]++;
            levelText[1].text = string.Format("{0} / {1}", level[1], 10);
            //Debug.Log("������ �ӵ��� ���׷��̵� ��");
        }
    }
    void UpgradSpeed()
    {
        if (level[2] < 10)
        {
            GameManager.Instance.Circle.ChangeSpeed(levelSize[level[2]]);
            level[2]++;
            levelText[2].text = string.Format("{0} / {1}", level[2], 10);
            //Debug.Log("�÷��̾��� �ӵ��� ���׷��̵� ��");
        }
    }
    #endregion
}