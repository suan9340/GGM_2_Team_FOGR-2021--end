using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material : TutoBase
{
    [SerializeField] private GameObject mouse = null;
    public void Attacked()
    {
        if (TutorialManager.Instance.isStory7)
        {
            TutorialManager.Instance.isStory8 = true;
            gameObject.SetActive(false);
            TutorialManager.Instance.isbig();
            mouse.SetActive(false);
        }
        else return;
    }
}
