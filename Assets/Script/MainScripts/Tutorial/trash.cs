using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : TutoBase
{
    [SerializeField] private GameObject mouse = null;
    protected override void OnMouseUp()
    {
        if (TutorialManager.Instance.isStory11)
        {
            gameObject.SetActive(false);
            Debug.Log("��ȭ�� ��ᰡ �þ");
            mouse.SetActive(false);
            TutorialManager.Instance.isStory12 = true;
        }
        else return;
    }
}
