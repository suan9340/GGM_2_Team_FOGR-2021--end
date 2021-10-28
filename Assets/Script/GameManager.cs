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
    public int Sps { get { return sps[curExpLevel]; } set { sps[curExpLevel] = value; } }
    public UIManager UIManager { get { return uiManager; } set { uiManager = value; } }
    public Circle Circle { get { return circle; } set { circle = value; } }
    public Player Player { get { return player; } set { player = value; } }
    #endregion
    #region ����
    private int curExpLevel;
    #endregion
    #region �ν�����
    [Header("���")] [SerializeField] private int matarial;
    [Header("���� ����ġ")] [SerializeField] private int exp;
    [Header("�ܰ躰 �ʴ� ����ġ �迭")] [SerializeField] private int[] sps;
    [Header("���� �������� �ܰ�")] [SerializeField] private int[] expLevel;
    [Header("���������� �����ϴ� �� ����(2���� �迭)")] [SerializeField] private LevelEnemy[] LevelPerEnemy;
    [Header("UIManager ��ũ��Ʈ")] [SerializeField] private UIManager uiManager;
    [Header("Circle ��ũ��Ʈ")] [SerializeField] private Circle circle;
    [Header("Player ��ũ��Ʈ")] [SerializeField] private Player player;
    #endregion
    private void Start()
    {
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
    public void GetExp(int get)
    {
        exp += get;
        if(exp >= expLevel[curExpLevel])
        {
            curExpLevel++;
        }
        uiManager.UpdateUI();
    }
    public float GetLevel(int type)
    {
        return LevelPerEnemy[curExpLevel].Get(type,curExpLevel);
    }
}
[System.Serializable]
public class LevelEnemy
{
    [Header("ü��")] [SerializeField] private float[] hp;
    [Header("���ݷ�")] [SerializeField] private float[] damage;
    [Header("�ӵ�")] [SerializeField] private float[] speed;
    public float Get(int type,int level)
    {
        switch (type)
        {
            case 0:
                return hp[level];
                break;
            case 1:
                return damage[level];
                break;
            case 2:
                return speed[level];
                break;
            default:
                return 0;
                break;
        }
    }
}