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
            Debug.Log("강화용 재료가 늘어나");
            TutorialManager.Instance.isStory16 = true;
        }
        else return;
    }
}
