using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material : MonoBehaviour
{
    private void OnMouseUp()
    {
        if (TutorialManager.Instance.isStory8)
        {
            gameObject.SetActive(false);
            Debug.Log("��Ḧ �����");
            TutorialManager.Instance.isStory9 = true;
        }
        else return;
    }

   
}


