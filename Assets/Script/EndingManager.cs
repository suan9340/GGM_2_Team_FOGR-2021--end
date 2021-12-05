using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    #region 인스펙터    
    //[Header("무기 배열 ?")] [SerializeField] private Weapon[] weapon;
    //[Header("이상한거")] [SerializeField] private GameObject holdPannel;
    [Header("레벨")] [SerializeField] private float[] level;
    [Header("레벨에 대응하는 차징 속도")] [SerializeField] private float[] levelWeaponSpeed;
    [Header("레벨에 대응하는 무기 데미지")] [SerializeField] private float[] levelWeaponDamage;
    [Header("레벨에 대응하는 속도")] [SerializeField] private float[] levelSpeed;
    [Header("업그레이드 판넬")] [SerializeField] private GameObject upgradePannel;
    [Header("다음 스테이지 판넬")] [SerializeField] private GameObject NextStagePannel;
    [Header("현제 레벨 표시하는 슬라이더")] [SerializeField] private Slider[] levelSlider;
    [Header("적 정보 배열")] [SerializeField] private EnemyInfo[] enemyInfo;
    [Header("업그레이드될 수치 표시용 텍스트")] [SerializeField] private Text[] levelValueText;
    [Header("적 이름")] [SerializeField] private Text enemy_Name_Text;
    [Header("적 설명")] [SerializeField] private Text enemy_Desc_Text;
    [Header("적 사진")] [SerializeField] private Image enemy_Image;
    [Header("적이 나오는 스테이지")] [SerializeField] private int[] stageEnemyArr;
    [Header("StageClear 에니메이션")] [SerializeField] private GameObject stageClear;
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
    #region 실질 업그레이드 실행문
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