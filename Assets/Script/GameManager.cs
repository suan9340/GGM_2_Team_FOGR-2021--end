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
    #endregion
    #region 변수
    private int curExpLevel;
    private int curWeaponLevel;
    #endregion
    #region 인스펙터
    [Header("재료")] [SerializeField] private int ingredient;
    [Header("현제 경험치")] [SerializeField] private int exp;
    [Header("무기 레벨업 필요한 재료량")] [SerializeField] private int[] ingredientAmount;
    [Header("단계별 초당 경험치 배열")] [SerializeField] private int[] sps;
    [Header("현제 스테이지 단계")] [SerializeField] private int[] expLevel;
    [Header("스테이지당 대응하는 적 정보(2차원 배열)")] [SerializeField] private LevelEnemy[] LevelPerEnemy;
    [Header("UIManager 스크립트")] [SerializeField] private UIManager uiManager;
    [Header("Circle 스크립트")] [SerializeField] private Circle circle;
    [Header("Player 스크립트")] [SerializeField] private Player player;
    [Header("CameraManager 스크립트")] [SerializeField] private CameraManager cameraManager;
    [Header("PoolManager 스크립트")] [SerializeField] private PoolManager poolManager;
    [Header("EndingManager")] [SerializeField] private EndingManager endingManager;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.Pause(true);
        }
    }
    void GameSetUp()
    {
        Time.timeScale = 1;
        uiManager.UpdateUI();
        int temp = 15;
        for (int i = 1; i < 120; i++) //무기 업글당 재료량 공식
        {
            ingredientAmount[i] = temp;
            temp += 10;
        }
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
        if(exp >= expLevel[curExpLevel])
        {
            curExpLevel++;
            uiManager.ShowUpgradePannel();
        }
        uiManager.UpdateUI();
    }
    public void GetIngredient()
    {
        if(ingredient >= ingredientAmount[curWeaponLevel])
        {
            ingredient = 0;
            curWeaponLevel++;
        }
    }
    public float GetLevel(int type,int mod)
    {
        return LevelPerEnemy[type].Get(mod);
    }
}
[System.Serializable]
public class LevelEnemy
{
    [Header("스테이지당 체력 증가량")] [SerializeField] private float hpUpValue;
    [Header("스테이지당 공격력 증가량")] [SerializeField] private float damageUpValue;
    [Header("스테이지당 속도 증가량")] [SerializeField] private float speedUpValue;
    [Header("체력")] [SerializeField] private float hp;
    [Header("공격력")] [SerializeField] private float damage;
    [Header("속도")] [SerializeField] private float speed;
    public void ChangeStage()
    {
        hp += hpUpValue;
        damage += damageUpValue;
        speed += speedUpValue;
    }
    public float Get(int type)
    {
        switch (type)
        {
            case 0:
                return hp;
            case 1:
                return damage;
            case 2:
                return speed;
            default:
                return 0;
        }
    }
}