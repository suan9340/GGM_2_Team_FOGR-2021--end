using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    #region �ν�����
    #endregion
    [Header("����� ����� �ҽ�")] [SerializeField] private AudioSource turn, click;
    public void Click()
    {
        click.Play();
    }
    public void Turn()
    {
        turn.Play();
    }
}
