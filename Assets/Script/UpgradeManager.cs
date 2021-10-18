using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private Text[] levelText;
    [SerializeField] private int[] level;
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
        GameManager.Instance.BreakTime(10);
    }
    public void UpgradDamage()
    {
        if(level[0] < 10)
        {
            level[0]++;
            levelText[0].text = string.Format("{0} / {1}", level[0], 10);
            Debug.Log("무기의 데미지가 업그레이드 됨");
        }
        gameObject.SetActive(false);
    }
    public void UpgradAttackSpeed()
    {
        if (level[1] < 10)
        {
            level[1]++;
            levelText[1].text = string.Format("{0} / {1}", level[1], 10);
            Debug.Log("무기의 속도를 업그레이드 됨");
        }
        gameObject.SetActive(false);
    }
    public void UpgradSpeed()
    {
        if (level[2] < 10)
        {
            level[2]++;
            levelText[2].text = string.Format("{0} / {1}", level[2], 10);
            Debug.Log("플레이어의 속도가 업그레이드 됨");
        }
        gameObject.SetActive(false);
    }
}
