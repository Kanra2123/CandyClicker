using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioMenager : MonoBehaviour
{

    public Sound[] sounds;

    void Awake ()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

   public void Play (string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        s.source.Play();
    }
}
