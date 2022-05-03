using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private MusicManager musicManager;

    private void Awake()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    public void PlayMusic()
    {
        if (musicManager != null)
        {
            musicManager.EnableMusic();
        }
    }
}
