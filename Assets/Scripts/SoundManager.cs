using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] AudioSources;
    private AudioSource AudioBackGround;
    public static SoundManager Insatance;
    private void Awake()
    {
        Insatance = this;
        AudioSources = GetComponents<AudioSource>();
        LoadConfig();
    }
    private void Start()
    {
      
    }

    public void PlaySound(string clipName)
    {
        AudioSource audioSource = GetFreeAudioSource();
        audioSource.clip = Resources.Load<AudioClip>(clipName);
        audioSource.Play();
    }
    public void SetVolume(float volume)
    {
        for (int i = 0; i < AudioSources.Length; i++)
        {
            AudioSource audioSource = AudioSources[i];
            audioSource.volume = volume;
        }
    }
    private AudioSource GetFreeAudioSource()
    {
        for (int i = 1; i < AudioSources.Length; i++)
        {
            AudioSource audioSource = AudioSources[i];
            if(!audioSource.isPlaying)
                return audioSource;
        }
        return gameObject.AddComponent<AudioSource>();
    }
    private void LoadConfig()
    {
        PlayerPrefsDataProxy ppdProxy= AppFacade.GetInstance(() => new AppFacade()).RetrieveProxy(PlayerPrefsDataProxy.NAME) as PlayerPrefsDataProxy;
        if (!ppdProxy.VO.SPD.SoundToggle)
            SetVolume(0);
        else
            SetVolume((float)ppdProxy.VO.SPD.SoundVoloum);
    }
}
