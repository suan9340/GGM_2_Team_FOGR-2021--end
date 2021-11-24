using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingManager : MonoBehaviour
{
    #region 인스펙터
    [Header("레벨에 대응하는 무기 데미지")] [SerializeField] private int[] levelWappenDamage;
    [Header("레벨")] [SerializeField] private int[] level;
    [Header("레벨에 대응하는 차징 속도")] [SerializeField] private float[] levelWappenSpeed;
    [Header("레벨의 크기")] [SerializeField] private float[] levelSize;
    [Header("이상한거")] [SerializeField] private GameObject holdPannel;
    [Header("업그레이드 판넬")] [SerializeField] private GameObject upgradePannel;
    [Header("다음 스테이지 판넬")] [SerializeField] private GameObject NextStagePannel;
    [Header("무기 배열 ?")] [SerializeField] private Wappen[] wappen;
    [Header("현제 레벨 표시하는 텍스트")] [SerializeField] private Text[] levelText;
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
    #region 실질 업그레이드 실행문
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
            //Debug.Log("무기의 데미지가 업그레이드 됨");
        }
    }
    void UpgradAttackSpeed()
    {
        if (level[1] < 10)
        {
            GameManager.Instance.Player.ChangeWappenSpeed(levelWappenSpeed[level[1]]);
            level[1]++;
            levelText[1].text = string.Format("{0} / {1}", level[1], 10);
            //Debug.Log("무기의 속도가 업그레이드 됨");
        }
    }
    void UpgradSpeed()
    {
        if (level[2] < 10)
        {
            GameManager.Instance.Circle.ChangeSpeed(levelSize[level[2]]);
            level[2]++;
            levelText[2].text = string.Format("{0} / {1}", level[2], 10);
            //Debug.Log("플레이어의 속도가 업그레이드 됨");
        }
    }
    #endregion
}