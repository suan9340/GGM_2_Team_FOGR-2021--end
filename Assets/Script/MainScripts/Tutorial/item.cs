using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : TutoBase
{
    protected override void OnMouseUp()
    {
        gameObject.SetActive(false);
        TutorialManager.Instance.isStory13 = true;
        Debug.Log("아이템을 먹었어");
    }
}
