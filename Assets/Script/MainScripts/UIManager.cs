using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region �ν�����
    [Header("��� ǥ�ÿ� �ؽ�Ʈ")] [SerializeField] private Text ingredientText;
    [Header("���� ���� ���� �ؽ�Ʈ")] [SerializeField] private Text levelText;
    [Header("���� ǥ�ÿ� �ؽ�Ʈ")] [SerializeField] private Text scoreText;
    [Header("Level �� ������ �ؽ�Ʈ")] [SerializeField] private Text stageText;
    [Header("���ӿ��� �ǳ�")] [SerializeField] private GameObject overPannel;
    [Header("���׷��̵� �ǳ�")] [SerializeField] private GameObject upgradePanel;
    [Header("����ġ �����̴�")] [SerializeField] private Slider slider;
    [Header("���� �ǳ�")] [SerializeField] private GameObject pausePannel;
    [Header("���� ���� ǥ���� ������Ʈ")] [SerializeField] private GameObject[] wappenUI;
    [Header("���� ������ ǥ���� �̹���")] [SerializeField] private GameObject buffImage;
    [Header("���½ð� ǥ�ÿ� �ؽ�Ʈ")] [SerializeField] private Text breakTimeText;
    [Header("���� �ǳ�")] [SerializeField] private GameObject endingPannel;
    #endregion
    private void Start()
    {
        StartCoroutine(GetScore());
    }
    private IEnumerator GetScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            scoreText.text = string.Format("Score : {0}", GameManager.Instance.Exp);
        }
    }
    public void UpdateUI()
    {
        slider.value = GameManager.Instance.GetSliderValue();
        stageText.text = string.Format("Stage : {0}", GameManager.Instance.CurExpLevel);
        ingredientText.text = string.Format("��� : {0} / {1}",GameManager.Instance.Ingredient,GameManager.Instance.IngredientAmount);
        levelText.text = string.Format("���� : {0} / {1}", GameManager.Instance.CurWeaponLevel, GameManager.Instance.WeaponLevelLength);
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
        GameManager.Instance.IsCanESC = false;
        upgradePanel.SetActive(true);
        GameManager.Instance.EndingManager.ShowNextEnemy();
    }
    /*public void BreakTime(int time)
    {

    }*/
    public void BuffOn(float dur, Sprite sprite)
    {
        buffImage.SetActive(true);
        buffImage.GetComponent<Skill>().SetUp(dur,sprite);
    }
    public void Pause(bool isOn)
    {
        pausePannel.SetActive(isOn);
        if (isOn)
        {
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(BreakTime(3));
        }
    }

    public IEnumerator BreakTime(int time)
    {
        GameManager.Instance.IsCanESC = false;
        Time.timeScale = 0;
        breakTimeText.gameObject.SetActive(true);
        for (int i = time; i > 0; i--)
        {
            breakTimeText.text = string.Format("{0}", i);
            yield return new WaitForSecondsRealtime(1f);
        }
        breakTimeText.gameObject.SetActive(false);
        GameManager.Instance.IsCanESC = true;
        Time.timeScale = 1;
    }
    public void Over()
    {
        overPannel.SetActive(true);
    }
    public void Ending()
    {
        Time.timeScale = 0;
        endingPannel.SetActive(true);
    }
}