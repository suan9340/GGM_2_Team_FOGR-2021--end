using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider MasterSoundSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider soundSlider;
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        /*PlayerPrefs.SetFloat("BGM", bgmSlider.value);
        PlayerPrefs.SetFloat("Master", MasterSoundSlider.value);
        PlayerPrefs.SetFloat("SFX", soundSlider.value);*/
        MasterSoundSlider.value = PlayerPrefs.GetFloat("Master");
        bgmSlider.value = PlayerPrefs.GetFloat("BGM");
        soundSlider.value = PlayerPrefs.GetFloat("SFX");
    }
    public void ChangeBGMVolume(float volume)
    {
        if (volume <= -30f)
        {
            audioMixer.SetFloat("BGM", -80f);
        }
        else
        {
            audioMixer.SetFloat("BGM", volume);
            PlayerPrefs.SetFloat("BGM", volume);
        }
    }
    public void ChangeMasterVolume(float volume)
    {
        Debug.Log(volume);
        if (volume <= -30)
        {
            audioMixer.SetFloat("Master", -80f);
        }
        else
        {
            audioMixer.SetFloat("Master", volume);
        }
        PlayerPrefs.SetFloat("Master", volume);
    }
    public void ChangeSFXVolume(float volume)
    {
        if (volume <= -30)
        {
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFX", volume);
        }
        PlayerPrefs.SetFloat("SFX", volume);
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
