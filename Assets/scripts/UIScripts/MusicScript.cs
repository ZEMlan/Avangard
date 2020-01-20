using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource music;
    void Start()
    {
        if(music == null)
            music = Camera.main.GetComponent<AudioSource>();
        music.clip = clips[Random.Range(0, clips.Length - 1)];
        music.Play();
    }

    private void Update()
    {
        if (!music.isPlaying)
        {
            music.clip = clips[Random.Range(0, clips.Length - 1)];
            music.Play();
        }
    }
}
