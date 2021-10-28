using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region �ν�����
    [Header("��� ǥ�ÿ� �ؽ�Ʈ")] [SerializeField] private Text matarialText;
    [Header("���� ǥ�ÿ� �ؽ�Ʈ")] [SerializeField] private Text scoreText;
    [Header("���ӿ��� �ǳ�")] [SerializeField] private GameObject overPannel;
    [Header("���׷��̵� �ǳ�")] [SerializeField] private GameObject upgradePanel;
    [Header("����ġ �����̴�")] [SerializeField] private Slider slider;
    [Header("���� �ǳ�")] [SerializeField] private GameObject pausePannel;
    [Header("���� ���� ǥ���� ������Ʈ")] [SerializeField] private GameObject[] wappenUI;
    #endregion
    private void Start()
    {
        StartCoroutine(AddScore());
    }
    public void UpdateUI()
    {
        matarialText.text = string.Format("��� : {0}",GameManager.Instance.Matarial);
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