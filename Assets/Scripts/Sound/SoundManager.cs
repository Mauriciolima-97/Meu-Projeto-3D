using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetups;

    public AudioSource musicSource;

    [Header("Settings")]
    private bool _isMuted = false;

    protected override void Awake()
    {
        base.Awake();
        _isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplyMute();
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        PlayerPrefs.SetInt("Muted", _isMuted ? 1 : 0);

        ApplyMute();
    }

    private void ApplyMute()
    {
        AudioListener.pause = _isMuted;

        AudioListener.volume = _isMuted ? 0 : 1;

        Debug.Log("Som Mutado: " + _isMuted);
    }

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }
    [System.Serializable]
    public enum MusicType
    {
        NONE,
        TYPE_01,
        TYPE_02,
        TYPE_03
    }
    [System.Serializable]
    public class MusicSetup
    {
        public MusicType musicType;
        public AudioClip audioClip;
    }

    public enum SFXType
    {
        TYPE_01,
        TYPE_02,
        TYPE_03,
        NONE
    }
    [System.Serializable]
    public class SFXSetup
    {
        public SFXType sfxType;
        public AudioClip audioClip;
    }

}
