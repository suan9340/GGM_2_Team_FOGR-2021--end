using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : TutoBase
{
    protected override void OnMouseUp()
    {
        if (TutorialManager.Instance.isStory11)
        {
            gameObject.SetActive(false);
            Debug.Log("��ȭ�� ��ᰡ �þ");
            TutorialManager.Instance.isSamll();
            TutorialManager.Instance.isStory12 = true;
        }
        else return;
    }
}
