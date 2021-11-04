using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region 인스펙터
    [Header("재료 표시용 텍스트")] [SerializeField] private Text matarialText;
    [Header("점수 표시용 텍스트")] [SerializeField] private Text scoreText;
    [Header("게임오버 판넬")] [SerializeField] private GameObject overPannel;
    [Header("업그레이드 판넬")] [SerializeField] private GameObject upgradePanel;
    [Header("경험치 슬라이더")] [SerializeField] private Slider slider;
    [Header("중지 판넬")] [SerializeField] private GameObject pausePannel;
    [Header("현제 무기 표시할 오브젝트")] [SerializeField] private GameObject[] wappenUI;
    #endregion
    private void Start()
    {
        StartCoroutine(AddScore());
    }
    public void UpdateUI()
    {
        matarialText.text = string.Format("재료 : {0}",GameManager.Instance.Matarial);
    }
    public void ChangeUiWappen(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            wappenUI[i].SetActive(false);
        }
        wappenUI[index].SetActive(true);
    }
    public void ShowUpgradePannel()
    {

    }
    public void BreakTime(int time)
    {

    }
    public void Pause(bool isOn)
    {
        pausePannel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Over()
    {
        overPannel.SetActive(true);
    }
    private IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            scoreText.text = string.Format("Score : {0}",GameManager.Instance.Exp);
        }
    }
}