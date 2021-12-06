using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoSingleton<TutorialManager>
{
    public bool isStory6 = false;
    public bool isStory7 = false;
    public bool isStory8 = false;
    public bool isStory9 = false;
    public bool isStory11 = false;
    public bool isStory12 = false;
    public bool isStory13 = false;
    [SerializeField] private Animator small;
    [SerializeField] private Animator change;

    public void isSamll()
    {
        small.Play("1");
    }

    public void isbig()
    {
        small.Play("2");
    }

    public void changeweapon()
    {
        change.Play("change");
    }
}
