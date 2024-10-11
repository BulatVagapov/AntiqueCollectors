using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string[] nameOfAudioSources;
    [SerializeField] private AudioSource[] ausioSources;

    private int musicPref;
    private int soundPref;

    public int MusicPref => musicPref;
    public int SoundsPref => soundPref;

    private Dictionary<string, AudioSource> audioSourcesDictionary = new();

    protected override void Awake()
    {
        base.Awake();
        LoadAudioPrefs();
    }

    void Start()
    {
        for(int i = 0; i < ausioSources.Length; i++)
        {
            audioSourcesDictionary.Add(nameOfAudioSources[i], ausioSources[i]);
        }

        GameManager.Instance.GameCycleStartEvent += OnGameCycleStart;
        GameManager.Instance.GameCycleEndEvent += OnGameCycleEnd;
        LoadingScreen.Instance.LoadingIsOver += () => PlayAudioSource("ScreenMusic");

        if (musicPref == 0)
        {
            TurnOnMusic();
        }
        else if (musicPref == 1)
        {
            TurnOffVolumeForGroup("MusicVolume");
        }

        if (soundPref == 0)
        {
            TurnOnSounds();
        }
        else if (soundPref == 1)
        {
            TurnOffVolumeForGroup("SoundsVolume");
        }
    }

    public void TurnOffVolumeForGroup(string floatName)
    {
        audioMixer.SetFloat(floatName, -80);
    }

    public void TurnOnMusic()
    {
        audioMixer.SetFloat("MusicVolume", -8);
    }

    public void TurnOnSounds()
    {
        audioMixer.SetFloat("SoundsVolume", 2);
    }

    public void PlayAudioSource(string name)
    {
        audioSourcesDictionary[name].Play();
    }

    public void StopAudioSource(string name)
    {
        audioSourcesDictionary[name].Stop();
    }

    private void OnGameCycleStart()
    {
        StopAudioSource("ScreenMusic");
        PlayAudioSource("GameMusic");
    }

    private void OnGameCycleEnd()
    {
        StopAudioSource("GameMusic");
        PlayAudioSource("ScreenMusic");
    }

    private void LoadAudioPrefs()
    {
        musicPref = PlayerPrefs.GetInt("musicPref", 0);
        soundPref = PlayerPrefs.GetInt("soundsPref", 0);
    }

    public void ChangeMusicPrefs()
    {
        if (musicPref == 0)
        {
            musicPref = 1;
        }
        else if (musicPref == 1)
        {
            musicPref = 0;
        }

        PlayerPrefs.SetInt("musicPref", musicPref);
    }

    public void ChangeSoundsPrefs()
    {
        if (soundPref == 0)
        {
            soundPref = 1;
        }
        else if (soundPref == 1)
        {
            soundPref = 0;
        }

        PlayerPrefs.SetInt("soundsPref", soundPref);
    }
}
