using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region 인스펙터
    [SerializeField] private GameObject DonClickChang;  // 클릭 방지용 창
    [SerializeField] private GameObject OutGameChang;   // 겜 종료 창
    #endregion

    private bool isOutGame = false;
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

    // 게임 종료 창 끄는 거 눌렀을 때 함수
    public void OnClickOutGameXXXX()
    {
        isOutGame = !isOutGame;
        OutGameChang.SetActive(false);
        DonClickChang.SetActive(false);

    }

    public void OnClickOutYesYes()
    {
        Debug.Log("게임 종료 성공!!");
        Application.Quit();
    }

}
