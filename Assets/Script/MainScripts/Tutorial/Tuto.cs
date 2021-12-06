using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Tuto : MonoBehaviour
{
    [SerializeField] private Button nextButton = null;
    [SerializeField] private Text storyText = null;
    [SerializeField] private Transform storyTextTransform = null;
    [SerializeField] private string[] story;
    [SerializeField] private float speed;
    [SerializeField] SoundManager soundManager;

    private Vector3 enemyPosition;
    private bool isTyping = true;
    private bool isTyping_ing = true;
    [SerializeField] private int index = 1;

    [Header("변수")]
    #region 변수들

    [SerializeField] private GameObject score = null;
    [SerializeField] private GameObject stage = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private GameObject material = null;
    [SerializeField] private GameObject trash = null;
    [SerializeField] private GameObject item = null;
    [SerializeField] private GameObject buff = null;
    [SerializeField] private GameObject outTuto = null;
    [SerializeField] private GameObject arrow = null;
    [SerializeField] private GameObject weaponpannel = null;
    [SerializeField] private GameObject weapon1 = null;
    [SerializeField] private Text materalText = null;
    [SerializeField] private GameObject materialPannel = null;
    [SerializeField] private GameObject click1 = null;
    [SerializeField] private GameObject click2 = null;

    #endregion

    private void Start()
    {
        Tutorial(index);
    }


    private void Tutorial(int num)
    {

        switch (num)
        {
            case 1:
                One();
                break;

            case 2:
                Two();
                break;

            case 3:
                Three();
                break;

            case 4:
                Four();
                break;

            case 5:
                Five();
                break;

            case 6:
                Six();
                break;

            case 7:
                Seven();
                break;

            case 8:
                Eight();
                break;

            case 9:
                Nine();
                break;

            case 10:
                Ten();
                break;

            case 11:
                Eleven();
                break;

            case 12:
                Twelve();
                break;

            case 13:
                Thirteen();
                break;

            case 14:
                Fourteen();
                break;

            case 15:
                Fiften();
                break;

            case 16:
                Sixteen();
                break;

            case 17:
                Seventeen();
                break;

            case 18:
                Eighteen();
                break;


            default:
                Debug.Log("끗");
                outTuto.SetActive(true);
                break;
        }

    }
    private IEnumerator TypingEffect(Text _typingText, string _message, float _speed)
    {
        isTyping_ing = true;
        isTyping = true;
        TutorialManager.Instance.isTypingSound = true;
        soundManager.keyboardPlay();
        for (int i = 0; i < _message.Length; i++)
        {
            _typingText.text = _message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        soundManager.keyboardStop();    
        TutorialManager.Instance.isTypingSound = false;
        TutorialManager.Instance.isSpeedTypingSound = false;
        speed = 0.1f;
        isTyping_ing = false;
        isTyping = false;
    }
    public void outttTuto()
    {
        SceneManager.LoadScene("Menu");
    }
    public void nextBtn()
    {
        if (!isTyping)
        {
            if (index == 12)
            {
                if (TutorialManager.Instance.isStory12)
                {
                    index++;
                    soundManager.Next();
                }
                else return;
            }


            else if (index == 7)
            {
                if (TutorialManager.Instance.isStory8)
                {
                    index++;
                    soundManager.Next();
                }

                else return;
            }
            else if (index == 16)
            {
                if (TutorialManager.Instance.isStory13)
                {
                    index++;
                    soundManager.Next();
                }
            }

            else
            {
                index++;
                soundManager.Next();
            }

            Tutorial(index);
        }
    }

    private IEnumerator click()
    {
        for(int i=0;i<8;i++)
        {
            click1.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            click1.SetActive(false);
            click2.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            click2.SetActive(false);
        }
    }
    private void One()
    {
        StartCoroutine(TypingEffect(storyText, story[0], speed));
    }

    private void Two()
    {
        StartCoroutine(TypingEffect(storyText, story[1], speed));
        arrow.SetActive(false);
        score.SetActive(true);
    }

    private void Three()
    {
        stage.SetActive(true);
        StartCoroutine(TypingEffect(storyText, story[2], speed));
    }

    private void Four()
    {
        StartCoroutine(TypingEffect(storyText, story[3], speed));
    }

    private void Five()
    {
        StartCoroutine(TypingEffect(storyText, story[4], speed));
        enemyPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0f);
        enemy.SetActive(true);
        enemy.transform.DOMove(new Vector3(0f, 0f, 0f), 1.5f);
    }

    private void Six()
    {
        TutorialManager.Instance.isStory6 = true;
        StartCoroutine(TypingEffect(storyText, story[5], speed));
        enemy.transform.position = new Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.z);
        enemy.transform.DOMove(new Vector3(0f, 0f, 0f), 2f);
    }

    private void Seven()
    {// 원의 크기는 재료를 흡수해서 가능
        //클릭
        TutorialManager.Instance.isStory7 = true;
        StartCoroutine(TypingEffect(storyText, story[6], speed));
        material.SetActive(true);
        click1.transform.position = new Vector3(4.97f, 1.71f, 0f);
        click2.transform.position = new Vector3(4.97f, 1.71f, 0f);
        StartCoroutine(click());
    }

    private void Eight()
    {
        StartCoroutine(TypingEffect(storyText, story[7], speed));
    }

    private void Nine()
    {// 강화용 증가
        material.SetActive(true);
        materialPannel.SetActive(true);
        materalText.enabled = true;
        materalText.text = string.Format("재료 1 / 5");
        StartCoroutine(TypingEffect(storyText, story[8], speed));
        material.transform.DOMove(new Vector3(0f, 0f, 0f), 3f);//속도좀줄ㅇ리자
    }

    private void Ten()
    {//무기레벨 또한 일정 레벨에 도달하면
        weaponpannel.SetActive(true);
        weapon1.SetActive(true);
        StartCoroutine(TypingEffect(storyText, story[9], speed));
    }

    private void Eleven()
    {
        weapon1.SetActive(false);
        TutorialManager.Instance.changeweapon();
        StartCoroutine(TypingEffect(storyText, story[10], speed));
    }

    private void Twelve()
    {// 쓰레기
        //클릭
        TutorialManager.Instance.isStory11 = true;
        StartCoroutine(TypingEffect(storyText, story[11], speed));
        trash.SetActive(true);
        click1.transform.position = new Vector3(-5.66f, 1.9f, 0f);
        click2.transform.position = new Vector3(-5.66f, 1.9f, 0f);
        StartCoroutine(click());
    }

    private void Thirteen()
    {
        materalText.text = string.Format("재료 2 / 5");
        StartCoroutine(TypingEffect(storyText, story[12], speed));
    }

    private void Fourteen()
    {
        StartCoroutine(TypingEffect(storyText, story[13], speed));
        trash.SetActive(true);
        trash.transform.DOMove(new Vector3(0f, 0f, 0f), 3f);
    }

    private void Fiften()
    {
        StartCoroutine(TypingEffect(storyText, story[14], speed));
    }

    private void Sixteen()
    {// 아이템
        //클릭
        StartCoroutine(TypingEffect(storyText, story[15], speed));
        item.SetActive(true);
        click1.transform.position = new Vector3(4.18f, -2.88f, 0f);
        click2.transform.position = new Vector3(4.18f, -2.88f, 0f);
        StartCoroutine(click());
    }

    private void Seventeen()
    {//버프
        StartCoroutine(TypingEffect(storyText, story[16], speed));
        buff.SetActive(true);
    }

    private void Eighteen()
    {
        StartCoroutine(TypingEffect(storyText, story[17], speed));
    }
}

