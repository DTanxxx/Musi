using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Music musicToPlay = null;

    private KeySpawner keySpawner;
    private AudioSource musicPlayer;

    private bool transitioning = false;
    private bool musicEnabled = false;

    public delegate void OnFinishPlaying();
    public static OnFinishPlaying onFinishPlaying;

    private void Start()
    {
        keySpawner = FindObjectOfType<KeySpawner>();
        musicPlayer = GetComponent<AudioSource>();
    }

    public IEnumerator PlayMusic()
    {
        musicPlayer.PlayOneShot(musicToPlay.GetMusic());
        musicEnabled = true;
        float[] timeStamps = musicToPlay.GetTimeStamps();
        GameObject[] keys = musicToPlay.GetKeys();
        for (int i = 0; i < timeStamps.Length; ++i)
        {
            if (i == 0) { yield return new WaitForSeconds(timeStamps[i]); }
            else { yield return new WaitForSeconds(timeStamps[i] - timeStamps[i - 1]); }
            // Time stamp is up, spawn key.
            keySpawner.SpawnKey(keys[i]);
        }
    }

    public void EnableMusic()
    {
        StartCoroutine(PlayMusic());
    }

    private void Update()
    {
        if (musicEnabled && !musicPlayer.isPlaying && !transitioning)
        {
            transitioning = true;
            onFinishPlaying();
        }
    }

    public void SetMusicToPlay(Music music)
    {
        musicToPlay = music;
    }

    public Music GetMusicToPlay()
    {
        return musicToPlay;
    }
}
