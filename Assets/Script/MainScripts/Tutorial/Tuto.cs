using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour
{
    [SerializeField] private Text storyText = null;
    [SerializeField] private string[] story;
    private int index = 1;
    private void Start()
    {
        Tutorial(index);
    }

    private void Tutorial(int num)
    {
        switch(num)
        {
            case 1:
                First();
                break;

            case 2:

                break;
        }
    }

    private void First()
    {
        Debug.Log("fir");
        storyText.text = story[0];
    }
}
