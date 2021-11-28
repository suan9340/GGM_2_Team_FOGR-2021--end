using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    #region �ν�����
    [Header("������ �����ϴ� ���� ������")] [SerializeField] private int[] levelWeaponDamage;
    [Header("����")] [SerializeField] private float[] level;
    [Header("������ �����ϴ� ��¡ �ӵ�")] [SerializeField] private float[] levelWeaponSpeed;
    [Header("������ ũ��")] [SerializeField] private float[] levelSize;
    [Header("�̻��Ѱ�")] [SerializeField] private GameObject holdPannel;
    [Header("���׷��̵� �ǳ�")] [SerializeField] private GameObject upgradePannel;
    [Header("���� �������� �ǳ�")] [SerializeField] private GameObject NextStagePannel;
    [Header("���� �迭 ?")] [SerializeField] private Weapon[] weapon;
    [Header("���� ���� ǥ���ϴ� �����̴�")] [SerializeField] private Slider[] levelSlider;
    [Header("�� ���� �迭")] [SerializeField] private EnemyInfo[] enemyInfo;
    [Header("�� �̸�")] [SerializeField] private Text enemy_Name_Text;
    [Header("�� ����")] [SerializeField] private Text enemy_Desc_Text;
    [Header("�� ����")] [SerializeField] private Image enemy_Image_Image;
    #endregion
    /*public void ShowNextStage()
    {
        holdPannel.SetActive(true);
        NextStagePannel.SetActive(true);
    }*/
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
    public void ShowNextEnemy()
    {
        enemy_Name_Text.text = enemyInfo[1].name;
        enemy_Desc_Text.text = enemyInfo[1].desc;
        enemy_Image_Image.sprite = enemyInfo[1].sprite;
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
        GameManager.Instance.PoolManager.ClearTable();
        GoGame();
    }
    #region ���� ���׷��̵� ���๮
    void UpgradDamage()
    {
        if (level[0] < 10)
        {
            for (int i = 0; i < 3; i++)
            {
                weapon[i].ChangeDamage(levelWeaponDamage[(int)level[0]]);
            }
            level[0]++;
            levelSlider[0].value = (float)level[0] * 0.1f;
        }
    }
    void UpgradSpeed()
    {
        if (level[1] < 10)
        {
            GameManager.Instance.Circle.ChangeSpeed(levelSize[(int)level[1]]);
            level[1]++;
            levelSlider[1].value = (float)level[2] * 0.1f;
        }
    }
    void UpgradAttackSpeed()
    {
        if (level[2] < 10)
        {
            GameManager.Instance.Player.ChangeWappenSpeed(levelWeaponSpeed[(int)level[2]]);
            level[2]++;
            levelSlider[2].value = level[2] * 0.1f;
        }
    }
    #endregion
}