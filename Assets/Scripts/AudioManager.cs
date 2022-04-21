using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public static bool isPlayingClip;
    private void Awake()
    {
        if(instance == null)
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
            s.source.loop = s.loop;
        }

    }

    public void Play(string name)
    {
        isPlayingClip = true;
        Sound s =Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        isPlayingClip = false;
    }

    /*
    public void PlayOnce(AudioClip clip)
    {
        isPlayingClip = true;
        Sound s = Array.Find(sounds, clip => clip.name == "Flamey_footsteps1.8");
        s.source.PlayOneShot(clip);
        s.source.loop = false;
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return; 
        }
    }
    */
}
