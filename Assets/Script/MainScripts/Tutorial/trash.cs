using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
    private void OnMouseUp()
    {
        if (TutorialManager.Instance.isStory15)
        {
            gameObject.SetActive(false);
            Debug.Log("��ȭ�� ��ᰡ �þ");
            TutorialManager.Instance.isStory16 = true;
        }
        else return;
    }
}
