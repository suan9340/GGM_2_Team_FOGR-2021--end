using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region �ν�����
    [SerializeField] private GameObject DonClickChang;  // Ŭ�� ������ â
    [SerializeField] private GameObject OutGameChang;   // �� ���� â
    #endregion

    private bool isOutGame = false;
    // ���� �����ϱ� ��ư ������ �� ����Ǵ� �Լ�
    public void OnClickStartGame()
    {
        Debug.Log("���� ���ۿ� �����ؽ�@!!!");
        SceneManager.LoadScene("Main");
    }


    // ���� �� Ʃ�丮�� ��ư ������ �� ����Ǵ� �Լ�
    public void OnClickTutoAndSetting()
    {
        Debug.Log("Ʃ�丮�� �� ���� ����");
        SceneManager.LoadScene("Tutorial");
    }


    // ���� ���� ��ư ������ �� ����Ǵ� �Լ�
    public void OnClickOutGame()
    {
        isOutGame = !isOutGame;
        if(isOutGame)
        {
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
