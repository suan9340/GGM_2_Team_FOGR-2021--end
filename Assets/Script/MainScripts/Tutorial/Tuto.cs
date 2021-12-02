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
    private Transform textTrans;
    [SerializeField] bool isa = false;

    private Vector3 enemyPosition;

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

    #endregion

    private bool isMove = false;
    private void Start()
    {
        textTrans = storyTextTransform;
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

            case 20:
                Twenty();
                break;

            case 21:
                TwentyOne();
                break;

            case 22:
                TwentyTwo();
                break;

            default:
                Debug.Log("끗");
                outTuto.SetActive(true);
                break;
        }

    }

    public void outttTuto()
    {
        SceneManager.LoadScene("Menu");
    }
    public void nextBtn()
    {
        if (isMove)
        {
            return;
        }

        if (index == 8)
        {
            if (TutorialManager.Instance.isStory9)
            {
                index++;
            }
            else return;
        }

        else if (index == 6)
        {
            if (isa)
            {
                index++;
            }
            else return;
        }

        else if (index == 15)
        {
            if (TutorialManager.Instance.isStory16)
            {
                index++;
            }
            else return;
        }

        else if (index == 19)
        {
            if (TutorialManager.Instance.isStory20)
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

    private void One()
    {
        storyText.text = story[0];
    }

    private void Two()
    {
        arrow.SetActive(false);
        score.SetActive(true);
        storyText.text = story[1];
    }

    private void Three()
    {
        stage.SetActive(true);
        storyText.text = story[2];
    }

    private void Four()
    {
        storyText.text = story[3];
    }

    private void Five()
    {
        enemyPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0f);
        enemy.SetActive(true);
        enemy.transform.DOMove(new Vector3(0f, 0f, 0f), 2f);
        Invoke("IsMove", 2f);
        storyText.text = story[4];
    }

    private void Six()
    {
        TutorialManager.Instance.isStory6 = true;
        enemy.transform.position = new Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.z);
        enemy.transform.DOMove(new Vector3(0f, 0f, 0f), 2f);
        storyText.text = story[5];
    }

    private void Seven()
    {
        material.SetActive(true);
        storyText.text = story[6];
    }

    private void Eight()
    {
        TutorialManager.Instance.isStory8 = true;
        storyText.text = story[7];
    }

    private void Nine()
    {
        storyText.text = story[8];
    }

    private void Ten()
    {
        storyText.text = story[9];
    }

    private void Eleven()
    {
        material.SetActive(true);
        material.transform.DOMove(new Vector3(2.53f, 0.38f, 0f), 2f);

        storyText.text = story[10];
    }

    private void Twelve()
    {
        storyText.text = story[11];
    }

    private void Thirteen()
    {
        storyText.text = story[12];
    }

    private void Fourteen()
    {
        storyText.text = story[13];
    }

    private void Fiften()
    {//쓰레기
        TutorialManager.Instance.isStory15 = true;
        trash.SetActive(true);
        storyText.text = story[14];
    }

    private void Sixteen()
    {
        storyText.text = story[15];
    }

    private void Seventeen()
    {
        trash.SetActive(true);
        trash.transform.DOMove(new Vector3(-2.7f, 0.7f, 0f), 2f);

        storyText.text = story[16];
    }

    private void Eighteen()
    {
        storyText.text = story[17];
    }

    private void Nineteen()
    {//아이템
        item.SetActive(true);
        storyText.text = story[18];
    }

    private void Twenty()
    {//버프
        buff.SetActive(true);
        storyText.text = story[19];
    }

    private void TwentyOne()
    {
        storyText.text = story[20];
    }

    private void TwentyTwo()
    {
        storyText.text = story[21];
    }

    private void IsMove()
    {
        isa = true;
    }
}
