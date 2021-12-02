using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    private void OnMouseUp()
    {
        gameObject.SetActive(false);
        TutorialManager.Instance.isStory20 = true;
        Debug.Log("아이템을 먹었어");
    }
}
