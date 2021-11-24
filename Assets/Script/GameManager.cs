using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    #region Set Get �Լ�
    public int Exp { get { return exp; } set { exp = value; } }
    public int Matarial { get { return matarial; } set { matarial = value; } }
    public int MatarialAmount { get { return matarialAmount[curWappenLevel]; } set { matarialAmount[curWappenLevel] = value; } }
    public int Sps { get { return sps[curExpLevel]; } set { sps[curExpLevel] = value; } }
    public int CurExpLevel { get { return curExpLevel; } set { curExpLevel = value; } }
    public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }
    public Circle Circle { get { return circle; } set { circle = value; } }
    public Player Player { get { return player; } set { player = value; } }
    public CameraManager CameraManager { get { return cameraManager; } set { cameraManager = value; } }
    #endregion
    #region ����
    private int curExpLevel;
    private int curWappenLevel;
    #endregion
    #region �ν�����
    [Header("���")] [SerializeField] private int matarial;
    [Header("���� ����ġ")] [SerializeField] private int exp;
    [Header("���� ������ �ʿ��� ��ᷮ")] [SerializeField] private int[] matarialAmount;
    [Header("�ܰ躰 �ʴ� ����ġ �迭")] [SerializeField] private int[] sps;
    [Header("���� �������� �ܰ�")] [SerializeField] private int[] expLevel;
    [Header("���������� �����ϴ� �� ����(2���� �迭)")] [SerializeField] private LevelEnemy[] LevelPerEnemy;
    [Header("UIManager ��ũ��Ʈ")] [SerializeField] private UIManager uiManager;
    [Header("Circle ��ũ��Ʈ")] [SerializeField] private Circle circle;
    [Header("Player ��ũ��Ʈ")] [SerializeField] private Player player;
    [Header("CameraManager ��ũ��Ʈ")] [SerializeField] private CameraManager cameraManager;
    #endregion
    private void Start()
    {
        uiManager.UpdateUI();
        Time.timeScale = 1;
        int temp = 15;
        for(int i = 1; i < 120; i++)
        {
            matarialAmount[i] = temp;
            temp += 10;
        }
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
            uiManager.ShowUpgradePannel();
        }
        uiManager.UpdateUI();
    }
    public void GetMatarial()
    {
        if(matarial >= matarialAmount[curWappenLevel])
        {
            matarial = 0;
            curWappenLevel++;
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
    [Header("���������� ü�� ������")] [SerializeField] private float hpUpValue;
    [Header("���������� ���ݷ� ������")] [SerializeField] private float damageUpValue;
    [Header("���������� �ӵ� ������")] [SerializeField] private float speedUpValue;
    [Header("ü��")] [SerializeField] private float hp;
    [Header("���ݷ�")] [SerializeField] private float damage;
    [Header("�ӵ�")] [SerializeField] private float speed;
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