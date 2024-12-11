using UnityEngine;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSound;
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("MusicIsOn", 1) == 1)
        {
            Play("Theme");
        }
        else
        {
            Stop("Theme");
        }
        if (PlayerPrefs.GetInt("SoundIsOn", 1) == 1)
        {
        }
        else
        {
            VolumeOff("Hit");
        }
        sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusic", 1f);
        sliderSound.value = PlayerPrefs.GetFloat("VolumeSound", 1f);
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
    public void VolumeOff(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.volume = 0f;
    }
    public void VolumeOn(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.volume = 1f;
    }
    
    public void UpdateVolumeMusic()
    {
        PlayerPrefs.SetFloat("VolumeMusic", sliderMusic.value);
        foreach(Sound s in sounds)
        {
            if(instance.GetComponent<AudioSource>().clip.name == "MainMenu")
            {
                instance.GetComponent<AudioSource>().volume = sliderMusic.value;
            }
            if (s.isMusic)
            {
                s.volume = PlayerPrefs.GetFloat("VolumeMusic", 1f);
            }
            else if (s.isSound)
            {
                s.volume = PlayerPrefs.GetFloat("VolumeSound", 1f);
            }
        }
    }
    public void UpdateVolumeSound()
    {
        PlayerPrefs.SetFloat("VolumeSound", sliderSound.value);
    }
}
