using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class trash : MonoBehaviour
{
    [SerializeField] private GameObject mouse = null;
    public void Attacked()
    {
        if (TutorialManager.Instance.isStory11)
        {
            gameObject.SetActive(false);
            Debug.Log("강화용 재료가 늘어나");
            mouse.SetActive(false);
            TutorialManager.Instance.isStory12 = true;
        }
        else return;
    }
}