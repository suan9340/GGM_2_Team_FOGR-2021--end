using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    #region Set Get 함수
    public int Exp { get { return exp; } set { exp = value; } }
    public int Matarial { get { return matarial; } set { matarial = value; } }
    public int Sps { get { return sps[curExpLevel]; } set { sps[curExpLevel] = value; } }
    public int CurExpLevel { get { return curExpLevel; } set { curExpLevel = value; } }
    public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }
    public Circle Circle { get { return circle; } set { circle = value; } }
    public Player Player { get { return player; } set { player = value; } }
    public CameraManager CameraManager { get { return cameraManager; } set { cameraManager = value; } }
    #endregion
    #region 변수
    private int curExpLevel;
    #endregion
    #region 인스펙터
    [Header("재료")] [SerializeField] private int matarial;
    [Header("현제 경험치")] [SerializeField] private int exp;
    [Header("단계별 초당 경험치 배열")] [SerializeField] private int[] sps;
    [Header("현제 스테이지 단계")] [SerializeField] private int[] expLevel;
    [Header("스테이지당 대응하는 적 정보(2차원 배열)")] [SerializeField] private LevelEnemy[] LevelPerEnemy;
    [Header("UIManager 스크립트")] [SerializeField] private UIManager uiManager;
    [Header("Circle 스크립트")] [SerializeField] private Circle circle;
    [Header("Player 스크립트")] [SerializeField] private Player player;
    [Header("CameraManager 스크립트")] [SerializeField] private CameraManager cameraManager;
    #endregion
    private void Start()
    {
        uiManager.UpdateUI();
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.Pause(true);
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
            Debug.Log("A");
            uiManager.ShowUpgradePannel();
        }
        uiManager.UpdateUI();
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
                break;
            case 1:
                return damage;
                break;
            case 2:
                return speed;
                break;
            default:
                return 0;
                break;
        }
    }
}