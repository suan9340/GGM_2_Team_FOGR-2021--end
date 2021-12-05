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
            Debug.Log("강화용 재료가 늘어나");
            TutorialManager.Instance.isSamll();
            TutorialManager.Instance.isStory12 = true;
        }
        else return;
    }
}
