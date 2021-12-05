using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Story : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image image;
    [SerializeField] Menu menu;
    [SerializeField] AudioSource audio;
    int page = 0;
    public void Next()
    { 
        page++;
        if(page >= sprites.Length)
        {
            page = 0;
            image.sprite = sprites[page];
            menu.EndStory();
            gameObject.SetActive(false);
        }
        audio.Play();
        image.sprite = sprites[page];
    }
}
