using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material : TutoBase
{
    protected override void OnMouseUp()
    {
        if (TutorialManager.Instance.isStory7)
        {
            TutorialManager.Instance.isStory8 = true;
            gameObject.SetActive(false);
            TutorialManager.Instance.isbig();
        }
        else return;
       
    }
}
