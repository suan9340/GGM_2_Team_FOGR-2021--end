using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // 게임 시작하기 버튼 눌렀을 때 실행되는 함수
    public void OnClickStartGame()
    {
        Debug.Log("게임 시작에 성공해써@!!!");
        SceneManager.LoadScene("Main");
    }


    // 설명서 및 튜토리얼 버튼 눌렀을 떄 실행되는 함수
    public void OnClickTutoAndSetting()
    {
        Debug.Log("튜토리얼 및 설명서 시작");
        SceneManager.LoadScene("Tutorial");
    }


    // 게임 종료 버튼 눌렀을 때 실행되는 함수
    public void OnClickOutGame()
    {
        Debug.Log("게임 종료에 성공!!");
        Application.Quit();
    }
}
