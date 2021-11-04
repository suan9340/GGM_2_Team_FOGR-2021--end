using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Skill : MonoBehaviour
{
    bool isStart = true;
    public float duration, time;
    [Header("��� �̹���")] [SerializeField] private Image backImage;
    [Header("���� �̹���")] [SerializeField] private Image image;
    Sprite sprite;
    public void Start()
    {
        time = duration;
    }
    public void SetUp(float _dur, Sprite _sprite)
    {
        duration = _dur;
        sprite = _sprite;
        time = duration;
        backImage.sprite = sprite;
        image.sprite = sprite;
        isStart = true;
    }
    void Update()
    {
        if (isStart)
        {
            time -= Time.deltaTime;
            image.fillAmount = time / duration;
            if(time < 0)
            {
                isStart = false;
                gameObject.SetActive(false);
            }
        }
    }
}