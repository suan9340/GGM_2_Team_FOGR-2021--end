using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    SpriteRenderer spriteRenderer = null;
    [SerializeField] private GameObject DonClickChang;  // 클릭 방지용 창
    [SerializeField] private GameObject OutGameChang;   // 겜 종료 창
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioSource bgm;

    [SerializeField] private Image[] UIimages;
    private bool isOutGame = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // 게임 시작하기 버튼 눌렀을 때 실행되는 함수
    public void OnClickStartGame()
    {
        UIimages[0].sprite = sprite[1];
        Debug.Log("게임 시작에 성공해써@!!!");
        SceneManager.LoadScene("Main");
    }


    // 설명서 및 튜토리얼 버튼 눌렀을 떄 실행되는 함수
    public void OnClickTutoAndSetting()
    {
        UIimages[1].sprite = sprite[3];
        Debug.Log("튜토리얼 및 설명서 시작");
        SceneManager.LoadScene("Tutorial");
    }
    // 게임 종료 버튼 눌렀을 때 실행되는 함수
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
    public void OnClickStory()
    {
        bgm.volume = 0.15f;
        UIimages[3].sprite = sprite[7];
        storyPanel.SetActive(true);
    }
    public void EndStory()
    {
        bgm.volume = 1;
        UIimages[3].sprite = sprite[6];
    }
    public void OnClickSetting()
    {
        UIimages[4].sprite = sprite[8];
        settingPanel.SetActive(true);
    }
    public void EndSetting()
    {
        UIimages[4].sprite = sprite[9];
    }

    // 게임 종료 창 끄는 거 눌렀을 때 함수
    public void OnClickOutGameXXXX()
    {
        UIimages[2].sprite = sprite[4];
        isOutGame = !isOutGame;
        OutGameChang.SetActive(false);
        DonClickChang.SetActive(false);
    }

    public void OnClickOutYesYes()
    {
        Debug.Log("게임 종료 성공!!");
        Application.Quit();
    }
    public void ClickAudio(int i)
    {
        audioSources[i].Play();
    }

}
