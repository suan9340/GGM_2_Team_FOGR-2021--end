using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingManager : MonoBehaviour
{
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider soundSlider;
    public void Apply()
    {

    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
