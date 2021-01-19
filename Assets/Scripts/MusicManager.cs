using UnityEngine.Audio;
using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager MusicManagerInstance;

    public SoundEffect[] sounds;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (MusicManagerInstance == null)
        {
            MusicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (SoundEffect s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound_clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlaySound(string name) //To play a sound use => FindObjectOfType<MusicManager>().PlaySound("name of sound");
    {
        SoundEffect sfx = Array.Find(sounds, sound => sound.name == name);
        if (sfx == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        sfx.source.PlayOneShot(sfx.sound_clip);
    }
}
