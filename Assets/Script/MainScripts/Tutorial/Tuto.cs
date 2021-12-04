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

    private Vector3 enemyPosition;
    private bool isTyping = true;
    private bool isTyping_ing = true;
    [SerializeField] private int index = 1;

    [Header("변수")]
    #region 변수들

    [SerializeField] private GameObject score = null;
    [SerializeField] private GameObject stage = null;
    [SerializeField] private GameObject home = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private GameObject material = null;
    [SerializeField] private GameObject trash = null;
    [SerializeField] private GameObject item = null;
    [SerializeField] private GameObject buff = null;
    [SerializeField] private GameObject outTuto = null;
    [SerializeField] private GameObject arrow = null;
    [SerializeField] private GameObject weaponpannel = null;

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

            case 19:
                Nineteen();
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
        for (int i = 0; i < _message.Length; i++)
        {
            _typingText.text = _message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
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
        if(!isTyping)
        {
             if (index == 12)
            {
                if (TutorialManager.Instance.isStory12)
                {
                    index++;
                }
                else return;
            }

            else if (index == 16)
            {
                if (TutorialManager.Instance.isStory13)
                {
                    index++;
                }
            }

            else
            {
                index++;
            }

            Tutorial(index);
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
        enemy.transform.DOMove(new Vector3(0f, 0f, 0f), 2f);
    }

    private void Six()
    {
        TutorialManager.Instance.isStory6 = true;
        StartCoroutine(TypingEffect(storyText, story[5], speed));
        enemy.transform.position = new Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.z);
        enemy.transform.DOMove(new Vector3(0f, 0f, 0f), 3f);
    }

    private void Seven()
    {// 원의 크기는 재료를 흡수해서 가능
        StartCoroutine(TypingEffect(storyText, story[6], speed));
        material.SetActive(true);
    }

    private void Eight()
    {
        TutorialManager.Instance.isStory8 = true;
        StartCoroutine(TypingEffect(storyText, story[7], speed));
    }

    private void Nine()
    {
        StartCoroutine(TypingEffect(storyText, story[8], speed));
        material.transform.DOMove(new Vector3(0f, 0f, 0f), 3f);
    }

    private void Ten()
    {
        weaponpannel.SetActive(true);
        StartCoroutine(TypingEffect(storyText, story[9], speed));
    }

    private void Eleven()
    {
        StartCoroutine(TypingEffect(storyText, story[10], speed));
    }

    private void Twelve()
    {// 쓰레기
        TutorialManager.Instance.isStory11 = true;
        StartCoroutine(TypingEffect(storyText, story[11], speed));
        trash.SetActive(true);
    }

    private void Thirteen()
    {
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
        StartCoroutine(TypingEffect(storyText, story[15], speed));
        item.SetActive(true);
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

    private void Nineteen()
    {
        StartCoroutine(TypingEffect(storyText, story[18], speed));
    }
}

