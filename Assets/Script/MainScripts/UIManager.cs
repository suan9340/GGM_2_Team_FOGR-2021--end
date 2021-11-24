using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region 인스펙터
    [Header("재료 표시용 텍스트")] [SerializeField] private Text matarialText;
    [Header("점수 표시용 텍스트")] [SerializeField] private Text scoreText;
    [Header("Level 애 대응할 텍스트")] [SerializeField] private Text levelText;
    [Header("게임오버 판넬")] [SerializeField] private GameObject overPannel;
    [Header("업그레이드 판넬")] [SerializeField] private GameObject upgradePanel;
    [Header("경험치 슬라이더")] [SerializeField] private Slider slider;
    [Header("중지 판넬")] [SerializeField] private GameObject pausePannel;
    [Header("현제 무기 표시할 오브젝트")] [SerializeField] private GameObject[] wappenUI;
    [Header("현제 버프를 표시할 이미지")] [SerializeField] private GameObject buffImage;
    #endregion
    private void Start()
    {
        StartCoroutine(AddScore());
    }
    public void UpdateUI()
    {
        slider.value = GameManager.Instance.GetSliderValue();
        levelText.text = string.Format("Stage : {0}", GameManager.Instance.CurExpLevel);
        matarialText.text = string.Format("재료 : {0} / {1}",GameManager.Instance.Matarial,GameManager.Instance.MatarialAmount);
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
        Time.timeScale = 0;
        upgradePanel.SetActive(true);
    }
    public void BreakTime(int time)
    {

    }
    public void BuffOn(float dur, Sprite sprite)
    {
        buffImage.SetActive(true);
        buffImage.GetComponent<Skill>().SetUp(dur,sprite);
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