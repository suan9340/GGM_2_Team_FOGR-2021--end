using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    #region 인스펙터
    #endregion
    [Header("출력할 오디오 소스")] [SerializeField] private AudioSource turn, click, next,keyboard;
    public void Click()
    {
        click.Play();
    }
    public void Turn()
    {
        turn.Play();
    }
    public void Next()
    {
        next.Play();
    }

    public void keyboardPlay()
    {
        keyboard.Play();
    }

    public void keyboardStop()
    {
        keyboard.Stop();
    }
}
