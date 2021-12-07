using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    #region Set Get 함수
    public int Exp { get { return exp; } set { exp = value; } }
    public int Ingredient { get { return ingredient; } set { ingredient = value; } }
    public int IngredientAmount { get { return ingredientAmount[curWeaponLevel]; } set { ingredientAmount[curWeaponLevel] = value; } }
    public int Sps { get { return sps[curExpLevel]; } set { sps[curExpLevel] = value; } }
    public int CurExpLevel { get { return curExpLevel; } set { curExpLevel = value; } }
    public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }
    public Circle Circle { get { return circle; } set { circle = value; } }
    public Player Player { get { return player; } set { player = value; } }
    public CameraManager CameraManager { get { return cameraManager; } set { cameraManager = value; } }
    public PoolManager PoolManager { get { return poolManager; } set { poolManager = value; } }
    public EndingManager EndingManager { get { return endingManager; } set { endingManager = value; } }
    public bool IsCanESC { get { return isCanESC; } set { isCanESC = value; } }
    public int CurWeaponLevel { get { return curWeaponLevel; } set { curWeaponLevel = value; } }
    public int WeaponLevelLength { get { return levelPerDamage.Length; }}
    public float LevelPerDamage { get { return levelPerDamage[curWeaponLevel]; } set { levelPerDamage[curWeaponLevel] = value; } }
    public float DamageUpgradeAmount { get { return damageUpgradeAmount; } set { damageUpgradeAmount = value; } }
    public float DamageBuffAmount { get { return damageBuffAmount; } set { damageBuffAmount = value; } }
    public float SpeedUpgradeAmount { get { return speedUpgradeAmount; } set { speedUpgradeAmount = value; } }
    public float SpeedBuffAmount { get { return speedBuffAmount; } set { speedBuffAmount = value; } }
    public float WaeponSpeedUpgradeAmount { get { return weaponSpeedUpgradeAmount; } set { weaponSpeedUpgradeAmount = value; } }
    public float WaeponSpeedBuffAmount { get { return weaponSpeedBuffAmount; } set { weaponSpeedBuffAmount = value; } }
    #endregion
    #region 변수
    bool isCanESC = true;
    private int curExpLevel;
    private int curWeaponLevel;
    #endregion
    #region 인스펙터
    [Header("재료")] [SerializeField] private int ingredient;
    [Header("현제 경험치")] [SerializeField] private int exp;
    [Header("무기 레벨업 필요한 재료량")] [SerializeField] private int[] ingredientAmount;
    [Header("무기 레벨에 따른 공격력")] [SerializeField] private float[] levelPerDamage;
    [Header("단계별 초당 경험치 배열")] [SerializeField] private int[] sps;
    [Header("현제 스테이지 단계")] [SerializeField] private int[] expLevel;
    [Header("스테이지당 대응하는 적 정보(2차원 배열)")] [SerializeField] private LevelEnemy[] LevelPerEnemy;
    [Header("UIManager 스크립트")] [SerializeField] private UIManager uiManager;
    [Header("Circle 스크립트")] [SerializeField] private Circle circle;
    [Header("Player 스크립트")] [SerializeField] private Player player;
    [Header("CameraManager 스크립트")] [SerializeField] private CameraManager cameraManager;
    [Header("PoolManager 스크립트")] [SerializeField] private PoolManager poolManager;
    [Header("EndingManager")] [SerializeField] private EndingManager endingManager;
    [Header("공격력 배율")] [SerializeField] private float damageUpgradeAmount;
    [Header("공격력 버프")] [SerializeField] private float damageBuffAmount;
    [Header("속도 배율")] [SerializeField] private float speedUpgradeAmount;
    [Header("속도 버프")] [SerializeField] private float speedBuffAmount;
    [Header("차징속도 배율")] [SerializeField] private float weaponSpeedUpgradeAmount;
    [Header("차징속도 버프")] [SerializeField] private float weaponSpeedBuffAmount;
    #endregion
    private void Start()
    {
        GameSetUp();
    }
    private void Update()
    {
        CheckInput();
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isCanESC)
        {
            uiManager.Pause(true);
        }
    }
    void GameSetUp()
    {
        Time.timeScale = 1;
        uiManager.UpdateUI();
        int temp = 5;
        for (int i = 0; i < 100; i++) //무기 업글당 재료량 공식
        {
            ingredientAmount[i] = temp;
            temp += 3;
        }
        float temp2 = 1;
        for (int i = 0; i < 100; i++)
        {
            levelPerDamage[i] = temp2;
            temp2 += 0.2f;
        }
        uiManager.UpdateUI();
    }
    public void UpGradeSpeed(float value)
    {
        speedUpgradeAmount = value;
    }
    public void UpGradeDamage(float value)
    {
        damageUpgradeAmount = value;
    }
    public void UpGradeWeaponSpeed(float value)
    {
        weaponSpeedUpgradeAmount = value;
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
    public float GetSliderValue()
    {
        return (float)exp / (float)expLevel[curExpLevel];
    }
    public void GetExp(int get)
    {
        exp += get;
        if (exp >= expLevel[curExpLevel])
        {
            curExpLevel++;
            uiManager.ShowUpgradePannel();
            if (curExpLevel == 19)
            {
                uiManager.Ending();
            }
        }
        uiManager.UpdateUI();
    }
    public void GetIngredient()
    {
        uiManager.UpdateUI();
        if (ingredient >= ingredientAmount[curWeaponLevel])
        {
            ingredient = 0;
            curWeaponLevel++;
            player.CheckWeapon();
        }
    }
    public float GetLevel(int type, int mod)
    {
        return LevelPerEnemy[type].Get(mod);
    }
    public void AddBuff(int type)
    {
        switch (type)
        {
            case 0:
                damageBuffAmount = 3;
                break;
            case 1:
                speedBuffAmount = 2;
                break;
            case 2:
                weaponSpeedBuffAmount = 2;
                break;
        }
    }
    public void MinusBuff(int type)
    {
        switch (type)
        {
            case 0:
                damageBuffAmount = 1;
                break;
            case 1:
                speedBuffAmount = 1;
                break;
            case 2:
                weaponSpeedBuffAmount = 1;
                break;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Ending()
    {

    }
}
[System.Serializable]
public class LevelEnemy
{
    [Header("체력")] [SerializeField] private float[] hp;
    [Header("공격력")] [SerializeField] private float[] damage;
    public float Get(int type)
    { 
        int index = GameManager.Instance.CurExpLevel;
        switch (type)
        {
            case 0:
                return hp[index];
            case 1:
                return damage[index];
            default:
                return 0;
        }
    }
}