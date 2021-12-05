using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    #region �ν�����    
    //[Header("���� �迭 ?")] [SerializeField] private Weapon[] weapon;
    //[Header("�̻��Ѱ�")] [SerializeField] private GameObject holdPannel;
    [Header("����")] [SerializeField] private float[] level;
    [Header("������ �����ϴ� ��¡ �ӵ�")] [SerializeField] private float[] levelWeaponSpeed;
    [Header("������ �����ϴ� ���� ������")] [SerializeField] private float[] levelWeaponDamage;
    [Header("������ �����ϴ� �ӵ�")] [SerializeField] private float[] levelSpeed;
    [Header("���׷��̵� �ǳ�")] [SerializeField] private GameObject upgradePannel;
    [Header("���� �������� �ǳ�")] [SerializeField] private GameObject NextStagePannel;
    [Header("���� ���� ǥ���ϴ� �����̴�")] [SerializeField] private Slider[] levelSlider;
    [Header("�� ���� �迭")] [SerializeField] private EnemyInfo[] enemyInfo;
    [Header("���׷��̵�� ��ġ ǥ�ÿ� �ؽ�Ʈ")] [SerializeField] private Text[] levelValueText;
    [Header("�� �̸�")] [SerializeField] private Text enemy_Name_Text;
    [Header("�� ����")] [SerializeField] private Text enemy_Desc_Text;
    [Header("�� ����")] [SerializeField] private Image enemy_Image;
    [Header("���� ������ ��������")] [SerializeField] private int[] stageEnemyArr;
    [Header("StageClear ���ϸ��̼�")] [SerializeField] private GameObject stageClear;
    #endregion
    /*public void ShowNextStage()
    {
        NextStagePannel.SetActive(true);
        holdPannel.SetActive(true);
    }*/
    public void ShowUpgrade()
    {
        NextStagePannel.SetActive(false);
        upgradePannel.SetActive(true);
        SetNextValue();
    }
    public void GoGame()
    {
        stageClear.SetActive(false);
        NextStagePannel.SetActive(false);
        upgradePannel.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.UIManager.StartCoroutine(GameManager.Instance.UIManager.BreakTime(5));
    }
    public void ShowNextEnemy()
    {
        stageClear.SetActive(true);
        bool istrue = false;
        enemy_Name_Text.text = "";
        enemy_Desc_Text.text = "";
        enemy_Image.color = new Vector4(0,0,0,0);
        for (int i = 1; i < stageEnemyArr.Length; i++)
        {
            if(stageEnemyArr[i] == GameManager.Instance.CurExpLevel)
            {
                istrue = true;
                enemy_Name_Text.text = enemyInfo[i].name;
                enemy_Desc_Text.text = enemyInfo[i].desc;
                enemy_Image.sprite = enemyInfo[i].sprite;
                enemy_Image.color = new Vector4(1, 1, 1, 1);
            }
        }
        if(!istrue)
        {
            ShowUpgrade();
        }
    }
    public void ShowUpgradeValue()
    {
        for (int i = 0; i < levelValueText.Length; i++)
        {
            switch (i)
            {
                case 0:
                    levelValueText[i].text = string.Format("{0} -> {1}", levelWeaponDamage[(int)level[i]]);
                    break;
                case 1:
                    levelValueText[i].text = string.Format("{0} -> {1}", levelSpeed[(int)level[i]]);
                    break;
                case 2:
                    levelValueText[i].text = string.Format("{0} -> {1}", levelWeaponSpeed[(int)level[i]]);
                    break;
            }
        }
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
    void SetNextValue() 
    {
        if((int)level[0] < 10)
        {
            levelValueText[0].text = string.Format("{0} -> {1}", levelWeaponDamage[(int)level[0] - 1], levelWeaponDamage[(int)level[0]]);
        }
        else
        {
            levelValueText[0].text = string.Format("MAX : {0}",levelWeaponDamage[(int)level[0]]);
        }
        if ((int)level[1] < 10)
        {
            levelValueText[1].text = string.Format("{0} -> {1}", levelSpeed[(int)level[1] - 1], levelSpeed[(int)level[1]]);
        }
        else
        {
            levelValueText[1].text = string.Format("MAX : {0}", levelSpeed[(int)level[1]]);
        }
        if ((int)level[2] < 10)
        {
            levelValueText[2].text = string.Format("{0} -> {1}", levelWeaponSpeed[(int)level[2] - 1], levelWeaponSpeed[(int)level[2]]);
        }
        else
        {
            levelValueText[2].text = string.Format("MAX : {0}", levelWeaponSpeed[(int)level[2]]);
        }
        levelSlider[0].value = level[0] * 0.1f;
        levelSlider[1].value = level[1] * 0.1f;
        levelSlider[2].value = level[2] * 0.1f;
    }
    #region ���� ���׷��̵� ���๮
    void UpgradDamage()
    {
        if (level[0] <= 10)
        {
            GameManager.Instance.UpGradeDamage(levelWeaponDamage[(int)level[0]]);
            level[0]++;
            levelSlider[0].value = level[0] * 0.1f;
        }
    }
    void UpgradSpeed()
    {
        if (level[1] <= 10)
        {
            GameManager.Instance.UpGradeSpeed(levelSpeed[(int)level[1]]);
            level[1]++;
            levelSlider[1].value = level[1] * 0.1f;
        }
    }
    void UpgradAttackSpeed()
    {
        if (level[2] <= 10)
        {
            GameManager.Instance.UpGradeWeaponSpeed(levelWeaponSpeed[(int)level[2]]);
            level[2]++;
            levelSlider[2].value = level[2] * 0.1f;
        }
    }
    #endregion
}