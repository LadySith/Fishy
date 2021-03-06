﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundEffect
{
    public string name;

    public AudioClip sound_clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
