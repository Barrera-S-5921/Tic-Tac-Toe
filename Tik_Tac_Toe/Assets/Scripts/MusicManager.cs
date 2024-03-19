using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] songs;
    public float volume;
    [SerializeField] public float _trackTimer;
    [SerializeField] public float _songsPlayed;
    [SerializeField] public bool[] _beenPlayed;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _beenPlayed = new bool[songs.Length];

        if (!_audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = volume;

        if (_audioSource.isPlaying)
        {
            _trackTimer += Time.deltaTime;
        }

        if (!_audioSource.isPlaying || _trackTimer >= _audioSource.clip.length)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
           
    }

    public void ChangeSong(int songPicked)
    {
        _trackTimer = 0;
        _songsPlayed++;
        _
        _audioSource.clip = songs[songPicked];
        _audioSource.Play();
    }
}
