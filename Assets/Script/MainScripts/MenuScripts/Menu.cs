using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
        Debug.Log("���� ���ῡ ����!!");
        Application.Quit();
    }
}
