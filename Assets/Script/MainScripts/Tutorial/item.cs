using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : TutoBase
{
    [SerializeField] private GameObject mouse = null;
    protected override void OnMouseUp()
    {
        gameObject.SetActive(false);
        TutorialManager.Instance.isStory13 = true;
        Debug.Log("�������� �Ծ���");
        mouse.SetActive(false);
    }
}
