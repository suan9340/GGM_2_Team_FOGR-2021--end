using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    SpriteRenderer spriteRenderer = null;
    [SerializeField] private GameObject DonClickChang;  // Ŭ�� ������ â
    [SerializeField] private GameObject OutGameChang;   // �� ���� â
    [SerializeField] private Sprite[] sprite;

    [SerializeField] private Image[] UIimages;
    private bool isOutGame = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // ���� �����ϱ� ��ư ������ �� ����Ǵ� �Լ�
    public void OnClickStartGame()
    {
        UIimages[0].sprite = sprite[1];
        Debug.Log("���� ���ۿ� �����ؽ�@!!!");
        SceneManager.LoadScene("Main");
    }


    // ���� �� Ʃ�丮�� ��ư ������ �� ����Ǵ� �Լ�
    public void OnClickTutoAndSetting()
    {
        UIimages[1].sprite = sprite[3];
        Debug.Log("Ʃ�丮�� �� ���� ����");
        SceneManager.LoadScene("Tutorial");
    }


    // ���� ���� ��ư ������ �� ����Ǵ� �Լ�
    public void OnClickOutGame()
    {
        isOutGame = !isOutGame;
        if(isOutGame)
        {
            UIimages[2].sprite = sprite[5];
            OutGameChang.SetActive(true);
            DonClickChang.SetActive(true);
        }
        else
        {
            OutGameChang.SetActive(false);
            DonClickChang.SetActive(false);

        }
    }

    // ���� ���� â ���� �� ������ �� �Լ�
    public void OnClickOutGameXXXX()
    {
        UIimages[2].sprite = sprite[4];
        isOutGame = !isOutGame;
        OutGameChang.SetActive(false);
        DonClickChang.SetActive(false);
    }

    public void OnClickOutYesYes()
    {
        Debug.Log("���� ���� ����!!");
        Application.Quit();
    }

}
